using System.Linq;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.KeHoachSanXuat
{
    public partial class ucKeHoachSanXuat : BaseUserControl
    {
        public ucKeHoachSanXuat(TLShoes.KeHoachSanXuat data = null)
        {
            InitializeComponent();

            KeHoachSanXuat_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            KeHoachSanXuat_DonHangId.DisplayMember = "MaHang";
            KeHoachSanXuat_DonHangId.ValueMember = "Id";
            
            Init(data);
            LoadDonhang();
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var saveData = CRUD.GetFormObject<TLShoes.KeHoachSanXuat>(FormControls);
            SF.Get<KeHoachSanXuatViewModel>().Save(saveData);
            return true;
        }



        public string ValidateInput()
        {
            return string.Empty;
        }

        private void KeHoachSanXuat_DonHangId_SelectedIndexChanged(object sender, System.EventArgs e)
        {
           LoadDonhang();
        }

        private void LoadDonhang()
        {
            var donHangId = KeHoachSanXuat_DonHangId.SelectedValue;
            if (donHangId != null)
            {
                var donHang = SF.Get<DonHangViewModel>().GetDetail((long)donHangId);
                if (donHang == null) return;
                SoDH.Text = donHang.OrderNo;
                DonHangImage.Image = FileHelper.ImageFromFile(donHang.HinhAnh);
                gridControl.DataSource = donHang.ChiTietDonHangs.Select(s => new { s.SoLuong, MauId = s.Mau.Ten, s.Size });
            }
        }
    }
}
