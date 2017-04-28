
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

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
            InitAuthorize();
        }

        private void InitAuthorize()
        {
            btnCancel.Enabled = false;
            btnDuyet.Enabled = true;
            btnDuyet.Visible = false;
            btnExport.Visible = false;
            btnSave.Enabled = true;

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
                CRUD.DecorateSaveData(saveData, _currentData == null);
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
                lblSoDonHang.Text = string.Format("Số đơn hàng: {0}", danhGiaInfo.DonDatHang.SoDH);
            }
            else
            {
                lblSoDonHang.Text = "";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = Define.EXPORT_EXTENSION;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ThreadHelper.LoadForm(() =>
                {
                    //Start Excel and get Application object.
                    var excel = new Application();

                    //Get a new workbook.
                    var workBook = excel.Workbooks.Open(Path.Combine(FileHelper.TemplatePath, Define.TEMPLATE_NHAP_KHO));
                    var workSheet = (_Worksheet)workBook.ActiveSheet;

                    try
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

                        workBook.SaveAs(saveDialog.FileName);
                    }
                    finally
                    {
                        workBook.Close();
                    }

                });


                var confirmDialog = MessageBox.Show(Define.MESSAGE_EXPORT_SUCCESS_TEXT, Define.MESSAGE_EXPORT_SUCCESS_TITLE, MessageBoxButtons.YesNo);
                if (confirmDialog == DialogResult.Yes)
                {
                    Process.Start(saveDialog.FileName);
                }
                this.ParentForm.Close();
            }
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
                InitAuthorize();
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
    }


}
