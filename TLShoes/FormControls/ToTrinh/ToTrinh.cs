using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinh : BaseUserControl
    {
        private TongHopToTrinh currentToTrinh = null;
        private Dictionary<long, List<ChiTietToTrinh>> DictChiTietToTrinh = new Dictionary<long, List<ChiTietToTrinh>>();
        private BindingList<TLShoes.ToTrinh> ToTrinhList = new BindingList<TLShoes.ToTrinh>();
        public ucToTrinh(TongHopToTrinh data = null)
        {
            InitializeComponent();

            ToTrinh_NguyenLieuId.DisplayMember = "Ten";
            ToTrinh_NguyenLieuId.ValueMember = "Id";
            ToTrinh_NguyenLieuId.DataSource = new BindingSource(SF.Get<NguyenLieuViewModel>().GetList(), null);

            Init(data);

            if (data != null)
            {
                ToTrinhList = new BindingList<TLShoes.ToTrinh>(data.ToTrinhs.ToList());
                currentToTrinh = data;
            }
            InitAuthorize();

            gridToTrinh.DataSource = ToTrinhList;
            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;
        }

        public void InitAuthorize()
        {
            btnDuyet.Visible = false;
            btnExport.Visible = false;
            btnSave.Enabled = true;

            if (currentToTrinh != null)
            {
                lblSoPhieu.Text = string.Format("Số Tờ Trình: {0}", currentToTrinh.SoPhieu);

                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(currentToTrinh.TrangThai);

                if (trangThai <= Define.TrangThai.DUYET)
                {
                    btnDuyet.Visible = true;
                }

                if (trangThai > Define.TrangThai.MOI)
                {
                    btnSave.Enabled = false;
                }

                if (trangThai == Define.TrangThai.DUYET_PVT)
                {
                    btnExport.Visible = true;
                }

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
                if (currentToTrinh == null)
                {
                    currentToTrinh = new TongHopToTrinh();
                    currentToTrinh.TrangThai = Define.TrangThai.MOI.ToString();
                    SF.Get<ToTrinhViewModel>().Save(currentToTrinh);
                }

                foreach (var toTrinh in ToTrinhList)
                {
                    toTrinh.TongHopToTrinhId = currentToTrinh.Id;
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
                    var nguyenLieuId = (long)toTrinh.NguyenLieuId;
                    if (DictChiTietToTrinh.ContainsKey(nguyenLieuId))
                    {
                        foreach (var chiTietToTrinh in DictChiTietToTrinh[nguyenLieuId])
                        {
                            chiTietToTrinh.ToTrinhId = toTrinh.Id;
                            SF.Get<ChiTietToTrinhViewModel>().Save(chiTietToTrinh);
                        }
                    }
                }
                transaction.Complete();
            }
            return true;
        }

        public string ValidateInput()
        {
            if (currentToTrinh != null)
            {
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(currentToTrinh.TrangThai);
                if (trangThai > Define.TrangThai.MOI)
                {
                    return "Chỉ lệnh đã được duyệt nên không thể thay đổi!";
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
                    var nguyenLieuId = (long)nguyenLieuObj;
                    var chiLenhList = SF.Get<ChiTietNguyenLieuViewModel>().GetList()
                        .Where(s => s.ChiTietNguyenLieuId == nguyenLieuId)
                        .GroupBy(s => s.NguyenLieuChiLenh.ChiLenh.DonHang);

                    var xuatKhoList = SF.Get<ChiTietXuatKhoViewModel>().GetListByNguyenLieu(nguyenLieuId);
                    var tongXuatKho = xuatKhoList.Sum(s => s.SoLuong);

                    var nhapKhoList = SF.Get<ChiTietNhapKhoViewModel>().GetListByNguyenLieu(nguyenLieuId);
                    var tongNhapKho = nhapKhoList.Sum(s => s.SoLuong);

                    // Bổ sung là tổng xuất kho ngoài chỉ lệnh
                    var xuatKhoBoSung = xuatKhoList.Where(s => s.PhieuXuatKho.LoaiXuat == Define.LoaiXuat.NGOAI_CHI_LENH.ToString()).Sum(s => s.SoLuong);

                    var tonTheKho = tongNhapKho - tongXuatKho;
                    ToTrinh_BoSung.Text = xuatKhoBoSung.ToString();
                    ToTrinh_TonTheKho.Text = tonTheKho.ToString();
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

                    if (!DictChiTietToTrinh.ContainsKey(nguyenLieuId))
                    {
                        DictChiTietToTrinh.Add(nguyenLieuId, lstChiTietToTrinh);
                    }
                    gridChiTietToTrinh.DataSource = lstChiTietToTrinh.Select(s => new { s.DonHang.MaHang, s.NhuCau, s.ThucTe });
                }
            }, ParentForm);
        }

        private void btnUpdateToTrinh_Click(object sender, EventArgs e)
        {
            var toTrinh = CRUD.GetFormObject<TLShoes.ToTrinh>(FormControls);
            toTrinh.NguyenLieu = SF.Get<NguyenLieuViewModel>().GetDetail((long)toTrinh.NguyenLieuId);
            ToTrinhList.Add(toTrinh);
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
                var nguyenLieuId = (long)data.NguyenLieuId;
                gridChiTietToTrinh.DataSource = DictChiTietToTrinh.ContainsKey(nguyenLieuId) ? DictChiTietToTrinh[nguyenLieuId] : data.ChiTietToTrinhs.ToList();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel |*.xls";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ThreadHelper.LoadForm(() =>
                {


                    //Start Excel and get Application object.
                    var excel = new Application();
                    //Get a new workbook.
                    var workBook = excel.Workbooks.Open(Path.Combine(FileHelper.TemplatePath, Define.TEMPLATE_TO_TRINH));
                    var workSheet = (_Worksheet)workBook.ActiveSheet;

                    try
                    {
                        // Get loai to trinh
                        if (currentToTrinh != null)
                        {
                            var groupByNguyenLieu = ToTrinhList.GroupBy(s => s.NguyenLieu.LoaiNguyenLieu).ToList();
                            var loaiToTrinh = "TỔNG HỢP";
                            if (groupByNguyenLieu.Count == 1)
                            {
                                loaiToTrinh = groupByNguyenLieu.First().Key.Ten;
                            }
                            workSheet.Cells[2, "A"] = string.Format("TỜ TRÌNH {0}", loaiToTrinh.ToUpper());
                        }

                        // Group by don hang 
                        var groupedToTrinh = ToTrinhList.SelectMany(s => s.ChiTietToTrinhs).GroupBy(s => s.DonHangId).ToList();
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
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (currentToTrinh != null)
            {
                using (var transaction = new TransactionScope())
                {
                    var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(currentToTrinh.TrangThai);
                    var ngayDuyet = TimeHelper.CurrentTimeStamp();
                    if (trangThai == Define.TrangThai.MOI)
                    {
                        currentToTrinh.SoPhieu = SF.Get<ToTrinhViewModel>().GenerateSoPhieu();
                        currentToTrinh.NgayLap = ngayDuyet;
                        currentToTrinh.NguoiLapId = Authorization.LoginUser.Id;
                        currentToTrinh.TrangThai = Define.TrangThai.DUYET.ToString();
                    }
                    if (trangThai == Define.TrangThai.DUYET)
                    {
                        currentToTrinh.TrangThai = Define.TrangThai.DUYET_PVT.ToString();
                        currentToTrinh.NgayDuyet = ngayDuyet;
                        currentToTrinh.NguoiDuyetId = Authorization.LoginUser.Id;
                    }

                    SF.Get<ToTrinhViewModel>().Save(currentToTrinh);
                    transaction.Complete();
                }
                InitAuthorize();
            }
        }
    }
}
