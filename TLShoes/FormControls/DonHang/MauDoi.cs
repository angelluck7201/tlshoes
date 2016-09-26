using System.ComponentModel;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.DonHang
{
    public partial class ucMauDoi : BaseUserControl
    {
        public static BindingList<MauDoiHinh> MauDoiHinh = new BindingList<MauDoiHinh>();

        public ucMauDoi(MauDoi data = null)
        {
            InitializeComponent();

            MauDoi_DonHangId.ValueMember = "Id";
            MauDoi_DonHangId.DisplayMember = "MaHang";
            MauDoi_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            Init(data);
            if (data != null)
            {
                MauDoiHinh = new BindingList<MauDoiHinh>(SF.Get<MauDoiViewModel>().GetHinhMauDoi(data.Id));
            }

            gridHinhAnh.DataSource = MauDoiHinh;
            CheckButtonLuuHinh();
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var saveData = CRUD.GetFormObject<MauDoi>(FormControls);
            using (var transaction = new TransactionScope())
            {
                SF.Get<MauDoiViewModel>().Save(saveData);

                SF.Get<MauDoiViewModel>().SaveHinh(MauDoiHinh.ToList(), saveData.Id);
                transaction.Complete();
            }

            return true;
        }


        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(MauDoi_MauNgay.Text))
            {
                return lblMauNgay.Text;
            }
            if (string.IsNullOrEmpty(MauDoi_NgayNhan.Text))
            {
                return lblNgayNhan.Text;
            }

            return string.Empty;
        }

        private void gridView1_Click(object sender, System.EventArgs e)
        {
            int selectedRow = gridView1.FocusedRowHandle;
            dynamic data = gridView1.GetRow(selectedRow);
            if (data != null)
            {
                FileHelper.SetImage(HinhHinh, data.HinhAnh);
                GhiChuHinh.Text = data.GhiChu;
                HinhId.Text = data.Id.ToString();
            }
            CheckButtonLuuHinh();
        }

        private void btnSaveHinh_Click(object sender, System.EventArgs e)
        {
            var id = PrimitiveConvert.StringToInt(HinhId.Text);
            var newData = MauDoiHinh.FirstOrDefault(s => s.Id == id);
            if (newData == null)
            {
                newData = new MauDoiHinh();
                newData.Id = TimeHelper.CurrentTimeStamp();
                MauDoiHinh.Add(newData);
            }
            newData.HinhAnh = CRUD.GetControlValue(HinhHinh).ToString();
            newData.GhiChu = GhiChuHinh.Text;
            gridHinhAnh.Refresh();
            ClearHinh();
            CheckButtonLuuHinh();
        }

        private void ClearHinh()
        {
            HinhId.Clear();
            GhiChuHinh.Clear();
            HinhHinh.Image = null;
        }

        private void CheckButtonLuuHinh()
        {
            if (string.IsNullOrEmpty(HinhId.Text))
            {
                btnSaveHinh.Text = "Thêm Hình";
            }
            else
            {
                btnSaveHinh.Text = "Lưu Hình";
            }
        }

    }
}
