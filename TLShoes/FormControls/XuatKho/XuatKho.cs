﻿
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

namespace TLShoes.FormControls.XuatKho
{
    public partial class ucXuatKho : BaseUserControl
    {
        private BindingList<ChiTietXuatKho> ChiTietXuatKhoList = new BindingList<ChiTietXuatKho>();
        private PhieuXuatKho _currentData;

        public ucXuatKho(PhieuXuatKho data = null)
        {
            InitializeComponent();

            var lstDonhang = new List<TLShoes.DonHang>();
            if (data != null && data.TrangThai == Define.TrangThai.DUYET_PVT.ToString())
            {
                lstDonhang.Add(data.DonHang);
            }
            else
            {
                lstDonhang = SF.Get<DonHangViewModel>().GetList(Define.TrangThai.DUYET);
            }
            SetComboboxDataSource(PhieuXuatKho_DonHangId, lstDonhang, "MaHang");

            SetComboboxDataSource(PhieuXuatKho_Kho, Define.KhoDic);

            SetComboboxDataSource(PhieuXuatKho_LoaiXuat, Define.LoaiXuatDic);

            SetComboboxDataSource(PhieuXuatKho_BoPhan, Define.PhanXuongDict);

            Init(data);

            if (data != null)
            {
                SF.Get<ChiTietXuatKhoViewModel>().GetDataSource(data.Id, ref ChiTietXuatKhoList);
                DonHangChange(data.DonHangId.GetValueOrDefault());
                _currentData = data;
                btnExport.Visible = true;
                gridNhatKy.DataSource = data.ChiTietXuatKhoes.SelectMany(s => s.NhatKyXuatKhoes).ToList();
            }
            gridNguyenLieu.DataSource = ChiTietXuatKhoList;

            SetRepositoryItem(NguyenLieuLookUp, SF.Get<NguyenLieuViewModel>().GetList(), "Ten");

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
            btnXuatLe.Visible = false;
            lblMessage.Text = "";

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
                    btnXuatLe.Visible = true;
                    btnDuyet.Visible = true;
                    btnDuyet.Enabled = false;
                }

                if (_currentData.DonHang.TrangThai == Define.TrangThai.DONE.ToString())
                {
                    btnExport.Visible = true;
                    btnDuyet.Visible = true;
                    btnDuyet.Enabled = false;
                    btnCancel.Enabled = false;
                    btnXuatLe.Enabled = false;
                    lblMessage.Text = Define.MESSAGE_NOT_AVAILABLE_DON_HANG_DONE;
                }

                var verifyAuthorize = Authorization.CheckAuthorization("PhieuXuatKho", Define.Authorization.VERIFY);
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

            // Validate Xuat Kho
            var donHangId = PhieuXuatKho_DonHangId.SelectedValue;
            if (donHangId != null)
            {
                var validateMessage = "";
                var chiLenhInfo = SF.Get<DonHangViewModel>().GetDetail((long)donHangId).ChiLenhs.FirstOrDefault();
                if (chiLenhInfo != null)
                {
                    foreach (var chitiet in ChiTietXuatKhoList)
                    {
                        bool isOk = chiLenhInfo.NguyenLieuChiLenhs.Any(s => s.DinhMucThuc >= chitiet.SoLuong && s.ChiTietNguyenLieux.Any(a => a.NguyenLieu.Id == chitiet.NguyenLieuId));

                        if (!isOk && chitiet.NguyenLieuId != null)
                        {
                            var nguyenLieu = SF.Get<NguyenLieuViewModel>().GetDetail((long)chitiet.NguyenLieuId);
                            if (nguyenLieu != null)
                            {
                                validateMessage += string.Format("{0} không phù hợp với chỉ lệnh \r\n", nguyenLieu.Ten);
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(validateMessage))
                {
                    var confirmResult = MessageBox.Show(validateMessage, "Bạn có muốn chắc tiếp tục xuất kho", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.No)
                        return false;
                }
            }

            var saveData = CRUD.GetFormObject<PhieuXuatKho>(FormControls);

            using (var transaction = new TransactionScope())
            {
                SF.Get<PhieuXuatKhoViewModel>().Save(saveData);

                // Save chi tiet xuat kho
                var currentItem = new List<long>();
                foreach (var chitiet in ChiTietXuatKhoList)
                {
                    chitiet.PhieuXuatKhoId = saveData.Id;
                    CRUD.DecorateSaveData(chitiet);
                    SF.Get<ChiTietXuatKhoViewModel>().Save(chitiet);
                    currentItem.Add(chitiet.Id);
                }

                // Clear data
                var listChiTietDelete = SF.Get<ChiTietXuatKhoViewModel>().GetList().Where(s => s.PhieuXuatKhoId == saveData.Id);
                foreach (var deleteItem in listChiTietDelete)
                {
                    if (!currentItem.Contains(deleteItem.Id))
                    {
                        SF.Get<ChiTietXuatKhoViewModel>().Delete(deleteItem.Id);
                    }
                }

                transaction.Complete();
            }

            return true;
        }

        public string ValidateInput()
        {
            if (PhieuXuatKho_DonHangId.SelectedValue == null)
            {
                return "Đơn Hàng";
            }
            return string.Empty;
        }

        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewNguyenLieu.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }

        private void PhieuXuatKho_DonHangId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var donHangobj = PhieuXuatKho_DonHangId.SelectedValue;
            if (donHangobj != null)
            {
                DonHangChange((long)donHangobj);
            }
        }

