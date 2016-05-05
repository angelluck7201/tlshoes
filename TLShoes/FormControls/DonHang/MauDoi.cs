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

namespace TLShoes.FormControls.DonHang
{
    public partial class ucMauDoi : UserControl
    {
        public ucMauDoi(MauDoi data = null)
        {
            InitializeComponent();

            MauDoi_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            MauDoi_DonHangId.ValueMember = "Id";
            MauDoi_DonHangId.DisplayMember = "MaHang";

            if (data != null)
            {
                MauDoi_DonHangId.SelectedValue = data.DonHangId;
                MauDoi_NgayNhan.Text = TimeHelper.TimestampToString(data.NgayNhan);
                MauDoi_MauNgay.Text = TimeHelper.TimestampToString(data.MauNgay);
                MauDoi_GhiChu.Text = data.GhiChu;
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

            var saveData = SF.Get<MauDoiViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new MauDoi();
            }

            saveData.DonHangId = (long)MauDoi_DonHangId.SelectedValue;
            saveData.MauNgay = TimeHelper.DateTimeToTimeStamp(MauDoi_MauNgay.Value);
            saveData.NgayNhan = TimeHelper.DateTimeToTimeStamp(MauDoi_NgayNhan.Value);
            saveData.GhiChu = MauDoi_GhiChu.Text;
            CRUD.DecorateSaveData(saveData);
            SF.Get<MauDoiViewModel>().Save(saveData);
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            MauDoi_DonHangId.SelectedIndex = 0;
            MauDoi_GhiChu.Text = "";
            MauDoi_NgayNhan.Text = "";
            MauDoi_MauNgay.Text = "";
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

        private void ucDonHang_Load(object sender, EventArgs e)
        {

        }
    }
}
