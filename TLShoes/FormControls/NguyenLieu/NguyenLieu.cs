using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.NguyenLieu
{
    public partial class ucNguyenLieu : UserControl
    {
        public ucNguyenLieu(TLShoes.NguyenLieu data = null)
        {
            InitializeComponent();

            NguyenLieu_LoaiNguyenLieu.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.LOAI_NGUYEN_LIEU), null);
            NguyenLieu_LoaiNguyenLieu.DisplayMember = "Ten";
            NguyenLieu_LoaiNguyenLieu.ValueMember = "Id";

            NguyenLieu_DonViTinh.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.DON_VI_TINH), null);
            NguyenLieu_DonViTinh.DisplayMember = "Ten";
            NguyenLieu_DonViTinh.ValueMember = "Id";

            if (data != null)
            {
                NguyenLieu_LoaiNguyenLieu.SelectedValue = data.LoaiNguyenLieuId;
                NguyenLieu_DonViTinh.SelectedValue = data.DonViTinh;

                NguyenLieu_MaNguyenLieu.Text = data.MaNguyenLieu;
                NguyenLieu_Ten.Text = data.Ten;
                NguyenLieu_SoLuong.Text = data.SoLuong.ToString();
                NguyenLieu_GhiChu.Text = data.GhiChu;

                defaultInfo.Controls["Id"].Text = data.Id.ToString();
                defaultInfo.Controls["AuthorId"].Text = data.AuthorId.ToString();
                defaultInfo.Controls["CreatedDate"].Text = TimeHelper.TimestampToString(data.CreatedDate);
                defaultInfo.Controls["ModifiedDate"].Text = TimeHelper.TimestampToString(data.ModifiedDate);
            }
        }
        public bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var id = CommonHelper.StringToInt(defaultInfo.Controls["Id"].Text);

            var saveData = SF.Get<NguyenLieuViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new TLShoes.NguyenLieu();
            }

            saveData.LoaiNguyenLieuId = (long)NguyenLieu_LoaiNguyenLieu.SelectedValue;
            saveData.DonViTinh = (long)NguyenLieu_DonViTinh.SelectedValue;

            saveData.MaNguyenLieu = NguyenLieu_MaNguyenLieu.Text;
            saveData.SoLuong = Int32.Parse(NguyenLieu_SoLuong.Text);
            saveData.Ten = NguyenLieu_Ten.Text;
            saveData.GhiChu = NguyenLieu_GhiChu.Text;

            CRUD.DecorateSaveData(saveData);
            SF.Get<NguyenLieuViewModel>().Save(saveData);
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            NguyenLieu_LoaiNguyenLieu.SelectedIndex = 0;
            NguyenLieu_DonViTinh.SelectedIndex = 0;
            NguyenLieu_Ten.Text = "";

            NguyenLieu_SoLuong.Text = "";
            NguyenLieu_GhiChu.Text = "";
        }

        public string ValidateInput()
        {
            return string.Empty;
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

        private void NguyenLieu_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormValidate.ValidateInputNumber(sender, e);
        }
    }
}
