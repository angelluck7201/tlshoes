using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Mvvm.POCO;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TLShoes.FormControls.MauThuDao
{
    public partial class ucMauThuDao : BaseUserControl
    {
        public static BindingList<CommonClass.GopYItem> GopYBindingList = new BindingList<CommonClass.GopYItem>();

        public static List<TLShoes.MauThuDao> ListDaoDaThu = new List<TLShoes.MauThuDao>();
        public static long CurrentDonHang;
        public TLShoes.MauThuDao CurrentMauThuDao;
        public ucMauThuDao(TLShoes.MauThuDao data)
        {
            InitializeComponent();

            ListDaoDaThu = SF.Get<MauThuDaoViewModel>().GetList();

            MauThuDao_DonHangId.DisplayMember = "MaHang";
            MauThuDao_DonHangId.ValueMember = "Id";
            MauThuDao_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            var listPhanLoai = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_LOAI_TEST);
            MauThuDao_KetQuaXuongChatId.DisplayMember = "Ten";
            MauThuDao_KetQuaXuongChatId.ValueMember = "Id";
            MauThuDao_KetQuaXuongChatId.DataSource = new BindingSource(listPhanLoai, null);
            MauThuDao_KetQuaXuongChatId.Text = "CHƯA PHÂN LOẠI";

            MauThuDao_KetQuaXuongMayId.Text = "CHƯA PHÂN LOẠI";
            MauThuDao_KetQuaXuongMayId.DisplayMember = "Ten";
            MauThuDao_KetQuaXuongMayId.ValueMember = "Id";
            MauThuDao_KetQuaXuongMayId.DataSource = new BindingSource(listPhanLoai, null);

            MauThuDao_KetQuaXuongDeId.Text = "CHƯA PHÂN LOẠI";
            MauThuDao_KetQuaXuongDeId.DisplayMember = "Ten";
            MauThuDao_KetQuaXuongDeId.ValueMember = "Id";
            MauThuDao_KetQuaXuongDeId.DataSource = new BindingSource(listPhanLoai, null);

            MauThuDao_KetQuaXuongGoId.Text = "CHƯA PHÂN LOẠI";
            MauThuDao_KetQuaXuongGoId.DisplayMember = "Ten";
            MauThuDao_KetQuaXuongGoId.ValueMember = "Id";
            MauThuDao_KetQuaXuongGoId.DataSource = new BindingSource(listPhanLoai, null);


            GopYBindingList.Clear();
            GopYBindingList.Add(new CommonClass.GopYItem("Bp Vật Tư", data != null ? data.GopYVatTu : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Px Chặt", data != null ? data.GopYXuongChat : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Px Gò", data != null ? data.GopYXuongGo : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Px Đe", data != null ? data.GopYXuongDe : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("QC", data != null ? data.GopYQc : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Công Nghệ", data != null ? data.GopYCongNghe : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Mẫu", data != null ? data.GopYMau : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Kho Vật Tư", data != null ? data.GopYKhoVatTu : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Tổ Phụ Trợ", data != null ? data.GopYPhuTro : ""));
            gridGopY.DataSource = GopYBindingList;

            lblGopY.Text = GopYBindingList[0].BoPhan;
            txtGopY.Text = GopYBindingList[0].GopY;

            Init(data);

            if (data != null)
            {
                CurrentDonHang = (long)data.DonHangId;
                CurrentMauThuDao = data;
                btnExport.Visible = true;
            }
            else
            {
                CurrentDonHang = 0;
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

            var saveData = CRUD.GetFormObject(FormControls, CurrentMauThuDao);

            saveData.GopYVatTu = GopYBindingList[0].GopY;
            saveData.GopYXuongChat = GopYBindingList[1].GopY;
            saveData.GopYXuongDe = GopYBindingList[2].GopY;
            saveData.GopYXuongGo = GopYBindingList[3].GopY;
            saveData.GopYQc = GopYBindingList[4].GopY;
            saveData.GopYCongNghe = GopYBindingList[5].GopY;
            saveData.GopYMau = GopYBindingList[6].GopY;
            saveData.GopYKhoVatTu = GopYBindingList[7].GopY;
            saveData.GopYPhuTro = GopYBindingList[8].GopY;
            CRUD.DecorateSaveData(saveData, CurrentMauThuDao == null);
            SF.Get<MauThuDaoViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }

        private void gridView1_Click(object sender, System.EventArgs e)
        {
            int selectedRow = gridView1.FocusedRowHandle;
            dynamic data = gridView1.GetRow(selectedRow);
            txtGopY.Text = data.GopY;
            lblGopY.Text = data.BoPhan;
            gridView1.FocusedRowHandle = selectedRow;
            txtGopY.Focus();
        }

        private void txtGopY_Leave(object sender, System.EventArgs e)
        {
            var changeData = GopYBindingList.FirstOrDefault(s => s.BoPhan == lblGopY.Text);
            if (changeData != null)
            {
                changeData.GopY = txtGopY.Text;
            }
        }

        private void MauThuDao_DonHangId_SelectedValueChanged(object sender, System.EventArgs e)
        {
            var donHangId = MauThuDao_DonHangId.SelectedValue;
            if (donHangId != null)
            {
                if (CurrentDonHang == (long)donHangId) return;
                var donHang = SF.Get<DonHangViewModel>().GetDetail((long)donHangId);
                if (donHang == null) return;
                var daoDaThu = ListDaoDaThu.FirstOrDefault(s => s.DonHang.MaPhomId == donHang.MaPhomId);

                GopYBindingList.Clear();
                GopYBindingList.Add(new CommonClass.GopYItem("Bp Vật Tư", daoDaThu != null ? daoDaThu.GopYVatTu : ""));
                GopYBindingList.Add(new CommonClass.GopYItem("Px Chặt", daoDaThu != null ? daoDaThu.GopYXuongChat : ""));
                GopYBindingList.Add(new CommonClass.GopYItem("Px Gò", daoDaThu != null ? daoDaThu.GopYXuongGo : ""));
                GopYBindingList.Add(new CommonClass.GopYItem("Px Đe", daoDaThu != null ? daoDaThu.GopYXuongDe : ""));
                GopYBindingList.Add(new CommonClass.GopYItem("QC", daoDaThu != null ? daoDaThu.GopYQc : ""));
                GopYBindingList.Add(new CommonClass.GopYItem("Công Nghệ", daoDaThu != null ? daoDaThu.GopYCongNghe : ""));
                GopYBindingList.Add(new CommonClass.GopYItem("Mẫu", daoDaThu != null ? daoDaThu.GopYMau : ""));
                GopYBindingList.Add(new CommonClass.GopYItem("Kho Vật Tư", daoDaThu != null ? daoDaThu.GopYKhoVatTu : ""));
                GopYBindingList.Add(new CommonClass.GopYItem("Tổ Phụ Trợ", daoDaThu != null ? daoDaThu.GopYPhuTro : ""));

                if (daoDaThu != null)
                {
                    MauThuDao_NgayBatDau.Enabled = false;
                    MauThuDao_NgayHoanThanh.Enabled = false;
                    MauThuDao_KetQuaXuongChatId.Enabled = false;
                    MauThuDao_KetQuaXuongMayId.Enabled = false;
                    MauThuDao_KetQuaXuongDeId.Enabled = false;
                    MauThuDao_KetQuaXuongGoId.Enabled = false;

                    if (daoDaThu.KetQuaXuongChat != null) MauThuDao_KetQuaXuongChatId.SelectedValue = daoDaThu.KetQuaXuongChat;
                    if (daoDaThu.KetQuaXuongMay != null) MauThuDao_KetQuaXuongMayId.SelectedValue = daoDaThu.KetQuaXuongMay;
                    if (daoDaThu.KetQuaXuongDe != null) MauThuDao_KetQuaXuongDeId.SelectedValue = daoDaThu.KetQuaXuongDe;
                    if (daoDaThu.KetQuaXuongGo != null) MauThuDao_KetQuaXuongGoId.SelectedValue = daoDaThu.KetQuaXuongGo;


                    lblThuDao.Visible = true;
                }
                else
                {
                    MauThuDao_NgayBatDau.Enabled = true;
                    MauThuDao_NgayHoanThanh.Enabled = true;
                    MauThuDao_KetQuaXuongChatId.Enabled = true;
                    MauThuDao_KetQuaXuongMayId.Enabled = true;
                    MauThuDao_KetQuaXuongDeId.Enabled = true;
                    MauThuDao_KetQuaXuongGoId.Enabled = true;
                    lblThuDao.Visible = false;
                }
            }
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            if (CurrentMauThuDao == null) return;
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = Define.EXPORT_EXTENSION;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ThreadHelper.LoadForm(() =>
                {
                    //Start Excel and get Application object.
                    var excel = new Application();

                    //Get a new workbook.
                    var workBook = excel.Workbooks.Open(Path.Combine(FileHelper.TemplatePath, Define.TEMPLATE_MAU_THU));
                    var workSheet = (_Worksheet)workBook.ActiveSheet;

                    try
                    {
                        var donHang = CurrentMauThuDao.DonHang;
                        workSheet.Cells[3, "D"] = donHang.MaHang;
                        workSheet.Cells[3, "G"] = donHang.KhachHang.TenCongTy;
                        var chiTietDonHang = donHang.ChiTietDonHangs.ToList();
                        workSheet.Cells[3, "J"] = chiTietDonHang.Sum(s => s.SoLuong);
                        var startCol = 2;
                        foreach (var chitiet in chiTietDonHang)
                        {
                            workSheet.Cells[5, startCol] = string.Format("#{0}", chitiet.Size);
                            workSheet.Cells[6, startCol] = chitiet.SoLuong;
                            if (chitiet.Mau != null) workSheet.Cells[3, "J"] = chitiet.Mau.Ten;
                            startCol++;
                        }

                        if (CurrentMauThuDao.KetQuaXuongChat != null) workSheet.Cells[9, "B"] = CurrentMauThuDao.KetQuaXuongChat;
                        workSheet.Cells[9, "I"] = CurrentMauThuDao.GopYXuongChat;

                        if (CurrentMauThuDao.KetQuaXuongMay != null) workSheet.Cells[10, "B"] = CurrentMauThuDao.KetQuaXuongMay;
                        workSheet.Cells[10, "I"] = CurrentMauThuDao.GopYXuongMay;

                        if (CurrentMauThuDao.KetQuaXuongDe != null) workSheet.Cells[11, "B"] = CurrentMauThuDao.KetQuaXuongDe;
                        workSheet.Cells[11, "I"] = CurrentMauThuDao.GopYXuongDe;

                        if (CurrentMauThuDao.KetQuaXuongGo != null) workSheet.Cells[12, "B"] = CurrentMauThuDao.KetQuaXuongGo;
                        workSheet.Cells[12, "I"] = CurrentMauThuDao.GopYXuongGo;

                        var currentDate = TimeHelper.TimeStampToDateTime(TimeHelper.CurrentTimeStamp());
                        workSheet.Cells[19, "J"] = string.Format("Ngày {0} Tháng {1} Năm {2}", currentDate.Day, currentDate.Month, currentDate.Year);

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
