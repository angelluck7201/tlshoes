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
        public BindingList<MauDoiHinh> MauDoiHinh = new BindingList<MauDoiHinh>();
        private MauDoiHinh _currentHinh;
        private MauDoi _currentData;

        public ucMauDoi(MauDoi data = null)
        {
            InitializeComponent();
            _currentData = data;

            var lstDonhang = SF.Get<DonHangViewModel>().GetList();
            SetComboboxDataSource(MauDoi_DonHangId, lstDonhang, "MaHang");

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
                MessageBox.Show(validateResult);
                return false;
            }
            var saveData = CRUD.GetFormObject(FormControls, _currentData);
            using (var transaction = new TransactionScope())
            {
                SF.Get<MauDoiViewModel>().Save(saveData);
                SF.Get<MauDoiViewModel>().SaveHinh(saveData, MauDoiHinh.ToList(), saveData.Id);
                transaction.Complete();
            }

            return true;
        }


        public string ValidateInput()
        {
            return string.Empty;
        }

        private void gridView1_Click(object sender, System.EventArgs e)
        {
            int selectedRow = gridView1.FocusedRowHandle;
            dynamic data = gridView1.GetRow(selectedRow);
            if (data != null)
            {
                _currentHinh = data;
                FileHelper.SetImage(HinhHinh, data.HinhAnh);
                GhiChuHinh.Text = data.GhiChu;
            }
            else
            {
                ClearHinh();
            }
            CheckButtonLuuHinh();
        }

        private void btnSaveHinh_Click(object sender, System.EventArgs e)
        {
            var newData = MauDoiHinh.FirstOrDefault(s => s == _currentHinh);
            if (newData == null) return;

            if (HinhHinh.Image != null)
            {
                newData.GhiChu = GhiChuHinh.Text;
                newData.Hinh = HinhHinh.Image;

                gridHinhAnh.RefreshDataSource();
                ClearHinh();
                CheckButtonLuuHinh();
            }
            else
            {
                MessageBox.Show("Chưa upload hình!");
            }
        }

        private void btnAddHinh_Click(object sender, System.EventArgs e)
        {
            if (HinhHinh.Image != null)
            {
                var newData = new MauDoiHinh();
                newData.Id = TimeHelper.CurrentTimeStamp();
                MauDoiHinh.Add(newData);

                newData.Hinh = HinhHinh.Image;
                newData.GhiChu = GhiChuHinh.Text;
                gridHinhAnh.Refresh();
                ClearHinh();
                CheckButtonLuuHinh();
            }
            else
            {
                MessageBox.Show("Chưa upload hình!");
            }
        }

        private void ClearHinh()
        {
            _currentHinh = null;
            GhiChuHinh.Clear();
            HinhHinh.Image = null;
        }

        private void CheckButtonLuuHinh()
        {
            btnSaveHinh.Enabled = true;
            btnDelete.Enabled = true;
            if (_currentHinh == null)
            {
                btnSaveHinh.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (_currentHinh != null)
            {
                MauDoiHinh.Remove(_currentHinh);
                gridHinhAnh.Refresh();
                ClearHinh();
                CheckButtonLuuHinh();
            }
        }



    }
}
