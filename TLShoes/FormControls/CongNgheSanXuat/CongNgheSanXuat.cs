using System;
using System.Linq;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.CongNgheSanXuat
{
    public partial class ucCongNgheSanXuat : BaseUserControl
    {
        public ucCongNgheSanXuat(TLShoes.CongNgheSanXuat data)
        {
            InitializeComponent();

            CongNgheSanXuat_DonHangId.DisplayMember = "MaHang";
            CongNgheSanXuat_DonHangId.ValueMember = "Id";
            CongNgheSanXuat_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            CongNgheSanXuat_MauDoiId.ValueMember = "Id";
            CongNgheSanXuat_MauDoiId.DisplayMember = "MauDoiNgayFormat";

            CongNgheSanXuat_PhanLoaiThuRapId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            CongNgheSanXuat_PhanLoaiThuRapId.DisplayMember = "Ten";
            CongNgheSanXuat_PhanLoaiThuRapId.ValueMember = "Id";

            CongNgheSanXuat_PhanLoaiThuDao.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            CongNgheSanXuat_PhanLoaiThuDao.DisplayMember = "Ten";
            CongNgheSanXuat_PhanLoaiThuDao.ValueMember = "Id";

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

            var saveData = CRUD.GetFormObject<TLShoes.CongNgheSanXuat>(FormControls);
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
                    .Select(s => new { s.Id, MauDoiNgayFormat = TimeHelper.TimestampToString(s.MauNgay) }).ToList(), null);
            }
        }       
    }
}
