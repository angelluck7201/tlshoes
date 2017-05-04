using System.Collections.Generic;
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
        private MauDoi _domainData;

        public ucMauDoi(MauDoi data = null)
        {
            InitializeComponent();
            _domainData = data;

            var lstDonhang = new List<TLShoes.DonHang>();
            if (data != null && !data.DonHang.IsAvailable)
            {
                lstDonhang.Add(data.DonHang);
            }
            else
            {
                lstDonhang = SF.Get<DonHangViewModel>().GetListAvailable();
            }
            SetComboboxDataSource(MauDoi_DonHangId, lstDonhang, "MaHang");

            Init(data);
            if (data != null)
            {
                MauDoiHinh = new BindingList<MauDoiHinh>(SF.Get<MauDoiViewModel>().GetHinhMauDoi(data.Id));
            }

            gridHinhAnh.DataSource = MauDoiHinh;
            CheckButtonLuuHinh();
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
                MessageBox.Show(validateResult);
                return false;
            }
            var saveData = CRUD.GetFormObject(FormControls, _domainData);
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
            if (MauDoi_DonHangId.SelectedValue == null)
            {
                return string.Format("{0} {1}!", "Không được phép để trống", "Đơn Hàng");
            }
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
