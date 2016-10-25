
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

            PhieuNhapKho_Kho.DisplayMember = "Value";
            PhieuNhapKho_Kho.ValueMember = "Key";
            PhieuNhapKho_Kho.DataSource = new BindingSource(Define.KhoDic, null);

            PhieuNhapKho_DanhGiaId.DisplayMember = "SoPhieu";
            PhieuNhapKho_DanhGiaId.ValueMember = "Id";
            PhieuNhapKho_DanhGiaId.DataSource = new BindingSource(SF.Get<DanhGiaViewModel>().GetList(), null);


            if (data != null)
            {
                SF.Get<ChiTietNhapKhoViewModel>().GetDataSource(data.Id, ref ChiTietNhapKhoList);
                Define.Kho selectedKho;
                Enum.TryParse<Define.Kho>(data.Kho, out selectedKho);
                PhieuNhapKho_Kho.SelectedValue = selectedKho;
                _currentData = data;
                btnExport.Visible = true;
            }

            gridNguyenLieu.DataSource = ChiTietNhapKhoList;

            NguyenLieuLookUp.NullText = "";
            NguyenLieuLookUp.Properties.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuLookUp.PopulateColumns();
            NguyenLieuLookUp.ShowHeader = false;
            NguyenLieuLookUp.Columns["Id"].Visible = false;
            NguyenLieuLookUp.Properties.DisplayMember = "Ten";
            NguyenLieuLookUp.Properties.ValueMember = "Id";
            NguyenLieuLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;

            DanhGiaChange();
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var saveData = CRUD.GetFormObject<PhieuNhapKho>(FormControls);
            using (var transaction = new TransactionScope())
            {
                SF.Get<PhieuNhapKhoViewModel>().Save(saveData);

                // Save chi teit Nhap kho
                var currentItem = new List<long>();
                foreach (var chitiet in ChiTietNhapKhoList)
                {
                    if (chitiet.IsUpdateKho == null || chitiet.IsUpdateKho == false)
                    {
                        var nguyenLieu = chitiet.NguyenLieu;
                        nguyenLieu.SoLuong += chitiet.SoLuong;
                        SF.Get<NguyenLieuViewModel>().Save(nguyenLieu);
                    }

                    chitiet.PhieuNhapKhoId = saveData.Id;
                    chitiet.IsUpdateKho = true;
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

        private void PhieuNhapKho_Kho_SelectedIndexChanged(object sender, EventArgs e)
        {
            KhoChange();
        }

        private void KhoChange()
        {
            var selectedValue = PhieuNhapKho_Kho.SelectedValue;
            if (selectedValue != null && string.IsNullOrEmpty(PhieuNhapKho_SoPhieu.Text))
            {
                var soPhieu = "";
                foreach (var item in selectedValue.ToString().Split('_'))
                {
                    soPhieu += item[0];
                }
                var currentDate = DateTime.UtcNow;
                soPhieu = string.Format("{0}_{1}_{2}", soPhieu, currentDate.Month, currentDate.Day);
                PhieuNhapKho_SoPhieu.Text = soPhieu;
            }
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

                        var currentDate = TimeHelper.TimeStampToDateTime(_currentData.NgayNhap);
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
                                if (nguyenLieu.DanhMuc != null) workSheet.Cells[startRow, "I"] = nguyenLieu.DanhMuc.Ten;
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


    }


}
