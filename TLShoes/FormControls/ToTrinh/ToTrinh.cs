using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinh : BaseUserControl
    {
        private TongHopToTrinh _currentToTrinh;
        private readonly Dictionary<long, List<ChiTietToTrinh>> _dictChiTietToTrinh = new Dictionary<long, List<ChiTietToTrinh>>();
        private readonly BindingList<TLShoes.ToTrinh> _toTrinhList = new BindingList<TLShoes.ToTrinh>();

        public ucToTrinh(TongHopToTrinh data = null)
        {
            InitializeComponent();

            var lstNguyenLieu = SF.Get<NguyenLieuViewModel>().GetList();
            SetComboboxDataSource(ToTrinh_NguyenLieuId, lstNguyenLieu, "Ten");

            Init(data);

            if (data != null)
            {
                _currentToTrinh = data;
                ToTrinh_NgayLap.Text = data.NgayLap.ToString(CultureInfo.InvariantCulture);
                ToTrinh_NgayDuyet.Text = data.NgayDuyet.ToString(CultureInfo.InvariantCulture);
                if (data.NguoiLap != null)
                {
                    ToTrinh_NguoiLap.Text = data.NguoiLap.TenNguoiDung;
                }
                if (data.NguoiDuyet != null)
                {
                    ToTrinh_NguoiDuyet.Text = data.NguoiDuyet.TenNguoiDung;
                }

                _toTrinhList = new BindingList<TLShoes.ToTrinh>(data.ToTrinhs.ToList());
                SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.TO_TRINH, data.Id);
            }
            InitAuthorize();

            gridToTrinh.DataSource = _toTrinhList;
            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;
        }

        private void InitAuthorize()
        {
            btnCancel.Enabled = false;
            btnDuyet.Enabled = true;
            btnDuyet.Visible = false;
            btnExport.Visible = false;
            btnSave.Enabled = true;

            if (_currentToTrinh != null)
            {
                lblSoPhieu.Text = string.Format("Số Tờ Trình: {0}", _currentToTrinh.SoPhieu);
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_currentToTrinh.TrangThai);

                if (trangThai <= Define.TrangThai.HUY)
                {
                    btnDuyet.Visible = true;
                }

                // Check verify authorize
                if (trangThai == Define.TrangThai.DUYET)
                {
                    if (Authorization.LoginUser.LoaiNguoiDung == Define.LoaiNguoiDung.GDSX.ToString())
                    {
                        btnDuyet.Visible = true;
                        btnCancel.Enabled = true;
                    }
                }

                // Can't save if verified
                if (trangThai > Define.TrangThai.HUY)
                {
                    btnSave.Enabled = false;
                }

                // Allow export after final verify
                if (trangThai == Define.TrangThai.DUYET_PVT)
                {
                    btnExport.Visible = true;
                    btnDuyet.Visible = true;
                    btnDuyet.Enabled = false;
                }

                var verifyAuthorize = Authorization.CheckAuthorization("ToTrinh", Define.Authorization.VERIFY);
                btnDuyet.Visible &= verifyAuthorize;
            }
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }

            using (var transaction = new TransactionScope())
            {
                if (_currentToTrinh == null)
                {
                    _currentToTrinh = new TongHopToTrinh { TrangThai = Define.TrangThai.MOI.ToString() };
                    CRUD.DecorateSaveData(_currentToTrinh);
                    SF.Get<ToTrinhViewModel>().Save(_currentToTrinh);
                }

                foreach (var toTrinh in _toTrinhList)
                {
                    toTrinh.TongHopToTrinhId = _currentToTrinh.Id;
                    CRUD.DecorateSaveData(toTrinh);
                    SF.Get<ToTrinhViewModel>().Save(toTrinh);

                    // Clear old data
                    if (toTrinh.ChiTietToTrinhs != null)
                    {
                        foreach (var chiTietToTrinh in toTrinh.ChiTietToTrinhs)
                        {
                            SF.Get<ChiTietToTrinhViewModel>().Delete(chiTietToTrinh);
                        }
                    }

                    // Save chi tiet to trinh
                    if (toTrinh.NguyenLieuId != null)
                    {
                        var nguyenLieuId = (long)toTrinh.NguyenLieuId;
                        if (_dictChiTietToTrinh.ContainsKey(nguyenLieuId))
                        {
                            foreach (var chiTietToTrinh in _dictChiTietToTrinh[nguyenLieuId])
                            {
                                chiTietToTrinh.ToTrinhId = toTrinh.Id;
                                CRUD.DecorateSaveData(chiTietToTrinh);
                                SF.Get<ChiTietToTrinhViewModel>().Save(chiTietToTrinh);
                            }
                        }
                    }
                }
                transaction.Complete();
            }
            return true;
        }

        private string ValidateInput()
        {
            if (_currentToTrinh != null)
            {
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_currentToTrinh.TrangThai);
                if (trangThai > Define.TrangThai.MOI)
                {
                    return "Tờ trình đã được duyệt nên không thể thay đổi!";
                }
            }
            return string.Empty;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                var nguyenLieuObj = ToTrinh_NguyenLieuId.SelectedValue;
                if (nguyenLieuObj != null)
                {
                    lblThongBao.Text = string.Format("Các đơn hàng đang sử dụng {0}", ToTrinh_NguyenLieuId.Text);

                    var nguyenLieuId = (long)nguyenLieuObj;
                    var chiLenhList = SF.Get<ChiTietNguyenLieuViewModel>().GetList()
                        .Where(s => s.ChiTietNguyenLieuId == nguyenLieuId && s.NguyenLieuChiLenh.ChiLenh.IsDuyet)
                        .GroupBy(s => s.NguyenLieuChiLenh.ChiLenh.DonHang);

                    var xuatKhoList = SF.Get<ChiTietXuatKhoViewModel>().GetListByNguyenLieu(nguyenLieuId);
                    var tongXuatKho = xuatKhoList.Sum(s => s.SoLuong);

                    var nhapKhoList = SF.Get<ChiTietNhapKhoViewModel>().GetListByNguyenLieu(nguyenLieuId);
                    var tongNhapKho = nhapKhoList.Sum(s => s.SoLuong);

                    // Bổ sung là tổng xuất kho ngoài chỉ lệnh
                    var xuatKhoBoSung = xuatKhoList.Where(s => s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.NGOAI_CHI_LENH.ToString()).Sum(s => s.SoLuong);

                    var tonTheKho = tongNhapKho - tongXuatKho;
                    ToTrinh_BoSung.Text = xuatKhoBoSung.ToString(CultureInfo.InvariantCulture);
                    ToTrinh_TonTheKho.Text = tonTheKho.ToString(CultureInfo.InvariantCulture);
                    ToTrinh_DuKien.Text = "0";

                    // Tính toán nhu cầu thực tế và xuất kho theo chỉ lệnh của vật tư
                    var lstChiTietToTrinh = new List<ChiTietToTrinh>();
                    foreach (var chilenh in chiLenhList)
                    {
                        var chitiet = new ChiTietToTrinh();
                        chitiet.DonHangId = chilenh.Key.Id;
                        chitiet.DonHang = chilenh.Key;
                        chitiet.NhuCau = chilenh.Sum(s => s.NguyenLieuChiLenh.DinhMucThuc);
                        chitiet.ThucTe = xuatKhoList.Where(s => s.PhieuXuatKho.DonHang.Id == chitiet.DonHangId
                                                             && s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.TRONG_CHI_LENH.ToString())
                                                    .Sum(s => s.SoLuong);
                        lstChiTietToTrinh.Add(chitiet);
                    }

                    if (!_dictChiTietToTrinh.ContainsKey(nguyenLieuId))
                    {
                        _dictChiTietToTrinh.Add(nguyenLieuId, lstChiTietToTrinh);
                    }
                    gridChiTietToTrinh.DataSource = lstChiTietToTrinh.Select(s => new { s.DonHang.MaHang, s.NhuCau, s.ThucTe });
                }
            }, ParentForm);
        }

        private void btnUpdateToTrinh_Click(object sender, EventArgs e)
        {
            var toTrinh = CRUD.GetFormObject<TLShoes.ToTrinh>(FormControls);
            if (toTrinh.NguyenLieuId != null) toTrinh.NguyenLieu = SF.Get<NguyenLieuViewModel>().GetDetail((long)toTrinh.NguyenLieuId);
            _toTrinhList.Add(toTrinh);
        }
        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewToTrinh.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }

        private void gridViewToTrinh_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var data = gridViewToTrinh.GetRow(gridViewToTrinh.FocusedRowHandle) as TLShoes.ToTrinh;
            if (data != null)
            {
                Init(data);
                if (data.NguyenLieuId != null)
                {
                    var nguyenLieuId = (long)data.NguyenLieuId;
                    gridChiTietToTrinh.DataSource = _dictChiTietToTrinh.ContainsKey(nguyenLieuId) ? _dictChiTietToTrinh[nguyenLieuId] : data.ChiTietToTrinhs.ToList();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export(Define.TEMPLATE_TO_TRINH, (workBook, workSheet) =>
            {
                // Get loai to trinh
                if (_currentToTrinh != null)
                {
                    var groupByNguyenLieu = _toTrinhList.GroupBy(s => s.NguyenLieu.LoaiNguyenLieu).ToList();
                    var loaiToTrinh = "TỔNG HỢP";
                    if (groupByNguyenLieu.Count == 1)
                    {
                        loaiToTrinh = groupByNguyenLieu.First().Key.Ten;
                    }
                    workSheet.Cells[2, "A"] = string.Format("TỜ TRÌNH {0}", loaiToTrinh.ToUpper());
                }

                // Group by don hang 
                var groupedToTrinh = _toTrinhList.SelectMany(s => s.ChiTietToTrinhs).GroupBy(s => s.DonHangId).ToList();
                var startColumn = 4;
                var startRow = 7;
                var dictNguyenLieu = new Dictionary<long, int>();
                foreach (var group in groupedToTrinh)
                {
                    if (group.Key != null)
                    {
                        var donhang = SF.Get<DonHangViewModel>().GetDetail((long)group.Key);
                        if (donhang == null) continue;

                        if (startColumn > 4)
                        {
                            var col = workSheet.Columns[startColumn];
                            col.EntireColumn.Insert(XlInsertShiftDirection.xlShiftToRight);
                        }

                        // Thong tin don hang 
                        workSheet.Cells[4, startColumn] = donhang.MaHang;
                        workSheet.Cells[5, startColumn] = donhang.ChiTietDonHangs.Sum(s => s.SoLuong);
                        workSheet.Cells[6, startColumn] = startColumn;

                        foreach (var chiTietToTrinh in group)
                        {
                            var toTrinh = chiTietToTrinh.ToTrinh;
                            if (toTrinh == null) continue;

                            var currentRow = 0;
                            if (toTrinh.NguyenLieuId != null && !dictNguyenLieu.ContainsKey((long)toTrinh.NguyenLieuId))
                            {
                                dictNguyenLieu.Add((long)toTrinh.NguyenLieuId, startRow);
                                if (startRow > 7)
                                {
                                    var range = workSheet.Range["A" + (startRow - 2), "A" + (startRow - 1)];
                                    range.EntireRow.Copy();
                                    var row = (Range)workSheet.Rows[startRow];
                                    row.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, range);
                                }
                                currentRow = startRow;
                                workSheet.Cells[currentRow, 1] = dictNguyenLieu.Count;
                                var nguyenLieu = toTrinh.NguyenLieu;
                                if (nguyenLieu != null)
                                {
                                    workSheet.Cells[currentRow, 2] = nguyenLieu.Ten;
                                }

                                startRow += 2;
                            }
                            else
                            {
                                if (toTrinh.NguyenLieuId != null) currentRow = dictNguyenLieu[(long)toTrinh.NguyenLieuId];
                            }

                            workSheet.Cells[currentRow, startColumn] = chiTietToTrinh.NhuCau;
                            workSheet.Cells[currentRow + 1, startColumn] = chiTietToTrinh.ThucTe;

                            workSheet.Cells[currentRow, startColumn + 1] = toTrinh.BoSung;
                            workSheet.Cells[currentRow, startColumn + 3] = toTrinh.ThuHoi;
                            workSheet.Cells[currentRow, startColumn + 4] = toTrinh.TonToTrinh;
                            workSheet.Cells[currentRow, startColumn + 5] = toTrinh.TonTheKho;
                            workSheet.Cells[currentRow, startColumn + 6] = toTrinh.TonThucTe;
                            workSheet.Cells[currentRow, startColumn + 8] = toTrinh.DuKien;
                        }
                        startColumn++;
                    }
                }

                var currentDate = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
                workSheet.Cells[startRow + 1, startColumn] = string.Format("Long An. Ngày {0} Tháng {1} Năm {2}", currentDate.Day, currentDate.Month, currentDate.Year);
                workSheet.Cells[startRow + 4, startColumn] = Authorization.LoginUser.TenNguoiDung;
            });
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (_currentToTrinh != null)
            {
                using (var transaction = new TransactionScope())
                {
                    var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_currentToTrinh.TrangThai);
                    var ngayDuyet = TimeHelper.Current();
                    // Lock item
                    if (trangThai <= Define.TrangThai.MOI)
                    {
                        _currentToTrinh.NgayLap = ngayDuyet;
                        _currentToTrinh.NguoiLapId = Authorization.LoginUser.Id;
                        _currentToTrinh.TrangThai = Define.TrangThai.DUYET.ToString();
                    }

                    // Verify
                    if (trangThai == Define.TrangThai.DUYET)
                    {
                        _currentToTrinh.SoPhieu = SF.Get<ToTrinhViewModel>().GenerateSoPhieu();
                        _currentToTrinh.TrangThai = Define.TrangThai.DUYET_PVT.ToString();
                        _currentToTrinh.NgayDuyet = ngayDuyet;
                        _currentToTrinh.NguoiDuyetId = Authorization.LoginUser.Id;
                    }

                    SF.Get<ToTrinhViewModel>().Save(_currentToTrinh);
                    transaction.Complete();
                }
                MessageBox.Show("Duyệt thành công!");
                ObserverControl.PulishAction(Define.ActionType.SAVE);
                var parentForm = this.ParentForm;
                if (parentForm != null) parentForm.Close();
            }
        }

        public override void btnCancel_Click(object sender, EventArgs e)
        {
            if (_currentToTrinh != null)
            {
                ShowCustomForm(new Form.NhatKyThayDoi(Define.ModelType.TO_TRINH.ToString(), _currentToTrinh.Id, () =>
                {
                    SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.TO_TRINH, _currentToTrinh.Id);
                    _currentToTrinh.TrangThai = Define.TrangThai.HUY.ToString();
                    _currentToTrinh.NgayDuyet = TimeHelper.Current();
                    _currentToTrinh.NguoiDuyetId = Authorization.LoginUser.Id;
                    InitAuthorize();
                }), "Nhật ký thay đổi");
            }
        }
    }
}
