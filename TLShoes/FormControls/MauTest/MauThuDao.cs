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
        public BindingList<CommonClass.GopYItem> GopYBindingList = new BindingList<CommonClass.GopYItem>();

        public List<TLShoes.MauThuDao> ListDaoDaThu = new List<TLShoes.MauThuDao>();
        public long CurrentDonHang;
        public TLShoes.MauThuDao _domainData;
        public ucMauThuDao(TLShoes.MauThuDao data)
        {
            InitializeComponent();

            ListDaoDaThu = SF.Get<MauThuDaoViewModel>().GetList();

            var lstDonhang = new List<TLShoes.DonHang>();
            if (data != null && !data.DonHang.IsAvailable)
            {
                lstDonhang.Add(data.DonHang);
            }
            else
            {
                lstDonhang = SF.Get<DonHangViewModel>().GetListAvailable();
            }
            SetComboboxDataSource(MauThuDao_DonHangId, lstDonhang, "MaHang");

            var listPhanLoai = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_LOAI_TEST);

            MauThuDao_KetQuaXuongChatId.Text = "CHƯA PHÂN LOẠI";
            SetComboboxDataSource(MauThuDao_KetQuaXuongChatId, listPhanLoai, "Ten");

            MauThuDao_KetQuaXuongMayId.Text = "CHƯA PHÂN LOẠI";
            SetComboboxDataSource(MauThuDao_KetQuaXuongMayId, listPhanLoai, "Ten");

            MauThuDao_KetQuaXuongDeId.Text = "CHƯA PHÂN LOẠI";
            SetComboboxDataSource(MauThuDao_KetQuaXuongDeId, listPhanLoai, "Ten");

            MauThuDao_KetQuaXuongGoId.Text = "CHƯA PHÂN LOẠI";
            SetComboboxDataSource(MauThuDao_KetQuaXuongGoId, listPhanLoai, "Ten");

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
                CurrentDonHang = data.DonHangId.GetValueOrDefault();
                _domainData = data;
            }
            else
            {
                CurrentDonHang = 0;
            }
            InitAuthorize();
        }

        private void InitAuthorize()
        {
            btnExport.Visible = false;

            if (_domainData != null)
            {
                SF.Get<DonHangViewModel>().CheckAvailableBaseOnDonHang(_domainData.DonHangId.GetValueOrDefault(), btnSave, lblMessage);
                btnExport.Visible = true;
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

            var saveData = CRUD.GetFormObject(FormControls, _domainData);

            saveData.GopYVatTu = GopYBindingList[0].GopY;
            saveData.GopYXuongChat = GopYBindingList[1].GopY;
            saveData.GopYXuongDe = GopYBindingList[2].GopY;
            saveData.GopYXuongGo = GopYBindingList[3].GopY;
            saveData.GopYQc = GopYBindingList[4].GopY;
            saveData.GopYCongNghe = GopYBindingList[5].GopY;
            saveData.GopYMau = GopYBindingList[6].GopY;
            saveData.GopYKhoVatTu = GopYBindingList[7].GopY;
            saveData.GopYPhuTro = GopYBindingList[8].GopY;
            SF.Get<MauThuDaoViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            if (MauThuDao_DonHangId.SelectedValue == null)
            {
                return "Đơn Hàng";
            }
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
                var daoDaThu = ListDaoDaThu.Where(s => s.DonHang.MaPhomId == donHang.MaPhomId).OrderByDescending(s=>s.CreatedDate).FirstOrDefault();
                if (daoDaThu != null)
                {
                    MauThuDao_NgayBatDau.Enabled = false;
                    MauThuDao_NgayHoanThanh.Enabled = false;
                    MauThuDao_KetQuaXuongChatId.Enabled = false;
                    MauThuDao_KetQuaXuongMayId.Enabled = false;
                    MauThuDao_KetQuaXuongDeId.Enabled = false;
                    MauThuDao_KetQuaXuongGoId.Enabled = false;

                    if (daoDaThu.KetQuaXuongChatId != null) MauThuDao_KetQuaXuongChatId.SelectedValue = daoDaThu.KetQuaXuongChatId;
                    if (daoDaThu.KetQuaXuongMayId != null) MauThuDao_KetQuaXuongMayId.SelectedValue = daoDaThu.KetQuaXuongMayId;
                    if (daoDaThu.KetQuaXuongDeId != null) MauThuDao_KetQuaXuongDeId.SelectedValue = daoDaThu.KetQuaXuongDeId;
                    if (daoDaThu.KetQuaXuongGoId != null) MauThuDao_KetQuaXuongGoId.SelectedValue = daoDaThu.KetQuaXuongGoId;

                    lblThuDao.Visible = true;
                    btnUpdateKetQua.Enabled = true;
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
                    btnUpdateKetQua.Enabled = false;
                }
            }
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            if (_domainData == null) return;
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
                        var donHang = _domainData.DonHang;
                        workSheet.Cells[3, "D"] = donHang.MaHang;
                        workSheet.Cells[3, "G"] = donHang.KhachHang.TenCongTy;
                        var chiTietDonHang = donHang.ChiTietDonHangs.ToList();
                        workSheet.Cells[3, "J"] = chiTietDonHang.Sum(s => s.SoLuong);
                        var startCol = 2;
                        var lstMau = chiTietDonHang.Select(s => s.Mau.Ten).Distinct();
                        var mau = string.Join("-", lstMau);
                        workSheet.Cells[3, "M"] = mau;
                        foreach (var chitiet in chiTietDonHang)
                        {
                            if (chitiet.Mau != null)
                            {
                                workSheet.Cells[5, startCol] = string.Format("#{0} ({1})", chitiet.Size, chitiet.Mau.Ten);
                            }
                            else
                            {
                                workSheet.Cells[5, startCol] = string.Format("#{0}", chitiet.Size);
                            }
                            workSheet.Cells[6, startCol] = chitiet.SoLuong;
                            startCol++;
                        }

                        if (_domainData.KetQuaXuongChat != null) workSheet.Cells[9, "B"] = _domainData.KetQuaXuongChat.Ten;
                        workSheet.Cells[9, "I"] = _domainData.GopYXuongChat;

                        if (_domainData.KetQuaXuongMay != null) workSheet.Cells[10, "B"] = _domainData.KetQuaXuongMay.Ten;
                        workSheet.Cells[10, "I"] = _domainData.GopYXuongMay;

                        if (_domainData.KetQuaXuongDe != null) workSheet.Cells[11, "B"] = _domainData.KetQuaXuongDe.Ten;
                        workSheet.Cells[11, "I"] = _domainData.GopYXuongDe;

                        if (_domainData.KetQuaXuongGo != null) workSheet.Cells[12, "B"] = _domainData.KetQuaXuongGo.Ten;
                        workSheet.Cells[12, "I"] = _domainData.GopYXuongGo;

                        var currentDate = TimeHelper.Current();
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

        private void btnUpdateKetQua_Click(object sender, System.EventArgs e)
        {
            MauThuDao_NgayBatDau.Enabled = true;
            MauThuDao_NgayHoanThanh.Enabled = true;
            MauThuDao_KetQuaXuongChatId.Enabled = true;
            MauThuDao_KetQuaXuongMayId.Enabled = true;
            MauThuDao_KetQuaXuongDeId.Enabled = true;
            MauThuDao_KetQuaXuongGoId.Enabled = true;
        }

    }
}
