
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.NhapKho
{
    public partial class ucNhapKho : BaseUserControl
    {
        private BindingList<ChiTietNhapKho> ChiTietNhapKhoList = new BindingList<ChiTietNhapKho>();
        private PhieuNhapKho _currentData;

        public ucNhapKho(PhieuNhapKho data = null)
        {
            InitializeComponent();
            Init(data);

            SetComboboxDataSource(PhieuNhapKho_Kho, Define.KhoDic);
            SetComboboxDataSource(PhieuNhapKho_LoaiPhieu, Define.LoaiNhapDict);

            var lstChiLenh = SF.Get<ChiLenhViewModel>().GetList(Define.TrangThai.DONE);
            SetComboboxDataSource(PhieuNhapKho_ChiLenhId, lstChiLenh, "SoPhieu");

            var lstDanhGia = SF.Get<DanhGiaViewModel>().GetList();
            SetComboboxDataSource(PhieuNhapKho_DanhGiaId, lstDanhGia, "SoPhieu");

            if (data != null)
            {
                SF.Get<ChiTietNhapKhoViewModel>().GetDataSource(data.Id, ref ChiTietNhapKhoList);
                _currentData = data;
                btnExport.Visible = true;
            }

            gridNguyenLieu.DataSource = ChiTietNhapKhoList;

            SetRepositoryItem(NguyenLieuLookUp, SF.Get<NguyenLieuViewModel>().GetList(), "Ten");

            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;

            DanhGiaChange();
            ChiLenhChange();
            LoaiPhieuChange();
            InitAuthorize();
        }

        private void InitAuthorize()
        {
            btnCancel.Enabled = false;
            btnDuyet.Enabled = true;
            btnDuyet.Visible = false;
            btnExport.Visible = false;
            btnSave.Enabled = true;
            btnChiTiet.Enabled = true;

            if (_currentData != null)
            {
                lblSoPhieu.Text = string.Format("Số Phiếu: {0}", _currentData.SoPhieu);
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_currentData.TrangThai);

                if (trangThai <= Define.TrangThai.HUY)
                {
                    if (Authorization.LoginUser.LoaiNguoiDung == Define.LoaiNguoiDung.TRUONG_PVT.ToString())
                    {
                        btnDuyet.Visible = true;
                    }
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
                    btnChiTiet.Enabled = false;
                }

                // Allow export after final verify
                if (trangThai == Define.TrangThai.DUYET_PVT)
                {
                    btnExport.Visible = true;
                    btnDuyet.Visible = true;
                    btnDuyet.Enabled = false;
                }

                var verifyAuthorize = Authorization.CheckAuthorization("PhieuNhapKho", Define.Authorization.VERIFY);
                btnDuyet.Visible &= verifyAuthorize;
            }
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            using (var transaction = new TransactionScope())
            {
                var saveData = CRUD.GetFormObject(FormControls, _currentData);
                if (!string.IsNullOrEmpty(saveData.SoPhieu))
                {
                    saveData.SoPhieu = SF.Get<PhieuNhapKhoViewModel>().GenerateSoPhieuDoiKho(saveData.SoPhieu, PrimitiveConvert.StringToEnum<Define.Kho>(saveData.Kho));
                }
                CRUD.DecorateSaveData(saveData);
                SF.Get<PhieuNhapKhoViewModel>().Save(saveData);

                // Save chi teit Nhap kho
                var currentItem = new List<long>();
                foreach (var chitiet in ChiTietNhapKhoList)
                {
                    chitiet.PhieuNhapKhoId = saveData.Id;
                    CRUD.DecorateSaveData(chitiet);
                    SF.Get<ChiTietNhapKhoViewModel>().Save(chitiet);
                    currentItem.Add(chitiet.Id);
                }

                // Clear data
                var listChiTietDelete = SF.Get<ChiTietNhapKhoViewModel>().GetList().Where(s => s.PhieuNhapKhoId == saveData.Id);
                foreach (var deleteItem in listChiTietDelete)
                {
                    if (!currentItem.Contains(deleteItem.Id))
                    {
                        SF.Get<ChiTietNhapKhoViewModel>().Delete(deleteItem.Id);
                    }
                }
                transaction.Complete();
            }

            return true;
        }

        public string ValidateInput()
        {

            return string.Empty;
        }

        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewNguyenLieu.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }

        private void NhapKho_DanhGiaId_SelectedIndexChanged(object sender, EventArgs e)
        {
            DanhGiaChange();
        }

        private void DanhGiaChange()
        {
            var selectedValue = PhieuNhapKho_DanhGiaId.SelectedValue;
            if (selectedValue != null)
            {
                var danhGiaInfo = SF.Get<DanhGiaViewModel>().GetDetail((long)selectedValue);
                lblSoDonHang.Text = string.Format("Số đơn đặt hàng: {0}", danhGiaInfo.DonDatHang.SoDH);
            }
            else
            {
                lblSoDonHang.Text = "";
            }
        }

        private void ChiLenhChange()
        {
            var selectedValue = PhieuNhapKho_ChiLenhId.SelectedValue;
            if (selectedValue != null)
            {
                var chilenhInfo = SF.Get<ChiLenhViewModel>().GetDetail((long)selectedValue);
                lblSoDonHang.Text = string.Format("Số đơn hàng: {0}", chilenhInfo.DonHang.OrderNo);
            }
            else
            {
                lblSoDonHang.Text = "";
            }
        }

        private void LoaiPhieuChange()
        {
            var selectedValue = PhieuNhapKho_LoaiPhieu.SelectedValue;
            if (selectedValue != null)
            {
                if (selectedValue.ToString() == Define.LoaiNhap.THU_HOI_CHI_LENH.ToString())
                {
                    lblChiLenhId.Visible = true;
                    PhieuNhapKho_ChiLenhId.Visible = true;

                    lblDanhGiaId.Visible = false;
                    PhieuNhapKho_DanhGiaId.Visible = false;

                }
                else
                {
                    lblChiLenhId.Visible = false;
                    PhieuNhapKho_ChiLenhId.Visible = false;

                    lblDanhGiaId.Visible = true;
                    PhieuNhapKho_DanhGiaId.Visible = true;
                }
            }
        }

        private void InitChiTietFromChiLenh()
        {
            var selectedValue = PhieuNhapKho_LoaiPhieu.SelectedValue;
            if (selectedValue != null && selectedValue.ToString() == Define.LoaiNhap.THU_HOI_CHI_LENH.ToString())
            {
                ThreadHelper.LoadForm(() =>
                {
                    var chiLenhId = PhieuNhapKho_ChiLenhId.SelectedValue;
                    if (chiLenhId != null)
                    {
                        var chilenh = SF.Get<ChiLenhViewModel>().GetDetail((long)chiLenhId);
                        if (chilenh != null)
                        {
                            ChiTietNhapKhoList.Clear();
                            foreach (var nguyenLieuChiLenh in chilenh.NguyenLieuChiLenhs.SelectMany(s=>s.ChiTietNguyenLieux))
                            {
                                var chiTietNhapKho = new ChiTietNhapKho();
                                chiTietNhapKho.NguyenLieuId = nguyenLieuChiLenh.NguyenLieuChiLenhId;
                                chiTietNhapKho.SoLuong = nguyenLieuChiLenh.NguyenLieuChiLenh.DinhMucThuc;
                                ChiTietNhapKhoList.Add(chiTietNhapKho);
                                gridViewNguyenLieu.RefreshData();
                            }
                        }
                    }
                });
            }
        }

        private void InitChiTietFromDonDatHang()
        {
            var selectedValue = PhieuNhapKho_LoaiPhieu.SelectedValue;
            if (selectedValue != null && selectedValue.ToString() == Define.LoaiNhap.DON_DAT_HANG.ToString())
            {
                ThreadHelper.LoadForm(() =>
                {
                    var phieuDanhGiaId = PhieuNhapKho_DanhGiaId.SelectedValue;
                    if (phieuDanhGiaId != null)
                    {
                        var danhGia = SF.Get<DanhGiaViewModel>().GetDetail((long)phieuDanhGiaId);
                        if (danhGia != null)
                        {
                            ChiTietNhapKhoList.Clear();
                            foreach (var nguyenLieuDatHang in danhGia.DonDatHang.ChiTietDonDatHangs)
                            {
                                var chiTietNhapKho = new ChiTietNhapKho();
                                chiTietNhapKho.NguyenLieuId = nguyenLieuDatHang.NguyenLieuId;
                                chiTietNhapKho.SoLuong = nguyenLieuDatHang.SoLuong;
                                ChiTietNhapKhoList.Add(chiTietNhapKho);
                                gridViewNguyenLieu.RefreshData();
                            }
                        }
                    }
                });
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export(Define.TEMPLATE_NHAP_KHO, (workBook, workSheet) =>
            {
                var currentDate = _currentData.NgayNhap;
                workSheet.Cells[3, "I"] = string.Format("Ngày {0} Tháng {1} Năm {2}", currentDate.Day, currentDate.Month, currentDate.Year);
                var startRow = 6;
                foreach (var chiTiet in _currentData.ChiTietNhapKhoes)
                {
                    if (startRow > 15)
                    {
                        var range = workSheet.Range["A" + (startRow - 1), "B" + (startRow - 1)];
                        range.EntireRow.Copy();
                        var row = (Range)workSheet.Rows[startRow];
                        row.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, range);
                    }
                    if (_currentData.DanhGia == null || _currentData.DanhGia.DonDatHang == null) continue;
                    var donDatHang = _currentData.DanhGia.DonDatHang;
                    workSheet.Cells[startRow, "A"] = donDatHang.NhaCungCap.TenCongTy;
                    workSheet.Cells[startRow, "B"] = donDatHang.SoDH;
                    var nguyenLieu = chiTiet.NguyenLieu;
                    if (nguyenLieu != null)
                    {
                        workSheet.Cells[startRow, "C"] = nguyenLieu.MaNguyenLieu;
                        workSheet.Cells[startRow, "D"] = nguyenLieu.Ten;
                        if (nguyenLieu.Mau != null) workSheet.Cells[startRow, "F"] = nguyenLieu.Mau.Ten;
                        workSheet.Cells[startRow, "G"] = nguyenLieu.QuyCach;
                        workSheet.Cells[startRow, "H"] = chiTiet.SoLuong;
                        if (nguyenLieu.DVT != null) workSheet.Cells[startRow, "I"] = nguyenLieu.DVT.Ten;
                        workSheet.Cells[startRow, "J"] = nguyenLieu.GhiChu;
                    }
                    startRow++;
                }
            });
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (_currentData != null)
            {
                using (var transaction = new TransactionScope())
                {
                    var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_currentData.TrangThai);
                    var ngayDuyet = TimeHelper.Current();
                    var kho = PrimitiveConvert.StringToEnum<Define.Kho>(_currentData.Kho);

                    // Lock item
                    if (trangThai <= Define.TrangThai.HUY)
                    {
                        _currentData.NgayLap = ngayDuyet;
                        _currentData.NguoiLapId = Authorization.LoginUser.Id;
                        _currentData.TrangThai = Define.TrangThai.DUYET.ToString();
                    }

                    // Verify
                    if (trangThai == Define.TrangThai.DUYET)
                    {
                        _currentData.SoPhieu = SF.Get<PhieuNhapKhoViewModel>().GenerateSoPhieu(kho);
                        _currentData.TrangThai = Define.TrangThai.DUYET_PVT.ToString();
                        _currentData.NgayDuyet = ngayDuyet;
                        _currentData.NguoiDuyetId = Authorization.LoginUser.Id;
                        SF.Get<NguyenLieuViewModel>().UpdateNguyenLieuNhapKho(_currentData);
                    }

                    SF.Get<PhieuNhapKhoViewModel>().Save(_currentData);
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
            if (_currentData != null)
            {
                using (var transaction = new TransactionScope())
                {
                    _currentData.TrangThai = Define.TrangThai.HUY.ToString();
                    _currentData.NgayDuyet = TimeHelper.Current();
                    _currentData.NguoiDuyetId = Authorization.LoginUser.Id;
                    SF.Get<PhieuNhapKhoViewModel>().Save(_currentData);
                    SF.Get<NguyenLieuViewModel>().UpdateNguyenLieuNhapKho(_currentData, true);
                    transaction.Complete();
                }
                InitAuthorize();
            }
        }

        private void PhieuNhapKho_LoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiPhieuChange();
        }

        private void PhieuNhapKho_ChiLenhId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChiLenhChange();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (ChiTietNhapKhoList != null && ChiTietNhapKhoList.Count > 0)
            {
                var confirmDialog = MessageBox.Show("Khởi tạo danh sách nhập kho từ Chỉ Lệnh/Đơn Đặt Hàng. Lưu ý, những dữ liệu hiện tại sẽ bị thay thế.",
                    "Khởi tạo danh sách", MessageBoxButtons.YesNo);
                if (confirmDialog == DialogResult.Yes)
                {
                    InitChiTiet();
                }
            }
            else
            {
                InitChiTiet();
            }
           
        }

        private void InitChiTiet()
        {
            var loaiPhieu = PhieuNhapKho_LoaiPhieu.SelectedValue;
            if (loaiPhieu != null)
            {
                if (loaiPhieu.ToString() == Define.LoaiNhap.THU_HOI_CHI_LENH.ToString())
                {
                    InitChiTietFromChiLenh();
                }
                else
                {
                    InitChiTietFromDonDatHang();
                }
                MessageBox.Show("Khởi tạo thành công, chuyển qua tab Chi Tiết để chỉnh sửa danh sách nhập kho!");
            }
        }
    }


}
