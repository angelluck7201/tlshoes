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
        private TLShoes.HuongDanDongGoi _domainData;
        public ucHuongDanDongGoi(TLShoes.HuongDanDongGoi data = null)
        {
            InitializeComponent();

            var lstDonhang = new List<TLShoes.DonHang>();
            if (data != null && data.DonHang.TrangThai == Define.TrangThai.DONE.ToString())
            {
                lstDonhang.Add(data.DonHang);
            }
            else
            {
                lstDonhang = SF.Get<DonHangViewModel>().GetListAvailable();
            }
            SetComboboxDataSource(HuongDanDongGoi_DonHangId, lstDonhang, "MaHang");

            SetComboboxDataSource(HuongDanDongGoi_CachDong, Define.LoaiDongDic);

            Init(data);

            if (data != null)
            {
                _domainData = data;
                SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.HUONG_DAN_DONG_GOI, data.Id);
            }

            CachDongChange();
            LayMau();
            SoDoiChange();
            InitAuthorize();
        }

        private void InitAuthorize()
        {
            if (_domainData != null)
            {
                SF.Get<DonHangViewModel>().CheckDoneBaseOnDonHang(_domainData.DonHangId.GetValueOrDefault(), btnSave, lblMessage);
            }
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
                var saveData = CRUD.GetFormObject(FormControls, _domainData);
                if (saveData.CachDong == "SOLID")
                {
                    saveData.DongAssorment = "";
                }
                CRUD.DecorateSaveData(saveData, _domainData == null);
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
            if (Define.LoaiDong.ASSORTMENT.ToString().Equals(HuongDanDongGoi_CachDong.SelectedValue))
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
