using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;


namespace TLShoes
{
    public partial class ucDonHang : UserControl
    {
        public static BindingList<ChiTietDonHang> ChiTietDonhang = new BindingList<ChiTietDonHang>(); 
        public ucDonHang(DonHang data = null)
        {
            ChiTietDonhang.Clear();

            InitializeComponent();

            DonHang_KhachHangId.DataSource = new BindingSource(SF.Get<KhachHangViewModel>().GetList(), null);
            DonHang_KhachHangId.DisplayMember = "TenCongTy";
            DonHang_KhachHangId.ValueMember = "Id";
            if (data != null)
            {
                DonHang_KhachHangId.SelectedValue = data.KhachHangId;
                DonHang_MaHang.Text = data.MaHang;
                DonHang_OrderNo.Text = data.OrderNo;
                DonHang_NgayNhan.Text = TimeHelper.TimestampToString(data.NgayNhan);
                DonHang_NgayXuat.Text = TimeHelper.TimestampToString(data.NgayXuat);
                if (!string.IsNullOrEmpty(data.HinhAnh))
                {
                    DonHang_Hinh.Image = Image.FromFile(data.HinhAnh);
                }

                var gopY = data.GopYKhachHangs.FirstOrDefault();
                if (gopY != null)
                {
                    GopYKhacHang_PXChat.Text = gopY.XuongChat;
                    GopYKhacHang_PXDe.Text = gopY.XuongDe;
                    GopYKhacHang_PXGo.Text = gopY.XuongGo;
                    GopYKhacHang_QC.Text = gopY.Qc;
                    GopYKhacHang_PXMay.Text = gopY.XuongMay;
                    GopYKhacHang_VatTu.Text = gopY.VatTu;
                }

                ChiTietDonhang = new BindingList<ChiTietDonHang>(data.ChiTietDonHangs.ToList());
                defaultInfo.Controls["Id"].Text = data.Id.ToString();
                defaultInfo.Controls["AuthorId"].Text = data.AuthorId.ToString();
                defaultInfo.Controls["CreatedDate"].Text = TimeHelper.TimestampToString(data.CreatedDate);
                defaultInfo.Controls["ModifiedDate"].Text = TimeHelper.TimestampToString(data.ModifiedDate);
            }

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

        public bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var id = CommonHelper.StringToInt(defaultInfo.Controls["Id"].Text);
            // Save Don hang
            var saveData = SF.Get<DonHangViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new DonHang();
            }

            saveData.KhachHangId = (long)DonHang_KhachHangId.SelectedValue;
            saveData.MaHang = DonHang_MaHang.Text;
            saveData.OrderNo = DonHang_OrderNo.Text;
            saveData.NgayNhan = TimeHelper.DateTimeToTimeStamp(DonHang_NgayNhan.Value);
            saveData.NgayXuat = TimeHelper.DateTimeToTimeStamp(DonHang_NgayXuat.Value);
            if (DonHang_Hinh.Image != null)
            {
                saveData.HinhAnh = CommonHelper.ImageSave(DonHang_Hinh.Image);
            }
            CRUD.DecorateSaveData(saveData);
            SF.Get<DonHangViewModel>().Save(saveData);
            id = saveData.Id;

            // Save gop y
            var saveGopY = SF.Get<GopYKhachHangViewModel>().GetDetail(id);
            if (saveGopY == null)
            {
                saveGopY = new GopYKhachHang();
            }
            saveGopY.DonHangId = id;
            saveGopY.Qc = GopYKhacHang_QC.Text;
            saveGopY.VatTu = GopYKhacHang_VatTu.Text;
            saveGopY.XuongChat = GopYKhacHang_PXChat.Text;
            saveGopY.XuongDe = GopYKhacHang_PXDe.Text;
            saveGopY.XuongGo = GopYKhacHang_PXGo.Text;
            saveGopY.XuongMay = GopYKhacHang_PXMay.Text;
            CRUD.DecorateSaveData(saveGopY);
            SF.Get<GopYKhachHangViewModel>().Save(saveGopY);

            // Save Chi Tiet Don Hang
            foreach (var chitiet in ChiTietDonhang)
            {
                chitiet.DonHangId = id;
                CRUD.DecorateSaveData(chitiet);
                SF.Get<ChiTietDonHangViewModel>().Save(chitiet);
            }
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            DonHang_KhachHangId.SelectedIndex = 0;
            DonHang_MaHang.Text = "";
            DonHang_OrderNo.Text = "";
            DonHang_NgayNhan.Text = "";
            DonHang_NgayXuat.Text = "";
            DonHang_Hinh.Image = null;

            GopYKhacHang_PXChat.Text = "";
            GopYKhacHang_PXDe.Text = "";
            GopYKhacHang_PXGo.Text = "";
            GopYKhacHang_PXMay.Text = "";
            GopYKhacHang_QC.Text = "";
            GopYKhacHang_VatTu.Text = "";
            ChiTietDonhang.Clear();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.ParentForm.Close();
                ChiTietDonhang.Clear();
            }
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ClearData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            ChiTietDonhang.Clear();
        }

        private void ucDonHang_Load(object sender, EventArgs e)
        {

        }
    }
}
