using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauTest
{
    public partial class ucMauTest : BaseUserControl
    {
        public ucMauTest(TLShoes.MauTest data)
        {
            InitializeComponent();
            MauTest_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            MauTest_DonHangId.DisplayMember = "MaHang";
            MauTest_DonHangId.ValueMember = "Id";

            MauTest_PhanLoaiTestHoaId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            MauTest_PhanLoaiTestHoaId.DisplayMember = "Ten";
            MauTest_PhanLoaiTestHoaId.ValueMember = "Id";

            MauTest_PhanLoaiTestLyId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            MauTest_PhanLoaiTestLyId.DisplayMember = "Ten";
            MauTest_PhanLoaiTestLyId.ValueMember = "Id";

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

            var saveData = CRUD.GetFormObject<TLShoes.MauTest>(FormControls);
            SF.Get<MauTestViewModel>().Save(saveData);
            return true;
        }

       

        public string ValidateInput()
        {
            return string.Empty;
        }
    }
}
