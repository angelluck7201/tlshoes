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

namespace TLShoes.FormControls.KeHoachSanXuat
{
    public partial class ucKeHoachSanXuat : UserControl
    {
        public ucKeHoachSanXuat(TLShoes.KeHoachSanXuat data = null)
        {
            InitializeComponent();


            KeHoachSanXuat_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            KeHoachSanXuat_DonHangId.DisplayMember = "MaHang";
            KeHoachSanXuat_DonHangId.ValueMember = "Id";

            if (data != null)
            {
                KeHoachSanXuat_DonHangId.SelectedValue = data.DonHangId;
                KeHoachSanXuat_NgayKiemHang.Text = TimeHelper.TimestampToString(data.NgayKiemHang);
                KeHoachSanXuat_NgayBatDauPxGo.Text = TimeHelper.TimestampToString(data.NgayBatDauPxGo);
                KeHoachSanXuat_NgayHoanThanhPxGo.Text = TimeHelper.TimestampToString(data.NgayHoanThanhPxGo);
                KeHoachSanXuat_NgayBatDauPXChat.Text = TimeHelper.TimestampToString(data.NgayBatDauPxChat);
                KeHoachSanXuat_NgayHoanThanhPXChat.Text = TimeHelper.TimestampToString(data.NgayHoanThanhPxChat);

                KeHoachSanXuat_NgayBatDauPxMay.Text = TimeHelper.TimestampToString(data.NgayBatDauPxMay);
                KeHoachSanXuat_NgayHoanThanhPxMay.Text = TimeHelper.TimestampToString(data.NgayHoanThanhPxMay);

                KeHoachSanXuat_NgayBatDauToPhuTro.Text = TimeHelper.TimestampToString(data.NgayBatDauToPhuTro);
                KeHoachSanXuat_NgayHoanThanhToPhuTro.Text = TimeHelper.TimestampToString(data.NgayHoanThanhToPhuTro);

                KeHoachSanXuat_GhiChu.Text = data.GhiChu;

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

            var saveData = SF.Get<KeHoachSanXuatViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new TLShoes.KeHoachSanXuat();
            }

            saveData.DonHangId = (long)KeHoachSanXuat_DonHangId.SelectedValue;
            saveData.GhiChu = KeHoachSanXuat_GhiChu.Text;
            saveData.NgayKiemHang = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayKiemHang.Value);
            saveData.NgayBatDauPxChat = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayBatDauPXChat.Value);
            saveData.NgayHoanThanhPxChat = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayHoanThanhPXChat.Value);
            saveData.NgayBatDauPxMay = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayBatDauPxMay.Value);
            saveData.NgayHoanThanhPxGo = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayHoanThanhPxGo.Value);
            saveData.NgayBatDauPxGo = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayBatDauPxGo.Value);
            saveData.NgayHoanThanhToPhuTro = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayHoanThanhToPhuTro.Value);
            saveData.NgayBatDauToPhuTro = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayBatDauToPhuTro.Value);
            saveData.NgayHoanThanhPxMay = TimeHelper.DateTimeToTimeStamp(KeHoachSanXuat_NgayHoanThanhPxMay.Value);
            CRUD.DecorateSaveData(saveData);
            SF.Get<KeHoachSanXuatViewModel>().Save(saveData);
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            KeHoachSanXuat_DonHangId.SelectedIndex = 0;
            KeHoachSanXuat_NgayKiemHang.Text = "";
            KeHoachSanXuat_NgayBatDauPXChat.Text = "";
            KeHoachSanXuat_NgayHoanThanhPXChat.Text = "";
            KeHoachSanXuat_NgayBatDauPxGo.Text = "";
            KeHoachSanXuat_NgayHoanThanhPxGo.Text = "";
            KeHoachSanXuat_NgayBatDauPxMay.Text = "";
            KeHoachSanXuat_NgayHoanThanhPxMay.Text = "";
            KeHoachSanXuat_NgayBatDauToPhuTro.Text = "";
            KeHoachSanXuat_NgayHoanThanhToPhuTro.Text = "";

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
    }
}
