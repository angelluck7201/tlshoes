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

namespace TLShoes.Form
{
    public partial class ucKhachHang : UserControl
    {

        public ucKhachHang(KhachHang data = null)
        {
            InitializeComponent();

            if (data != null)
            {
                KhachHang_TenCongTy.Text = data.TenCongTy;
                KhachHang_TenNguoiDaiDien.Text = data.TenNguoiDaiDien;
                KhachHang_DienThoai.Text = data.Dienthoai;
                KhachHang_DiaChi.Text = data.DiaChi;
                KhachHang_GhiChu.Text = data.GhiChu;
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

            var saveData = SF.Get<KhachHangViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new KhachHang();
            }

            saveData.TenNguoiDaiDien = KhachHang_TenNguoiDaiDien.Text;
            saveData.TenCongTy = KhachHang_TenCongTy.Text;
            saveData.Dienthoai = KhachHang_DienThoai.Text;
            saveData.GhiChu = KhachHang_GhiChu.Text;
            CRUD.DecorateSaveData(saveData);
            SF.Get<KhachHangViewModel>().Save(saveData);
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            KhachHang_TenNguoiDaiDien.Text = "";
            KhachHang_TenCongTy.Text = "";
            KhachHang_GhiChu.Text = "";
            KhachHang_GhiChu.Text = "";

        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(KhachHang_TenCongTy.Text))
            {
                return lblTenCongTy.Text;
            }
            if (string.IsNullOrEmpty(KhachHang_DienThoai.Text))
            {
                return lblDienThoai.Text;
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
    }
}
