using System;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class ucDanhMuc : UserControl
    {
        public ucDanhMuc(TLShoes.DanhMuc danhMuc = null)
        {
            InitializeComponent();
            DanhMuc_Loai.DataSource = new BindingSource(Define.LoaiDanhMucDic, null);
            DanhMuc_Loai.DisplayMember = "Value";
            DanhMuc_Loai.ValueMember = "Key";

            if (danhMuc != null)
            {
                DanhMuc_Ten.Text = danhMuc.Ten;
                DanhMuc_GhiChu.Text = danhMuc.GhiChu;
                DanhMuc_Loai.SelectedValue = Enum.Parse(typeof(Define.LoaiDanhMuc),danhMuc.Loai);
                defaultInfo.Controls["Id"].Text = danhMuc.Id.ToString();
                defaultInfo.Controls["AuthorId"].Text = danhMuc.AuthorId.ToString();
                defaultInfo.Controls["CreatedDate"].Text = TimeHelper.TimestampToString(danhMuc.CreatedDate);
                defaultInfo.Controls["ModifiedDate"].Text = TimeHelper.TimestampToString(danhMuc.ModifiedDate);
            }
        }

        public bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }
            var id = PrimitiveConvert.StringToInt(defaultInfo.Controls["Id"].Text);

            var saveData = SF.Get<DanhMucViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new TLShoes.DanhMuc();
            }

            saveData.Ten = DanhMuc_Ten.Text;
            saveData.Loai = DanhMuc_Loai.SelectedValue.ToString();
            saveData.GhiChu = DanhMuc_GhiChu.Text;
            CRUD.DecorateSaveData(saveData);
            SF.Get<DanhMucViewModel>().Save(saveData);
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            DanhMuc_Ten.Text = "";
            DanhMuc_Loai.SelectedIndex = 0;
            DanhMuc_GhiChu.Text = "";
        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(DanhMuc_Ten.Text))
            {
                return string.Format("{0} {1}!", "Không được phép để trống", lblTen.Text);
            }
            if (SF.Get<DanhMucViewModel>().CheckDuplicate(DanhMuc_Ten.Text))
            {
                return string.Format("{0} {1}!", DanhMuc_Ten.Text, "đã tồn tại trong hệ thống");
            }
            return string.Empty;
        }

        private void defaultButton1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.ParentForm.Close();
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
        }
    }
}
