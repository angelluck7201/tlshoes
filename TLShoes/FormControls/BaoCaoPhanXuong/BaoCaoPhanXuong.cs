using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.BaoCaoPhanXuong
{
    public partial class ucBaoCaoPhanXuong : BaseUserControl
    {
        private TLShoes.BaoCaoPhanXuong _domainData;
        public ucBaoCaoPhanXuong(TLShoes.BaoCaoPhanXuong data)
        {
            InitializeComponent();

            var lstDonHang = SF.Get<DonHangViewModel>().GetList();
            SetComboboxDataSource(BaoCaoPhanXuong_DonHangId, lstDonHang, "MaHang");

            SetComboboxDataSource(BaoCaoPhanXuong_PhanXuong, Define.PhanXuongDict);

            _domainData = data;
            Init(data);
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }

            using (var transaction = new TransactionScope())
            {
                var saveData = CRUD.GetFormObject(FormControls, _domainData);
                saveData.LuyKe = SF.Get<BaoCaoPhanXuongViewModel>().GetList(saveData.DonHangId.GetValueOrDefault(), saveData.PhanXuong, saveData.BaoCaoNgay).Sum(s => s.SanLuongThucHien);
                SF.Get<BaoCaoPhanXuongViewModel>().Save(saveData);

                // Nếu update các phân xưởng củ thì sẽ check lại các phân xưởng có ngày lớn hơn để cập nhật lại lũy kế
                var lstGreaterBaoCao = SF.Get<BaoCaoPhanXuongViewModel>().GetList(saveData.DonHangId.GetValueOrDefault(), saveData.PhanXuong, saveData.BaoCaoNgay, false);
                foreach (var baoCaoPhanXuong in lstGreaterBaoCao)
                {
                    CRUD.DecorateSaveData(baoCaoPhanXuong);
                    baoCaoPhanXuong.LuyKe = SF.Get<BaoCaoPhanXuongViewModel>().GetList(baoCaoPhanXuong.DonHangId.GetValueOrDefault(), baoCaoPhanXuong.PhanXuong, baoCaoPhanXuong.BaoCaoNgay).Sum(s => s.SanLuongThucHien);
                    SF.Get<BaoCaoPhanXuongViewModel>().Save(baoCaoPhanXuong);
                }
                transaction.Complete();
            }

            return true;
        }


        public string ValidateInput()
        {
            var selectedPhanXuong = BaoCaoPhanXuong_PhanXuong.SelectedValue;
            if (selectedPhanXuong == null)
            {
                return "Không thể để trống Phân Xưởng!";
            }

            var selectedDonhang = BaoCaoPhanXuong_DonHangId.SelectedValue;
            if (selectedDonhang == null)
            {
                return "Không thể để trống Đơn Hàng!";
            }


            // Check duplicate baocao in date
            var checkedDate = BaoCaoPhanXuong_BaoCaoNgay.Value.ToShortDateString();
            var phanXuong = selectedPhanXuong.ToString();
            var isDuplicate = SF.Get<BaoCaoPhanXuongViewModel>().IsDulicateReportInDate((long)selectedDonhang, phanXuong, checkedDate);
            if (isDuplicate)
            {
                return string.Format("Báo cáo ngày {0} của phân xưởng {1} đã được tạo nên không thể tạo thêm!", checkedDate, phanXuong);
            }

            return string.Empty;
        }

        private void BaoCaoPhanXuong_SanLuongKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormValidate.ValidateInputNumber(sender, e);
        }

        private void BaoCaoPhanXuong_SanLuongThucHien_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormValidate.ValidateInputNumber(sender, e);
        }
    }
}
