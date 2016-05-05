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

namespace TLShoes.FormControls.BaoCaoPhanXuong
{
    public partial class ucBaoCaoPhanXuong : UserControl
    {
        public ucBaoCaoPhanXuong(TLShoes.BaoCaoPhanXuong data)
        {
            InitializeComponent();

            BaoCaoPhanXuong_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            BaoCaoPhanXuong_DonHangId.DisplayMember = "MaHang";
            BaoCaoPhanXuong_DonHangId.ValueMember = "Id";

            BaoCaoPhanXuong_PhanXuongId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_XUONG), null);
            BaoCaoPhanXuong_PhanXuongId.DisplayMember = "Ten";
            BaoCaoPhanXuong_PhanXuongId.ValueMember = "Id";

            if (data != null)
            {
                BaoCaoPhanXuong_DonHangId.SelectedValue = data.DonHangId;
                BaoCaoPhanXuong_PhanXuongId.SelectedValue = data.PhanXuongId;

                BaoCaoPhanXuong_SanLuongKhoan.Text = data.SanLuongKhoan.ToString();
                BaoCaoPhanXuong_SanLuongThucHien.Text = data.SanLuongThucHien.ToString();
                BaoCaoPhanXuong_PhanXuongId.SelectedValue = data.PhanXuongId;
                BaoCaoPhanXuong_GhiChu.Text = data.GhiChu;
                BaoCaoPhanXuong_BaoCaoNgay.Text = TimeHelper.TimestampToString(data.BaoCaoNgay);
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

            var saveData = SF.Get<BaoCaoPhanXuongViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new TLShoes.BaoCaoPhanXuong();
            }

            saveData.DonHangId = (long)BaoCaoPhanXuong_DonHangId.SelectedValue;
            saveData.PhanXuongId = (long)BaoCaoPhanXuong_PhanXuongId.SelectedValue;

            saveData.SanLuongThucHien = Int32.Parse(BaoCaoPhanXuong_SanLuongThucHien.Text);
            saveData.SanLuongKhoan = Int32.Parse(BaoCaoPhanXuong_SanLuongKhoan.Text);
            saveData.GhiChu = BaoCaoPhanXuong_GhiChu.Text;
            saveData.BaoCaoNgay = TimeHelper.DateTimeToTimeStamp(BaoCaoPhanXuong_BaoCaoNgay.Value);

            CRUD.DecorateSaveData(saveData);
            SF.Get<BaoCaoPhanXuongViewModel>().Save(saveData);
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            BaoCaoPhanXuong_DonHangId.SelectedIndex = 0;
            BaoCaoPhanXuong_PhanXuongId.SelectedIndex = 0;
            BaoCaoPhanXuong_SanLuongThucHien.Text = "";

            BaoCaoPhanXuong_SanLuongKhoan.Text = "";
            BaoCaoPhanXuong_GhiChu.Text = "";
            BaoCaoPhanXuong_BaoCaoNgay.Text = "";
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

        private void BaoCaoPhanXuong_SanLuongKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormValidate.ValidateInputNumber(sender, e);
        }

        private void BaoCaoPhanXuong_SanLuongThucHien_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormValidate.ValidateInputNumber(sender, e);
        }
    }
}
