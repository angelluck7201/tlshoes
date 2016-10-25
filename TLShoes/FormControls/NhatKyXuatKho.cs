using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls
{
    public partial class ucNhatKyXuatKho : BaseUserControl
    {
        private Action _callBack;
        public ucNhatKyXuatKho(PhieuXuatKho data, Action callBack= null)
        {
            InitializeComponent();
            Init();

            NhatKyXuatKho_ChiTietXuatKhoId.DisplayMember = "TenNguyenLieu";
            NhatKyXuatKho_ChiTietXuatKhoId.ValueMember = "Id";
            NhatKyXuatKho_ChiTietXuatKhoId.DataSource = new BindingSource(data.ChiTietXuatKhoes.ToList(), null);

            _callBack = callBack;

        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }

            // Save Don hang
            var saveData = CRUD.GetFormObject<NhatKyXuatKho>(FormControls);
            CRUD.DecorateSaveData(saveData);
            SF.Get<PhieuXuatKhoViewModel>().Save(saveData);

            _callBack();

            return true;
        }

        public string ValidateInput()
        {
            var chitietId = NhatKyXuatKho_ChiTietXuatKhoId.SelectedValue;
            if (chitietId != null)
            {
                var chitiet = SF.Get<ChiTietXuatKhoViewModel>().GetDetail((long)chitietId);
                var soLuongDaXuat = chitiet.NhatKyXuatKhoes.Sum(s => s.SoLuong);
                var soLuongXuat = PrimitiveConvert.StringToFloat(NhatKyXuatKho_SoLuong.Text);
                if (soLuongDaXuat + soLuongXuat >= chitiet.SoLuong)
                {
                    return "Đã vượt quá hạn mức của phiếu xuất, nên không thể xuất kho!";
                }
            }
            return string.Empty;
        }
    }
}
