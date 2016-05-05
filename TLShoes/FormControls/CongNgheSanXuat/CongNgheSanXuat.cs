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

namespace TLShoes.FormControls.CongNgheSanXuat
{
    public partial class ucCongNgheSanXuat : UserControl
    {
        public ucCongNgheSanXuat(TLShoes.CongNgheSanXuat data)
        {
            InitializeComponent();

            CongNgheSanXuat_DonHangId.DisplayMember = "MaHang";
            CongNgheSanXuat_DonHangId.ValueMember = "Id";
            CongNgheSanXuat_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            CongNgheSanXuat_MauDoiId.ValueMember = "Id";
            CongNgheSanXuat_MauDoiId.DisplayMember = "Id";

            CongNgheSanXuat_PhanLoaiThuRap.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            CongNgheSanXuat_PhanLoaiThuRap.DisplayMember = "Ten";
            CongNgheSanXuat_PhanLoaiThuRap.ValueMember = "Id";

            CongNgheSanXuat_PhanLoaiThuDao.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            CongNgheSanXuat_PhanLoaiThuDao.DisplayMember = "Ten";
            CongNgheSanXuat_PhanLoaiThuDao.ValueMember = "Id";

            if (data != null)
            {
                CongNgheSanXuat_DonHangId.SelectedValue = data.DonHangId;
                CongNgheSanXuat_MauDoiId.SelectedValue = data.MauDoiId;

                CongNgheSanXuat_YKienThuRap.Text = data.YKienThuRap;
                CongNgheSanXuat_PhanLoaiThuRap.SelectedValue = data.PhanLoaiThuRapId;

                CongNgheSanXuat_YKienThuDao.Text = data.YKienThuDao;
                CongNgheSanXuat_PhanLoaiThuDao.SelectedValue = data.PhanLoaiThuDao;
                CongNgheSanXuat_NgayDuyet.Text = TimeHelper.TimestampToString(data.NgayDuyet);

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

            var saveData = SF.Get<CongNgheSanXuatViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new TLShoes.CongNgheSanXuat();
            }

            saveData.DonHangId = (long)CongNgheSanXuat_DonHangId.SelectedValue;
            saveData.MauDoiId = (long)CongNgheSanXuat_MauDoiId.SelectedValue;

            saveData.YKienThuDao = CongNgheSanXuat_YKienThuDao.Text;
            saveData.PhanLoaiThuDao = (long)CongNgheSanXuat_PhanLoaiThuDao.SelectedValue;
            saveData.YKienThuRap = CongNgheSanXuat_YKienThuRap.Text;
            saveData.PhanLoaiThuRapId = (long)CongNgheSanXuat_PhanLoaiThuRap.SelectedValue;
            saveData.NgayDuyet = TimeHelper.DateTimeToTimeStamp(CongNgheSanXuat_NgayDuyet.Value);

            CRUD.DecorateSaveData(saveData);
            SF.Get<CongNgheSanXuatViewModel>().Save(saveData);
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            CongNgheSanXuat_DonHangId.SelectedIndex = 0;
            CongNgheSanXuat_PhanLoaiThuDao.SelectedIndex = 0;
            CongNgheSanXuat_YKienThuDao.Text = "";

            CongNgheSanXuat_YKienThuRap.Text = "";
            CongNgheSanXuat_PhanLoaiThuRap.SelectedIndex = 0;
            CongNgheSanXuat_NgayDuyet.Text = "";
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

        private void CongNgheSanXuat_DonHangId_SelectedValueChanged(object sender, EventArgs e)
        {
            CongNgheSanXuat_MauDoiId.Text = "";
            var donhang = (ComboBox)sender;
            if (donhang.SelectedValue != null)
                CongNgheSanXuat_MauDoiId.DataSource = new BindingSource(SF.Get<MauDoiViewModel>().GetList((long)donhang.SelectedValue), null);
        }
    }
}
