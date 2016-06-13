using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.FormControls;
using TLShoes.ViewModels;


namespace TLShoes
{
    public partial class ucDonHang : BaseUserControl
    {
        public static BindingList<ChiTietDonHang> ChiTietDonhang = new BindingList<ChiTietDonHang>();

        public static Dictionary<string, string> GopYDict = new Dictionary<string, string>()
        {
            {"Bp Vật Tư",""},
            {"Px Chặt",""},
            {"Px May",""},
            {"Px Gò",""},
            {"Px Đe",""},
            {"QC",""},
            {"Công Nghệ",""},
            {"Mẫu",""},
            {"Kho Vật Tư",""}, 
            {"Tổ Phụ Trợ",""},
            {"Kho Thành Phẩm",""},
        };

        public ucDonHang(DonHang data = null)
        {
            ChiTietDonhang.Clear();

            InitializeComponent();

            DonHang_KhachHangId.DataSource = new BindingSource(SF.Get<KhachHangViewModel>().GetList(), null);
            DonHang_KhachHangId.DisplayMember = "TenCongTy";
            DonHang_KhachHangId.ValueMember = "Id";

            DonHang_MaPhomId.DataSource = new BindingSource(SF.Get<NguyenLieuViewModel>().GetList().Where(s => s.LoaiNguyenLieu.Ten == "PHOM").ToList(), null);
            DonHang_MaPhomId.DisplayMember = "MaNguyenLieu";
            DonHang_MaPhomId.ValueMember = "Id";

            HideAllGopY();
            Init(data);
            if (data != null)
            {
                GopYDict["BP Vật Tư"] = data.GopYVatTu;
                GopYDict["Px Chặt"] = data.GopYXuongChat;
                GopYDict["Px May"] = data.GopYXuongMay;
                GopYDict["Px Gò"] = data.GopYXuongGo;
                GopYDict["Px Đe"] = data.GopYXuongDe;
                GopYDict["QC"] = data.GopYQc;
                GopYDict["Công Nghệ"] = data.GopYCongNghe;
                GopYDict["Mẫu"] = data.GopYMau;
                GopYDict["Kho Vật Tư"] = data.GopYKhoVatTu;
                GopYDict["Tổ Phụ Trợ"] = data.GopYPhuTro;
                GopYDict["Kho Thành Phẩm"] = data.GopYKhoThanhPham;

                ChiTietDonhang = new BindingList<ChiTietDonHang>(data.ChiTietDonHangs.ToList());
            }

            gridGopY.DataSource = GopYDict;

            repositoryItemLookUpEdit1.NullText = "";
            repositoryItemLookUpEdit1.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.MAU).Select(s => new { s.Ten, s.Id }).ToList();
            repositoryItemLookUpEdit1.PopulateColumns();
            repositoryItemLookUpEdit1.ShowHeader = false;
            repositoryItemLookUpEdit1.Columns["Id"].Visible = false;
            repositoryItemLookUpEdit1.Properties.DisplayMember = "Ten";
            repositoryItemLookUpEdit1.Properties.ValueMember = "Id";
            repositoryItemLookUpEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            gridControl.DataSource = ChiTietDonhang;
        }