        private void DonHangChange(long donHangId)
        {
            var donHangInfo = SF.Get<DonHangViewModel>().GetDetail(donHangId);
            SoDH.Text = donHangInfo.OrderNo;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export(Define.TEMPLATE_XUAT_KHO, (workBook, workSheet) =>
            {
                workSheet.Cells[3, "B"] = _currentData.BoPhan;
                var chiLenhInfo = SF.Get<DonHangViewModel>().GetDetail((long)_currentData.DonHangId).ChiLenhs.FirstOrDefault();
                if (chiLenhInfo != null)
                {
                    workSheet.Cells[3, "F"] = chiLenhInfo.SoPhieu;
                }
                var currentDate = _currentData.NgayXuat;
                workSheet.Cells[3, "H"] = string.Format("Ngày {0} Tháng {1} Năm {2}", currentDate.Day, currentDate.Month, currentDate.Year);
                var startRow = 6;
                foreach (var chiTietXuatKhoe in _currentData.ChiTietXuatKhoes)
                {
                    if (startRow > 15)
                    {
                        var range = workSheet.Range["A" + (startRow - 1), "B" + (startRow - 1)];
                        range.EntireRow.Copy();
                        var row = (Range)workSheet.Rows[startRow];
                        row.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, range);
                    }

                    workSheet.Cells[startRow, "A"] = _currentData.DonHang.OrderNo;
                    workSheet.Cells[startRow, "B"] = _currentData.DonHang.MaHang;

                    var nguyenLieu = chiTietXuatKhoe.NguyenLieu;
                    if (nguyenLieu != null)
                    {
                        workSheet.Cells[startRow, "C"] = nguyenLieu.Ten;
                        if (nguyenLieu.Mau != null) workSheet.Cells[startRow, "E"] = nguyenLieu.Mau.Ten;
                        workSheet.Cells[startRow, "F"] = nguyenLieu.QuyCach;
                        workSheet.Cells[startRow, "G"] = chiTietXuatKhoe.SoLuong;
                        if (nguyenLieu.DVT != null) workSheet.Cells[startRow, "H"] = nguyenLieu.DVT.Ten;
                        workSheet.Cells[startRow, "I"] = nguyenLieu.GhiChu;
                    }
                    startRow++;
                }
            });
        }

        private void btnXuatLe_Click(object sender, EventArgs e)
        {
            if (_currentData != null)
            {
                ShowCustomForm(new ucNhatKyXuatKho(_currentData, () => gridNhatKy.RefreshDataSource()), "Xuất Kho.");
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
                        _currentData.SoPhieu = SF.Get<PhieuXuatKhoViewModel>().GenerateSoPhieu();
                        _currentData.TrangThai = Define.TrangThai.DUYET_PVT.ToString();
                        _currentData.NgayDuyet = ngayDuyet;
                        _currentData.NguoiDuyetId = Authorization.LoginUser.Id;
                        SF.Get<NguyenLieuViewModel>().UpdateNguyenLieuXuatKho(_currentData);
                    }

                    SF.Get<PhieuXuatKhoViewModel>().Save(_currentData);
                    transaction.Complete();
                }
                InitAuthorize();
            }
        }

        public override void btnCancel_Click(object sender, EventArgs e)
        {
            if (_currentData != null && _currentData.TrangThai == Define.TrangThai.DUYET.ToString())
            {
                using (var transaction = new TransactionScope())
                {
                    _currentData.TrangThai = Define.TrangThai.HUY.ToString();
                    _currentData.NgayDuyet = TimeHelper.Current();
                    _currentData.NguoiDuyetId = Authorization.LoginUser.Id;
                    SF.Get<PhieuXuatKhoViewModel>().Save(_currentData);
                    SF.Get<NguyenLieuViewModel>().UpdateNguyenLieuXuatKho(_currentData, true);
                    transaction.Complete();
                }
                InitAuthorize();
            }
        }
    }


}
