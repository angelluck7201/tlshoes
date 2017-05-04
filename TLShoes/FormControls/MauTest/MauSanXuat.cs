using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauSanXuat
{
    public partial class ucMauSanXuat : BaseUserControl
    {
        public BindingList<CommonClass.GopYItem> GopYBindingList = new BindingList<CommonClass.GopYItem>();
        private TLShoes.MauSanXuat _domainData;

        public ucMauSanXuat(TLShoes.MauSanXuat data)
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
            SetComboboxDataSource(MauSanXuat_DonHangId, lstDonhang, "MaHang");

            var lstPhanLoaiTest = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_LOAI_TEST);
            SetComboboxDataSource(MauSanXuat_PhanLoaiKetQua,lstPhanLoaiTest,"Ten");


            GopYBindingList.Add(new CommonClass.GopYItem("Bp Vật Tư", data != null ? data.GopYVatTu : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Px Chặt", data != null ? data.GopYXuongChat : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Px Gò", data != null ? data.GopYXuongGo : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Px Đe", data != null ? data.GopYXuongDe : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("QC", data != null ? data.GopYQc : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Công Nghệ", data != null ? data.GopYCongNghe : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Mẫu", data != null ? data.GopYMau : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Kho Vật Tư", data != null ? data.GopYKhoVatTu : ""));
            GopYBindingList.Add(new CommonClass.GopYItem("Tổ Phụ Trợ", data != null ? data.GopYPhuTro : ""));
            gridGopY.DataSource = GopYBindingList;

            lblGopY.Text = GopYBindingList[0].BoPhan;
            txtGopY.Text = GopYBindingList[0].GopY;

            _domainData = data;
            Init(data);
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
            saveData.GopYVatTu = GopYBindingList[0].GopY;
            saveData.GopYXuongChat = GopYBindingList[1].GopY;
            saveData.GopYXuongDe = GopYBindingList[2].GopY;
            saveData.GopYXuongGo = GopYBindingList[3].GopY;
            saveData.GopYQc = GopYBindingList[4].GopY;
            saveData.GopYCongNghe = GopYBindingList[5].GopY;
            saveData.GopYMau = GopYBindingList[6].GopY;
            saveData.GopYKhoVatTu = GopYBindingList[7].GopY;
            saveData.GopYPhuTro = GopYBindingList[8].GopY;
            SF.Get<MauSanXuatViewModel>().Save(saveData);
            return true;
        }



        public string ValidateInput()
        {
            if (MauSanXuat_DonHangId.SelectedValue == null)
            {
                return "Đơn Hàng";
            }
            return string.Empty;
        }

        private void gridView1_Click(object sender, System.EventArgs e)
        {
            int selectedRow = gridView1.FocusedRowHandle;
            dynamic data = gridView1.GetRow(selectedRow);
            txtGopY.Text = data.GopY;
            lblGopY.Text = data.BoPhan;
            gridView1.FocusedRowHandle = selectedRow;
            txtGopY.Focus();
        }

        private void txtGopY_Leave(object sender, System.EventArgs e)
        {
            var changeData = GopYBindingList.FirstOrDefault(s => s.BoPhan == lblGopY.Text);
            if (changeData != null)
            {
                changeData.GopY = txtGopY.Text;
            }
        }
    }
}
