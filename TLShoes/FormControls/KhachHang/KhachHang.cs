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
using TLShoes.FormControls;
using TLShoes.ViewModels;

namespace TLShoes.Form
{
    public partial class ucKhachHang : BaseUserControl
    {

        public ucKhachHang(KhachHang data = null)
        {
            InitializeComponent();
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

            var saveData = CRUD.GetFormObject<KhachHang>(FormControls);

            SF.Get<KhachHangViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(KhachHang_TenCongTy.Text))
            {
                return lblTenCongTy.Text;
            }
            if (string.IsNullOrEmpty(KhachHang_Dienthoai.Text))
            {
                return lblDienThoai.Text;
            }
            return string.Empty;
        }

        #region Update total assessment

        private void UpdateTotalAssessment()
        {
            var updateData = new List<decimal>();
            if (KhachHang_DungThoiGian.Rating > 0)
            {
                updateData.Add(KhachHang_DungThoiGian.Rating);
            }
            if (KhachHang_DatTestHoa.Rating > 0)
            {
                updateData.Add(KhachHang_DatTestHoa.Rating);
            }
            if (KhachHang_DatTestLy.Rating > 0)
            {
                updateData.Add(KhachHang_DatTestLy.Rating);
            }
            if (KhachHang_DichVuGiaoHang.Rating > 0)
            {
                updateData.Add(KhachHang_DichVuGiaoHang.Rating);
            }
            if (KhachHang_DichVuHauMai.Rating > 0)
            {
                updateData.Add(KhachHang_DichVuHauMai.Rating);
            }
            if (KhachHang_DungMau.Rating > 0)
            {
                updateData.Add(KhachHang_DungMau.Rating);
            }
            if (KhachHang_DungYeuCauKyThuat.Rating > 0)
            {
                updateData.Add(KhachHang_DungYeuCauKyThuat.Rating);
            }
            if (KhachHang_Gia.Rating > 0)
            {
                updateData.Add(KhachHang_Gia.Rating);
            }
            if (KhachHang_Khac.Rating > 0)
            {
                updateData.Add(KhachHang_Khac.Rating);
            }

            DanhGiaTongThe.Rating = updateData.Average();
        }

        private void KhachHang_DungThoiGian_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void KhachHang_DungMau_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void KhachHang_DatTestLy_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void KhachHang_DatTestHoa_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void KhachHang_DungYeuCauKyThuat_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void KhachHang_Gia_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void KhachHang_DichVuGiaoHang_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void KhachHang_DichVuHauMai_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void KhachHang_Khac_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }
        #endregion
    }
}
