using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.Mvvm.Native;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinh : BaseUserControl
    {
        private TongHopToTrinh _currentTongHopToTrinh;
        private TLShoes.ToTrinh _currentToTrinh;

        public ucToTrinh(long? tongHopTroTrinhId)
        {
            InitializeComponent();

            _currentTongHopToTrinh = DbContext.TongHopToTrinhs.Find(tongHopTroTrinhId);

            var lstNguyenLieu = SF.Get<NguyenLieuViewModel>().GetListNguyenLieuToTrinh(DbContext);


            Init(_currentTongHopToTrinh);
            if (_currentTongHopToTrinh == null)
            {
                _currentTongHopToTrinh = new TongHopToTrinh();
                _currentTongHopToTrinh.TrangThai = Define.TrangThai.MOI.ToString();
            }
            else
            {
                NgayLap.Text = _currentTongHopToTrinh.NgayLap.ToString(CultureInfo.InvariantCulture);
                NgayDuyet.Text = _currentTongHopToTrinh.NgayDuyet.ToString(CultureInfo.InvariantCulture);
                if (_currentTongHopToTrinh.NguoiLap != null)
                {
                    NguoiLap.Text = _currentTongHopToTrinh.NguoiLap.TenNguoiDung;
                }
                if (_currentTongHopToTrinh.NguoiDuyet != null)
                {
                    NguoiDuyet.Text = _currentTongHopToTrinh.NguoiDuyet.TenNguoiDung;
                }

                SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.TO_TRINH, _currentTongHopToTrinh.Id);
                
                // Get nguyen lieu cua to trinh hien tai de hien thi tren Combobox
                var nguyenLieuToTrinh = _currentTongHopToTrinh.ToTrinhs
                                            .SelectMany(s => s.ChiTietToTrinhs)
                                            .Select(s => s.ChiTietNguyenLieu.NguyenLieu).ToList();
                lstNguyenLieu.AddRange(nguyenLieuToTrinh);
                lstNguyenLieu = lstNguyenLieu.Distinct().ToList();
            }

            _currentTongHopToTrinh.ToTrinhs = new BindingList<TLShoes.ToTrinh>(_currentTongHopToTrinh.ToTrinhs.ToList());

            gridToTrinh.DataSource = _currentTongHopToTrinh.ToTrinhs;
            SetComboboxDataSource(ToTrinh_NguyenLieuId, lstNguyenLieu, "Ten");

            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;

            InitAuthorize();
        }

        private void InitAuthorize()
        {
            btnCancel.Enabled = false;
            btnDuyet.Enabled = true;
            btnDuyet.Visible = false;
            btnExport.Visible = false;
            btnSave.Enabled = true;

            if (_currentTongHopToTrinh != null)
            {
                lblSoPhieu.Text = string.Format("Số Tờ Trình: {0}", _currentTongHopToTrinh.SoPhieu);
                lblTrangThai.Text = string.Format("Trạng Thái: {0}", _currentTongHopToTrinh.TrangThaiDisplay);
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_currentTongHopToTrinh.TrangThai);

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
                CRUD.DecorateSaveData(DbContext);

                if (string.IsNullOrEmpty(_currentTongHopToTrinh.SoPhieu))
                {
                    _currentTongHopToTrinh.SoPhieu = SF.Get<ToTrinhViewModel>().GenerateSoPhieu(DbContext);
                }
                DbContext.TongHopToTrinhs.AddOrUpdate(_currentTongHopToTrinh);

                // Delete unselected to trinh
                var deleteChiTietToTrinh = new List<ChiTietToTrinh>();
                foreach (var toTrinh in _currentTongHopToTrinh.ToTrinhs)
                {
                    deleteChiTietToTrinh.AddRange(toTrinh.ChiTietToTrinhs.Where(s => !s.IsChon));
                }

                DbContext.ChiTietToTrinhs.RemoveRange(deleteChiTietToTrinh);

                DbContext.SaveChanges();
                transaction.Complete();
            }
            return true;
        }

        private string ValidateInput()
        {
            if (_currentTongHopToTrinh != null)
            {
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_currentTongHopToTrinh.TrangThai);
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
                    var doneStatus = Define.TrangThai.DONE.ToString();
                    var duyetChiLenhStatus = Define.TrangThai.DUYET_PKT.ToString();
                    var duyetKhoStatus = Define.TrangThai.DUYET_PVT.ToString();

                    // Check to trinh trong danh sach hien tai 
                    _currentToTrinh = _currentTongHopToTrinh.ToTrinhs.FirstOrDefault(s => s.NguyenLieuId == nguyenLieuId);
                    // Check tao moi hoac update to trinh
                    if (_currentToTrinh == null || _currentToTrinh.NguyenLieuId != nguyenLieuId)
                    {
                        _currentToTrinh = new TLShoes.ToTrinh();
                        _currentToTrinh.ChiTietToTrinhs = new BindingList<ChiTietToTrinh>();
                        _currentToTrinh.NguyenLieuId = nguyenLieuId;
                        _currentToTrinh.NguyenLieu = DbContext.NguyenLieux.Find(nguyenLieuId);
                        BindingData(_currentToTrinh);

                        // Not binding data
                        ToTrinh_NguyenLieuId.DataBindings.Clear();
                    }

                    // Get danh sach cac don hang chua hoan thanh
                    var unDoneDonHang = DbContext.DonHangs
                        .Where(s => s.TrangThai != doneStatus);

                    // Get danh sach nguyen lieu cua cac chi lenh da duoc duyet
                    // Cac nguyen lieu chua duoc su dung trong cac to trinh
                    var chitietNguyenLieuList = unDoneDonHang
                        .SelectMany(s => s.ChiLenhs).Where(s => s.TrangThai == duyetChiLenhStatus)
                        .SelectMany(s => s.NguyenLieuChiLenhs)
                        .SelectMany(s => s.ChiTietNguyenLieux).Where(s => s.ChiTietNguyenLieuId == nguyenLieuId && !s.ChiTietToTrinhs.Any());

                    // Danh sach nguyen lieu theo cac phieu xuat kho da duoc duyet
                    var xuatKhoList = unDoneDonHang.SelectMany(s => s.PhieuXuatKhoes)
                                        .Where(s => s.TrangThai == duyetKhoStatus)
                                        .SelectMany(s => s.ChiTietXuatKhoes).Where(s => s.NguyenLieuId == nguyenLieuId);
                    var tongXuatKho = xuatKhoList.ToList().Sum(s => s.SoLuong);

                    // Bổ sung là tổng xuất kho ngoài chỉ lệnh
                    var xuatKhoBoSung = xuatKhoList.Where(s => s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.NGOAI_CHI_LENH.ToString()).ToList().Sum(s => s.SoLuong);
                    _currentToTrinh.BoSung = xuatKhoBoSung;

                    // Danh sach nhap kho theo don hang da duoc duyet
                    var nhapKhoList = unDoneDonHang.SelectMany(s => s.ChiLenhs)
                                        .Where(s => s.TrangThai == duyetChiLenhStatus)
                                        .SelectMany(s => s.PhieuNhapKhoes).Where(s => s.TrangThai == duyetKhoStatus)
                                        .SelectMany(s => s.ChiTietNhapKhoes).Where(s => s.NguyenLieuId == nguyenLieuId);
                    var tongNhapKho = nhapKhoList.ToList().Sum(s => s.SoLuong);

                    var tonTheKho = tongNhapKho - tongXuatKho;
                    _currentToTrinh.TonTheKho = tonTheKho;

                    // Tính toán nhu cầu thực tế và xuất kho theo chỉ lệnh của vật tư
                    foreach (var chitietNguyenLieu in chitietNguyenLieuList)
                    {
                        var chiTietNguyenLieuId = chitietNguyenLieu.Id;
                        var chitiet = _currentToTrinh.ChiTietToTrinhs.FirstOrDefault(s => s.ChiTietNguyenLieuId == chiTietNguyenLieuId);
                        if (chitiet == null)
                        {
                            chitiet = new ChiTietToTrinh();
                            _currentToTrinh.ChiTietToTrinhs.Add(chitiet);
                        }
                        chitiet.ChiTietNguyenLieu = chitietNguyenLieu;
                        chitiet.ChiTietNguyenLieuId = chitietNguyenLieu.Id;
                        chitiet.NhuCau = chitietNguyenLieu.NguyenLieuChiLenh.DinhMucThuc;
                        var donHangId = chitietNguyenLieu.NguyenLieuChiLenh.ChiLenh.DonHangId;
                        chitiet.ThucTe = xuatKhoList.Where(s => s.PhieuXuatKho.DonHangId == donHangId
                                                             && s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.TRONG_CHI_LENH.ToString()).ToList()
                                                    .Sum(s => s.SoLuong);

                        // Neu la to trinh moi thi defaul la chon het
                        chitiet.IsChon = _currentToTrinh.Id == 0;
                    }

                    gridChiTietToTrinh.DataSource = new BindingList<ChiTietToTrinh>(_currentToTrinh.ChiTietToTrinhs.ToList());
                }
            }, ParentForm);
        }

        private void btnUpdateToTrinh_Click(object sender, EventArgs e)
        {
            if (_currentToTrinh == null)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cho tờ trình!");
                return;
            }

            if (!_currentTongHopToTrinh.ToTrinhs.Contains(_currentToTrinh))
            {
                _currentTongHopToTrinh.ToTrinhs.Add(_currentToTrinh);                
            }
        }

        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            var data = gridViewToTrinh.GetRow(gridViewToTrinh.FocusedRowHandle) as TLShoes.ToTrinh;
            if (data != null)
            {
                _currentTongHopToTrinh.ToTrinhs.Remove(data);
                DbContext.ToTrinhs.Remove(data);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export(Define.TEMPLATE_TO_TRINH, (workBook, workSheet) =>
            {
                // Get loai to trinh
                if (_currentTongHopToTrinh == null) return;

                var groupByNguyenLieu = _currentTongHopToTrinh.ToTrinhs.GroupBy(s => s.NguyenLieu.LoaiNguyenLieu).ToList();
                var loaiToTrinh = "TỔNG HỢP";
                if (groupByNguyenLieu.Count == 1)
                {
                    loaiToTrinh = groupByNguyenLieu.First().Key.Ten;
                }
                workSheet.Cells[2, "A"] = string.Format("TỜ TRÌNH {0}", loaiToTrinh.ToUpper());
                

                // Group by don hang 
                var groupedToTrinh = _currentTongHopToTrinh.ToTrinhs.SelectMany(s => s.ChiTietToTrinhs).GroupBy(s => s.ChiTietNguyenLieu.NguyenLieuChiLenh.ChiLenh.DonHangId).ToList();
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
                workSheet.Cells[startRow + 7, startColumn] = Authorization.LoginUser.TenNguoiDung;

                if (!string.IsNullOrEmpty(_currentTongHopToTrinh.GhiChu))
                {
                    workSheet.Cells[startRow + 2, 2] = _currentTongHopToTrinh.GhiChu;   
                }

            });
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (_currentTongHopToTrinh != null)
            {
                using (var transaction = new TransactionScope())
                {
                    var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_currentTongHopToTrinh.TrangThai);
                    var ngayDuyet = TimeHelper.Current();
                    // Lock item
                    if (trangThai <= Define.TrangThai.MOI)
                    {
                        _currentTongHopToTrinh.NgayLap = ngayDuyet;
                        _currentTongHopToTrinh.NguoiLapId = Authorization.LoginUser.Id;
                        _currentTongHopToTrinh.TrangThai = Define.TrangThai.DUYET.ToString();
                    }

                    // Verify
                    if (trangThai == Define.TrangThai.DUYET)
                    {
                        _currentTongHopToTrinh.SoPhieu = SF.Get<ToTrinhViewModel>().GenerateSoPhieu(DbContext);
                        _currentTongHopToTrinh.TrangThai = Define.TrangThai.DUYET_PVT.ToString();
                        _currentTongHopToTrinh.NgayDuyet = ngayDuyet;
                        _currentTongHopToTrinh.NguoiDuyetId = Authorization.LoginUser.Id;
                    }

                    SF.Get<ToTrinhViewModel>().Save(_currentTongHopToTrinh);
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
            if (_currentTongHopToTrinh != null)
            {
                ShowCustomForm(new Form.NhatKyThayDoi(Define.ModelType.TO_TRINH.ToString(), _currentTongHopToTrinh.Id, () =>
                {
                    SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.TO_TRINH, _currentTongHopToTrinh.Id);
                    _currentTongHopToTrinh.TrangThai = Define.TrangThai.HUY.ToString();
                    _currentTongHopToTrinh.NgayDuyet = TimeHelper.Current();
                    _currentTongHopToTrinh.NguoiDuyetId = Authorization.LoginUser.Id;
                    InitAuthorize();
                }), "Nhật ký thay đổi");
            }
        }

        private void gridViewToTrinh_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var data = gridViewToTrinh.GetRow(gridViewToTrinh.FocusedRowHandle) as TLShoes.ToTrinh;
            if (data != null)
            {
                if (_currentToTrinh != null && _currentToTrinh.NguyenLieuId == data.NguyenLieuId) return;

                _currentToTrinh = data;
                gridChiTietToTrinh.DataSource = _currentToTrinh.ChiTietToTrinhs;
                BindingData(_currentToTrinh);

                // Not bind 
                ToTrinh_NguyenLieuId.DataBindings.Clear();
            }
        }
    }
}
