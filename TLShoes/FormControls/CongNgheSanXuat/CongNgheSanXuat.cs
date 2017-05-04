using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.CongNgheSanXuat
{
    public partial class ucCongNgheSanXuat : BaseUserControl
    {
        private TLShoes.CongNgheSanXuat _domainData;
        public ucCongNgheSanXuat(TLShoes.CongNgheSanXuat data)
        {
            InitializeComponent();

            var lstDonhang = new List<TLShoes.DonHang>();
            if (data != null && !data.DonHang.IsAvailable)
            {
                lstDonhang.Add(data.DonHang);
            }
            else
            {
                lstDonhang = SF.Get<DonHangViewModel>().GetListAvailable();
            }
            SetComboboxDataSource(CongNgheSanXuat_DonHangId, lstDonhang, "MaHang");

            CongNgheSanXuat_MauDoiId.ValueMember = "Id";
            CongNgheSanXuat_MauDoiId.DisplayMember = "MauNgay";

            var lstPhanLoai = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_LOAI_TEST);
            SetComboboxDataSource(CongNgheSanXuat_PhanLoaiThuRapId, lstPhanLoai, "Ten");
            SetComboboxDataSource(CongNgheSanXuat_PhanLoaiThuDaoId, lstPhanLoai, "Ten");

            _domainData = data;
            Init(data);
            LoadMauDoi();
            InitAuthorize();
        }

        private void InitAuthorize()
        {
            if (_domainData != null)
            {
                SF.Get<DonHangViewModel>().CheckAvailableBaseOnDonHang(_domainData.DonHangId.GetValueOrDefault(), btnSave, lblMessage);
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

            var saveData = CRUD.GetFormObject(FormControls, _domainData);
            SF.Get<CongNgheSanXuatViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            if (CongNgheSanXuat_DonHangId.SelectedValue == null)
            {
                return "Đơn Hàng";
            }
            return string.Empty;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(LoadMauDoi);
        }

        private void LoadMauDoi()
        {
            CongNgheSanXuat_MauDoiId.Text = "";
            var donhang = CongNgheSanXuat_DonHangId;
            if (donhang.SelectedValue != null)
            {
                CongNgheSanXuat_MauDoiId.DataSource = new BindingSource(SF.Get<MauDoiViewModel>().GetList((long)donhang.SelectedValue).ToList(), null);
            }
        }
    }
}
