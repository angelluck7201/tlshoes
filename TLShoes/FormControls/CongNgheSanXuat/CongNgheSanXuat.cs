using System;
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

            var lstDonHang = SF.Get<DonHangViewModel>().GetList();
            SetComboboxDataSource(CongNgheSanXuat_DonHangId, lstDonHang, "MaHang");

            CongNgheSanXuat_MauDoiId.ValueMember = "Id";
            CongNgheSanXuat_MauDoiId.DisplayMember = "MauDoiNgayFormat";

            var lstPhanLoai = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_LOAI_TEST);
            SetComboboxDataSource(CongNgheSanXuat_PhanLoaiThuRapId, lstPhanLoai, "Ten");
            SetComboboxDataSource(CongNgheSanXuat_PhanLoaiThuDaoId, lstPhanLoai, "Ten");

            _domainData = data;
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

            var saveData = CRUD.GetFormObject(FormControls, _domainData);
            SF.Get<CongNgheSanXuatViewModel>().Save(saveData);
            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }

        private void CongNgheSanXuat_DonHangId_SelectedValueChanged(object sender, EventArgs e)
        {
            CongNgheSanXuat_MauDoiId.Text = "";
            var donhang = (ComboBox)sender;
            if (donhang.SelectedValue != null)
            {
                CongNgheSanXuat_MauDoiId.DataSource = new BindingSource(SF.Get<MauDoiViewModel>().GetList((long)donhang.SelectedValue)
                    .Select(s => new { s.Id, MauDoiNgayFormat = s.MauNgay }).ToList(), null);
            }
        }
    }
}
