using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.BaoCaoPhanXuong
{
    public partial class ucBaoCaoPhanXuong : BaseUserControl
    {
        public ucBaoCaoPhanXuong(TLShoes.BaoCaoPhanXuong data)
        {
            InitializeComponent();

            BaoCaoPhanXuong_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            BaoCaoPhanXuong_DonHangId.DisplayMember = "MaHang";
            BaoCaoPhanXuong_DonHangId.ValueMember = "Id";

            BaoCaoPhanXuong_PhanXuongId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_XUONG), null);
            BaoCaoPhanXuong_PhanXuongId.DisplayMember = "Ten";
            BaoCaoPhanXuong_PhanXuongId.ValueMember = "Id";

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

            var saveData = CRUD.GetFormObject<TLShoes.BaoCaoPhanXuong>(FormControls);
            SF.Get<BaoCaoPhanXuongViewModel>().Save(saveData);
            return true;
        }

     
        public string ValidateInput()
        {
            return string.Empty;
        }

        private void BaoCaoPhanXuong_SanLuongKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormValidate.ValidateInputNumber(sender, e);
        }

        private void BaoCaoPhanXuong_SanLuongThucHien_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormValidate.ValidateInputNumber(sender, e);
        }
    }
}
