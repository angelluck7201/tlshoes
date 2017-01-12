using System;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.FormControls;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class ucDanhMuc : BaseUserControl
    {
        public ucDanhMuc(DanhMuc danhMuc = null)
        {
            InitializeComponent();
            SetToolTip();

            DanhMuc_Loai.DisplayMember = "Value";
            DanhMuc_Loai.ValueMember = "Key";
            DanhMuc_Loai.DataSource = new BindingSource(Define.LoaiDanhMucDic, null);

            Init(danhMuc);
            if (danhMuc != null)
            {
                DanhMuc_Ten.Text = danhMuc.Ten;
                DanhMuc_GhiChu.Text = danhMuc.GhiChu;
                DanhMuc_Loai.SelectedValue = Enum.Parse(typeof(Define.LoaiDanhMuc), danhMuc.Loai);
            }
        }

        private void SetToolTip()
        {
//            var toolTip = ToolTipHelper.GetToolTip();
//
//            toolTip.SetToolTip(lblTen, "Ten danh muc");
//            toolTip.SetToolTip(lblGhiChu, "ghi chu ne");
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }
            var id = PrimitiveConvert.StringToInt(defaultInfo.Controls["Id"].Text);

            var saveData = SF.Get<DanhMucViewModel>().GetDetail(id);
            var isNew = false;
            if (saveData == null)
            {
                saveData = new DanhMuc();
                isNew = true;
            }

            saveData.Ten = DanhMuc_Ten.Text;
            saveData.Loai = DanhMuc_Loai.SelectedValue.ToString();
            saveData.GhiChu = DanhMuc_GhiChu.Text;
            CRUD.DecorateSaveData(saveData, isNew);
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
