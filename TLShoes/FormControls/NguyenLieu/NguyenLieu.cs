using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.NguyenLieu
{
    public partial class ucNguyenLieu : BaseUserControl
    {
        public ucNguyenLieu(TLShoes.NguyenLieu data = null)
        {
            InitializeComponent();

            NguyenLieu_LoaiNguyenLieuId.DisplayMember = "Ten";
            NguyenLieu_LoaiNguyenLieuId.ValueMember = "Id";
            NguyenLieu_LoaiNguyenLieuId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.LOAI_NGUYEN_LIEU), null);

            NguyenLieu_DonViTinh.DisplayMember = "Ten";
            NguyenLieu_DonViTinh.ValueMember = "Id";
            NguyenLieu_DonViTinh.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.DON_VI_TINH), null);

            NguyenLieu_MauId.DisplayMember = "Ten";
            NguyenLieu_MauId.ValueMember = "Id";
            NguyenLieu_MauId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.MAU), null);


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

            var saveData = CRUD.GetFormObject<TLShoes.NguyenLieu>(FormControls);
            SF.Get<NguyenLieuViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }

        private void NguyenLieu_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormValidate.ValidateInputNumber(sender, e);
        }
    }
}
