using System;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.FormControls;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class ucDanhMuc : BaseUserControl
    {
        private DanhMuc _domainData;
        public ucDanhMuc(DanhMuc danhMuc = null)
        {
            InitializeComponent();
            _domainData = danhMuc;

            SetComboboxDataSource(DanhMuc_Loai, Define.LoaiDanhMucDic);
            Init(danhMuc);
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
            SF.Get<DanhMucViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(DanhMuc_Ten.Text))
            {
                return string.Format("{0} {1}!", "Không được phép để trống", lblTen.Text);
            }
            var id = PrimitiveConvert.StringToInt(defaultInfo.Controls["Id"].Text);
            if (SF.Get<DanhMucViewModel>().CheckDuplicate(id, DanhMuc_Loai.Text, DanhMuc_Ten.Text))
            {
                return string.Format("{0} {1}!", DanhMuc_Ten.Text, "đã tồn tại trong hệ thống");
            }
            return string.Empty;
        }
    }
}
