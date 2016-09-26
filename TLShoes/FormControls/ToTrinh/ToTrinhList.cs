using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinhList : UserControl
    {
        public ucToTrinhList()
        {
            InitializeComponent();
            ReloadData();
            ObserverControl.Regist("ucToTrinh", "ucToTrinhList", ReloadData);
            ObserverControl.Regist("Refresh", "ucToTrinhList", ReloadData);
            ObserverControl.Regist("Close", "ucToTrinhList", ReloadData);
            ObserverControl.Regist("Export", "ucToTrinhList", Export);
        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<ToTrinhViewModel>().GetDataSource(gridControl);
                if (gridView.RowCount > 0)
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = true;
                }
                else
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = false;
                }
            });
        }

        public void Export(object filePath)
        {
            ThreadHelper.LoadForm(() =>
            {
                // Get list export data
                var exportData = new List<TLShoes.ToTrinh>();
                var gridInfo = (GridViewInfo)gridView.GetViewInfo();
                foreach (var row in gridInfo.RowsInfo)
                {
                    int rowHandle = row.RowHandle;

                    if (gridView.IsDataRow(rowHandle))
                    {
                        var dataObject = gridView.GetRow(rowHandle) as TLShoes.ToTrinh;
                        if (dataObject != null)
                        {
                            exportData.Add(dataObject);
                        }
                    }
                }

                //Start Excel and get Application object.
                var excel = new Application();
                //Get a new workbook.
                var workBook = excel.Workbooks.Open(Path.Combine(FileHelper.TemplatePath, Define.TEMPLATE_TO_TRINH));
                var workSheet = (_Worksheet)workBook.ActiveSheet;

                try
                {
                    // Group by don hang 
                    var groupedToTrinh = exportData.SelectMany(s => s.ChiTietToTrinhs).GroupBy(s => s.DonHangId).ToList();
                    var startColumn = 4;
                    var startRow = 7;
                    var dictNguyenLieu = new Dictionary<long, int>();
                    foreach (var group in groupedToTrinh)
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
                            if (!dictNguyenLieu.ContainsKey((long)toTrinh.NguyenLieuId))
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
                                currentRow = dictNguyenLieu[(long)toTrinh.NguyenLieuId];
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

                    var currentDate = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
                    workSheet.Cells[startRow + 1, startColumn] = string.Format("Long An. Ngày {0} Tháng {1} Năm {2}", currentDate.Day, currentDate.Month, currentDate.Year);
                    workSheet.Cells[startRow + 4, startColumn] = Authorization.LoginUser.TenNguoiDung;

                    workBook.SaveAs(filePath);
                }
                finally
                {
                    workBook.Close();
                }

            });


            var confirmDialog = MessageBox.Show(Define.MESSAGE_EXPORT_SUCCESS_TEXT, Define.MESSAGE_EXPORT_SUCCESS_TITLE, MessageBoxButtons.YesNo);
            if (confirmDialog == DialogResult.Yes)
            {
                Process.Start(filePath.ToString());
            }

        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                var info = SF.Get<ToTrinhViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);
            });
        }
    }
}
