using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.DonHang
{
    public partial class ucMauDoi : BaseUserControl
    {
        public ucMauDoi(MauDoi data = null)
        {
            InitializeComponent();

            MauDoi_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            MauDoi_DonHangId.ValueMember = "Id";
            MauDoi_DonHangId.DisplayMember = "MaHang";

            Init(data);

        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var saveData = CRUD.GetFormObject<MauDoi>(FormControls);
            SF.Get<MauDoiViewModel>().Save(saveData);
            return true;
        }


        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(MauDoi_MauNgay.Text))
            {
                return lblMauNgay.Text;
            }
            if (string.IsNullOrEmpty(MauDoi_NgayNhan.Text))
            {
                return lblNgayNhan.Text;
            }

            return string.Empty;
        }

      
    }
}
