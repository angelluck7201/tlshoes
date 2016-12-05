
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

            PhieuXuatKho_DonHangId.DisplayMember = "MaHang";
            PhieuXuatKho_DonHangId.ValueMember = "Id";
            PhieuXuatKho_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            PhieuXuatKho_Kho.DisplayMember = "Value";
            PhieuXuatKho_Kho.ValueMember = "Key";
            PhieuXuatKho_Kho.DataSource = new BindingSource(Define.KhoDic, null);

            PhieuXuatKho_LoaiXuat.DisplayMember = "Value";
            PhieuXuatKho_LoaiXuat.ValueMember = "Key";
            PhieuXuatKho_LoaiXuat.DataSource = new BindingSource(Define.LoaiXuatDic, null);

            PhieuXuatKho_BoPhan.DisplayMember = "Value";
            PhieuXuatKho_BoPhan.ValueMember = "Key";
            PhieuXuatKho_BoPhan.DataSource = new BindingSource(Define.PhanXuongDict, null);

            Init(data);

            if (data != null)
            {
                SF.Get<ChiTietXuatKhoViewModel>().GetDataSource(data.Id, ref ChiTietXuatKhoList);
                PhieuXuatKho_Kho.SelectedValue = PrimitiveConvert.StringToEnum<Define.Kho>(data.Kho);
                PhieuXuatKho_LoaiXuat.SelectedValue = PrimitiveConvert.StringToEnum<Define.LoaiXuat>(data.LoaiXuat);
                PhieuXuatKho_BoPhan.SelectedValue = PrimitiveConvert.StringToEnum<Define.PhanXuong>(data.BoPhan);
                DonHangChange((long)data.DonHangId);
                _currentData = data;
                btnExport.Visible = true;
                gridNhatKy.DataSource =data.ChiTietXuatKhoes.SelectMany(s => s.NhatKyXuatKhoes).ToList();

            }
            gridNguyenLieu.DataSource = ChiTietXuatKhoList;

            NguyenLieuLookUp.NullText = "";
            NguyenLieuLookUp.Properties.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuLookUp.PopulateColumns();
            NguyenLieuLookUp.ShowHeader = false;
            NguyenLieuLookUp.Columns["Id"].Visible = false;
            NguyenLieuLookUp.Properties.DisplayMember = "Ten";
            NguyenLieuLookUp.Properties.ValueMember = "Id";
            NguyenLieuLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

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

                // Save chi teit xuat kho
                var currentItem = new List<long>();
                foreach (var chitiet in ChiTietXuatKhoList)
                {
                    if (chitiet.IsUpdateKho == null || chitiet.IsUpdateKho == false)
                    {
                        var nguyenLieu = chitiet.NguyenLieu;
                        nguyenLieu.SoLuong -= chitiet.SoLuong;
                        SF.Get<NguyenLieuViewModel>().Save(nguyenLieu);
                    }
                    chitiet.PhieuXuatKhoId = saveData.Id;
                    chitiet.IsUpdateKho = true;
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
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = Define.EXPORT_EXTENSION;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ThreadHelper.LoadForm(() =>
                {
                    //Start Excel and get Application object.
                    var excel = new Application();

                    //Get a new workbook.
                    var workBook = excel.Workbooks.Open(Path.Combine(FileHelper.TemplatePath, Define.TEMPLATE_XUAT_KHO));
                    var workSheet = (_Worksheet)workBook.ActiveSheet;

                    try
                    {
                        workSheet.Cells[3, "B"] = _currentData.BoPhan;
                        var chiLenhInfo = SF.Get<DonHangViewModel>().GetDetail((long)_currentData.DonHangId).ChiLenhs.FirstOrDefault();
                        if (chiLenhInfo != null)
                        {
                            workSheet.Cells[3, "F"] = chiLenhInfo.SoPhieu;
                        }
                        var currentDate = TimeHelper.TimeStampToDateTime(_currentData.NgayXuat);
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
                                if (nguyenLieu.DanhMuc != null) workSheet.Cells[startRow, "H"] = nguyenLieu.DanhMuc.Ten;
                                workSheet.Cells[startRow, "I"] = nguyenLieu.GhiChu;
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
                    var ngayDuyet = TimeHelper.CurrentTimeStamp();
                    // Lock item
                    if (trangThai == Define.TrangThai.MOI)
                    {
                        _currentData.SoPhieu = SF.Get<PhieuXuatKhoViewModel>().GenerateSoPhieu();
                    }

                    if (trangThai <= Define.TrangThai.HUY)
                    {
                        _currentData.NgayLap = ngayDuyet;
                        _currentData.NguoiLapId = Authorization.LoginUser.Id;
                        _currentData.TrangThai = Define.TrangThai.DUYET.ToString();
                    }

                    // Verify
                    if (trangThai == Define.TrangThai.DUYET)
                    {
                        _currentData.TrangThai = Define.TrangThai.DUYET_PVT.ToString();
                        _currentData.NgayDuyet = ngayDuyet;
                        _currentData.NguoiDuyetId = Authorization.LoginUser.Id;
                    }

                    SF.Get<PhieuXuatKhoViewModel>().Save(_currentData);
                    transaction.Complete();
                }
                InitAuthorize();
            }
        }

        public override void btnCancel_Click(object sender, EventArgs e)
        {
            if (_currentData != null)
            {
                _currentData.TrangThai = Define.TrangThai.HUY.ToString();
                _currentData.NgayDuyet = TimeHelper.CurrentTimeStamp();
                _currentData.NguoiDuyetId = Authorization.LoginUser.Id;
                InitAuthorize();
            }
        }
    }


}
