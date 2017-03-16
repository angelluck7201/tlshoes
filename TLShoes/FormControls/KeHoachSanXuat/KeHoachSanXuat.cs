using System.Linq;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.KeHoachSanXuat
{
    public partial class ucKeHoachSanXuat : BaseUserControl
    {
        private TLShoes.KeHoachSanXuat _domainData;
        public ucKeHoachSanXuat(TLShoes.KeHoachSanXuat data = null)
        {
            InitializeComponent();

            KeHoachSanXuat_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            KeHoachSanXuat_DonHangId.DisplayMember = "MaHang";
            KeHoachSanXuat_DonHangId.ValueMember = "Id";
            _domainData = data;
            Init(data);
            LoadDonhang();
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }
            var saveData = CRUD.GetFormObject(FormControls, _domainData);
            CRUD.DecorateSaveData(saveData, _domainData == null);
            SF.Get<KeHoachSanXuatViewModel>().Save(saveData);
            return true;
        }


        public string ValidateInput()
        {
            if (_domainData == null)
            {
                var donHangId = KeHoachSanXuat_DonHangId.SelectedValue;
                if (donHangId == null)
                {
                    return "Chưa chọn đơn hàng.";
                }
                if (SF.Get<KeHoachSanXuatViewModel>().IsDuplicateDonhang((long) donHangId))
                {
                    var donHang = SF.Get<DonHangViewModel>().GetDetail((long) donHangId);

                    return string.Format("Đơn hàng số {0} đã được tạo kế hoạch rồi.", donHang.MaHang);
                }
            }
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
