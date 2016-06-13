using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauSanXuat
{
    public partial class ucMauSanXuat : BaseUserControl
    {
        public ucMauSanXuat(TLShoes.MauSanXuat data)
        {
            InitializeComponent();
            MauSanXuat_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            MauSanXuat_DonHangId.DisplayMember = "MaHang";
            MauSanXuat_DonHangId.ValueMember = "Id";

            MauSanXuat_PhanLoaiKetQua.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            MauSanXuat_PhanLoaiKetQua.DisplayMember = "Ten";
            MauSanXuat_PhanLoaiKetQua.ValueMember = "Id";

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

            var saveData = CRUD.GetFormObject<TLShoes.MauSanXuat>(FormControls);
            SF.Get<MauSanXuatViewModel>().Save(saveData);
            return true;
        }

       

        public string ValidateInput()
        {
            return string.Empty;
        }
    }
}
