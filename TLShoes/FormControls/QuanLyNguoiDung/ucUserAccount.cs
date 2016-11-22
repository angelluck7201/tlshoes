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

namespace TLShoes.FormControls.QuanLyNguoiDung
{
    public partial class ucUserAccount : BaseUserControl
    {
        private UserAccount _domainData;

        public ucUserAccount(UserAccount data = null)
        {
            InitializeComponent();
            _domainData = data;

            UserAccount_LoaiNguoiDung.DisplayMember = "Value";
            UserAccount_LoaiNguoiDung.ValueMember = "Key";
            UserAccount_LoaiNguoiDung.DataSource = new BindingSource(Define.LoaiNguoiDungDict, null);

            Init(data);

            if (data != null)
            {
                UserAccount_LoaiNguoiDung.SelectedValue = PrimitiveConvert.StringToEnum<Define.LoaiNguoiDung>(data.LoaiNguoiDung);
                UserAccount_TenNguoiDung.Enabled = false;
            }

        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }

            var saveData = CRUD.GetFormObject<UserAccount>(FormControls);
            CRUD.DecorateSaveData(saveData, _domainData == null);
            SF.Get<UserAccountViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(UserAccount_TenNguoiDung.Text))
            {
                return string.Format("{0} {1}!", "Không được phép để trống", lblTenNguoiDung.Text);
            }
            if (string.IsNullOrEmpty(UserAccount_TenNhanVien.Text))
            {
                return string.Format("{0} {1}!", "Không được phép để trống", lblTenNhanVien.Text);
            }
            var id = PrimitiveConvert.StringToInt(defaultInfo.Controls["Id"].Text);
            if (SF.Get<UserAccountViewModel>().CheckDuplicate(UserAccount_TenNguoiDung.Text, id))
            {
                return string.Format("{0} {1} {2}!", lblTenNguoiDung.Text, UserAccount_TenNguoiDung.Text, "đã tồn tại trong hệ thống");
            }
            return string.Empty;
        }
    }
}
