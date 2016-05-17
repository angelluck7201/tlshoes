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
    public partial class ucKeHoachSanXuat : BaseUserControl
    {
        public ucKeHoachSanXuat(TLShoes.KeHoachSanXuat data = null)
        {
            InitializeComponent();


            KeHoachSanXuat_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            KeHoachSanXuat_DonHangId.DisplayMember = "MaHang";
            KeHoachSanXuat_DonHangId.ValueMember = "Id";

            Init(data);
         }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var saveData = CRUD.GetFormObject<TLShoes.KeHoachSanXuat>(FormControls);
            SF.Get<KeHoachSanXuatViewModel>().Save(saveData);
            return true;
        }

      

        public string ValidateInput()
        {
            return string.Empty;
        }
    }
}
