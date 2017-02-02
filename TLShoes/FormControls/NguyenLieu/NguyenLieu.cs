using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.NguyenLieu
{
    public partial class ucNguyenLieu : BaseUserControl
    {
        private TLShoes.NguyenLieu _domainData;
        public ucNguyenLieu(TLShoes.NguyenLieu data = null)
        {
            InitializeComponent();
            _domainData = data;

            var lstNguyenLieu = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.LOAI_NGUYEN_LIEU);
            SetComboboxDataSource(NguyenLieu_LoaiNguyenLieuId, lstNguyenLieu, "Ten");

            var lstDonViTinh = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.DON_VI_TINH);
            SetComboboxDataSource(NguyenLieu_DonViTinh, lstDonViTinh, "Ten");

            var lstMau = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.MAU);
            SetComboboxDataSource(NguyenLieu_MauId, lstMau, "Ten");

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

            var saveData = CRUD.GetFormObject(FormControls, _domainData);
            SF.Get<NguyenLieuViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }
    }
}