        private void HideAllGopY()
        {
            DonHang_GopYCongNghe.Hide();
            DonHang_GopYKhoVatTu.Hide();
            DonHang_GopYKhoThanhPham.Hide();
            DonHang_GopYMau.Hide();
            DonHang_GopYPhuTro.Hide();
            DonHang_GopYXuongGo.Hide();
            DonHang_GopYXuongChat.Hide();
            DonHang_GopYXuongDe.Hide();
            DonHang_GopYXuongMay.Hide();
            DonHang_GopYVatTu.Hide();
            DonHang_GopYQC.Hide();

            lblGopY.Text = "";
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var saveData = CRUD.GetFormObject<DonHang>(FormControls);
            SF.Get<DonHangViewModel>().Save(saveData);
            var id = saveData.Id;

            // Save Chi Tiet Don Hang
            foreach (var chitiet in ChiTietDonhang)
            {
                chitiet.DonHangId = id;
                CRUD.DecorateSaveData(chitiet);
                SF.Get<ChiTietDonHangViewModel>().Save(chitiet);
            }
            return true;
        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(DonHang_KhachHangId.Text))
            {
                return lblKhacHangId.Text;
            }
            if (string.IsNullOrEmpty(DonHang_MaHang.Text))
            {
                return lblMaHang.Text;
            }
            if (string.IsNullOrEmpty(DonHang_OrderNo.Text))
            {
                return lblOrderNo.Text;
            }
            if (string.IsNullOrEmpty(DonHang_NgayNhan.Text))
            {
                return lblNgayNhan.Text;
            }
            if (string.IsNullOrEmpty(DonHang_NgayXuat.Text))
            {
                return lblNgayXuat.Text;
            }
            return string.Empty;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            int selectedRow = gridView1.FocusedRowHandle;
            dynamic data = gridView1.GetRow(selectedRow);
            HideAllGopY();
            switch ((string)data.Key)
            {
                case "Bp Vật Tư":
                    DonHang_GopYVatTu.Show();
                    lblGopY.Text = "Vật Tư";
                    break;
                case "Px Chặt":
                    DonHang_GopYXuongChat.Show();
                    lblGopY.Text = "Xưởng Chặt";
                    break;
                case "Px May":
                    DonHang_GopYXuongMay.Show();
                    lblGopY.Text = "Xưởng May";
                    break;
                case "Px Gò":
                    DonHang_GopYXuongGo.Show();
                    lblGopY.Text = "Xưởng Gò";
                    break;
                case "Px Đe":
                    DonHang_GopYXuongDe.Show();
                    lblGopY.Text = "Xưởng Đe";
                    break;
                case "QC":
                    DonHang_GopYQC.Show();
                    lblGopY.Text = "Bp QC";
                    break;
                case "Công Nghệ":
                    DonHang_GopYCongNghe.Show();
                    lblGopY.Text = "Công Nghệ";
                    break;
                case "Mẫu":
                    DonHang_GopYMau.Show();
                    lblGopY.Text = "Mẫu";
                    break;
                case "Kho Vật Tư":
                    DonHang_GopYKhoVatTu.Show();
                    lblGopY.Text = "Kho Vật Tư";
                    break;
                case "Tổ Phụ Trợ":
                    DonHang_GopYPhuTro.Show();
                    lblGopY.Text = "Tổ Phụ Trợ";
                    break;
                case "Kho Thành Phẩm":
                    DonHang_GopYKhoThanhPham.Show();
                    lblGopY.Text = "Kho Thành Phẩm";
                    break;
            }
            GopYDict["Bp Vật Tư"] = DonHang_GopYVatTu.Text;
            GopYDict["Px Chặt"] = DonHang_GopYXuongChat.Text;
            GopYDict["Px May"] = DonHang_GopYXuongMay.Text;
            GopYDict["Px Gò"] = DonHang_GopYXuongGo.Text;
            GopYDict["Px Đe"] = DonHang_GopYXuongDe.Text;
            GopYDict["QC"] = DonHang_GopYQC.Text;
            GopYDict["Công Nghệ"] = DonHang_GopYCongNghe.Text;
            GopYDict["Mẫu"] = DonHang_GopYMau.Text;
            GopYDict["Kho Vật Tư"] = DonHang_GopYKhoVatTu.Text;
            GopYDict["Tổ Phụ Trợ"] = DonHang_GopYPhuTro.Text;
            GopYDict["Kho Thành Phẩm"] = DonHang_GopYKhoThanhPham.Text;

            gridGopY.DataSource = null;
            gridGopY.DataSource = GopYDict;
            gridView1.FocusedRowHandle = selectedRow;
        }
    }
}
