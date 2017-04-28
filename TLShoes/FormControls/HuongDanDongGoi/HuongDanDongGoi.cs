using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.HuongDanDongGoi
{
    public partial class ucHuongDanDongGoi : BaseUserControl
    {
        private int SoLuong = 0;
        private TLShoes.HuongDanDongGoi _curData;
        public ucHuongDanDongGoi(TLShoes.HuongDanDongGoi data = null)
        {
            InitializeComponent();

            HuongDanDongGoi_DonHangId.DisplayMember = "MaHang";
            HuongDanDongGoi_DonHangId.ValueMember = "Id";
            HuongDanDongGoi_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            HuongDanDongGoi_CachDong.DisplayMember = "Value";
            HuongDanDongGoi_CachDong.ValueMember = "Key";
            HuongDanDongGoi_CachDong.DataSource = new BindingSource(Define.LoaiDongDic, null);

            Init(data);

            if (data != null)
            {
                _curData = data;
                HuongDanDongGoi_CachDong.SelectedValue = PrimitiveConvert.StringToEnum<Define.LoaiDong>(data.CachDong);
                SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.HUONG_DAN_DONG_GOI, data.Id);
            }

            CachDongChange();
            LayMau();
            SoDoiChange();
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }

            using (var transaction = new TransactionScope())
            {
                // Save huong dan 
                var saveData = CRUD.GetFormObject(FormControls, _curData);
                if (saveData.CachDong == "SOLID")
                {
                    saveData.DongAssorment = "";
                }
                CRUD.DecorateSaveData(saveData, _curData == null);
                SF.Get<HuongDanDongGoiViewModel>().Save(saveData);

                var nhatKyThayDoi = new NhatKyThayDoi();
                nhatKyThayDoi.GhiChu = LyDoThayDoi.Text;
                nhatKyThayDoi.ModelName = Define.ModelType.HUONG_DAN_DONG_GOI.ToString();
                nhatKyThayDoi.ItemId = saveData.Id;
                CRUD.DecorateSaveData(nhatKyThayDoi);
                SF.Get<NhatKyThayDoiViewModel>().Save(nhatKyThayDoi);
                transaction.Complete();
            }

            return true;
        }

        public string ValidateInput()
        {
            if (!string.IsNullOrEmpty(defaultInfo.Controls["Id"].Text))
            {
                if (string.IsNullOrEmpty(LyDoThayDoi.Text))
                {
                    return "lý do thay đổi";
                }
            }
            return string.Empty;
        }

        private void btnLayMau_Click(object sender, System.EventArgs e)
        {
            LayMau();
        }

        private void HuongDanDongGoi_SoDoi_Leave(object sender, System.EventArgs e)
        {
            SoDoiChange();
        }

        private void HuongDanDongGoi_CachDong_Leave(object sender, System.EventArgs e)
        {

        }

        private void HuongDanDongGoi_CachDong_SelectedValueChanged(object sender, System.EventArgs e)
        {
            CachDongChange();
        }

        public void CachDongChange()
        {
            if (Define.LoaiDong.ASSORTMENT.Equals(HuongDanDongGoi_CachDong.SelectedValue))
            {
                HuongDanDongGoi_DongAssorment.Visible = true;
                lblDongAssorment.Visible = true;
            }
            else
            {
                HuongDanDongGoi_DongAssorment.Visible = false;
                lblDongAssorment.Visible = false;
            }
        }

        public void LayMau()
        {
            var selectedValue = HuongDanDongGoi_DonHangId.SelectedValue;
            if (selectedValue != null)
            {
                var donHang = SF.Get<DonHangViewModel>().GetDetail((long)selectedValue);
                if (donHang != null)
                {
                    HuongDanDongGoi_MauDongGoiId.DataSource = new BindingSource(SF.Get<MauHuongDanDongGoiViewModel>().GetList((long)donHang.KhachHangId), null);
                    HuongDanDongGoi_MauDongGoiId.DisplayMember = "TenMau";
                    HuongDanDongGoi_MauDongGoiId.ValueMember = "Id";

                    TenCongTy.Text = donHang.KhachHang.TenCongTy;
                }
            }
        }

        public void SoDoiChange()
        {
            var soDoi = PrimitiveConvert.StringToInt(HuongDanDongGoi_SoDoi.Text);
            if (soDoi > 0)
            {
                SoThung.Text = (PrimitiveConvert.StringToInt(HuongDanDongGoi_SoLuong.Text) / soDoi).ToString();
            }
        }

        private void HuongDanDongGoi_SoLuong_TextChanged(object sender, System.EventArgs e)
        {
            SoDoiChange();
        }
    }
}
