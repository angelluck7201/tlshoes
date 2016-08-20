using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Mvvm.POCO;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauThuDao
{
    public partial class ucMauThuDao : BaseUserControl
    {
        public static BindingList<CommonClass.GopYItem> GopYBindingList = new BindingList<CommonClass.GopYItem>();

        public static List<string> DaoList = new List<string>();
        public static long CurrentDonHang;
        public ucMauThuDao(TLShoes.MauThuDao data)
        {
            InitializeComponent();
            MauThuDao_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            MauThuDao_DonHangId.DisplayMember = "MaHang";
            MauThuDao_DonHangId.ValueMember = "Id";

            GopYBindingList.Clear();
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

            Init(data);

            DaoList = SF.Get<MauThuDaoViewModel>().GetList().Select(s => s.DonHang.MaHang.Split('-')[1]).ToList();
            lblThuDao.Visible = false;
            if (data != null)
            {
                CurrentDonHang = (long) data.DonHangId;
            }
            else
            {
                CurrentDonHang = 0;
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

            var saveData = CRUD.GetFormObject<TLShoes.MauThuDao>(FormControls);

            saveData.GopYVatTu = GopYBindingList[0].GopY;
            saveData.GopYXuongChat = GopYBindingList[1].GopY;
            saveData.GopYXuongDe = GopYBindingList[2].GopY;
            saveData.GopYXuongGo = GopYBindingList[3].GopY;
            saveData.GopYQc = GopYBindingList[4].GopY;
            saveData.GopYCongNghe = GopYBindingList[5].GopY;
            saveData.GopYMau = GopYBindingList[6].GopY;
            saveData.GopYKhoVatTu = GopYBindingList[7].GopY;
            saveData.GopYPhuTro = GopYBindingList[8].GopY;
            SF.Get<MauThuDaoViewModel>().Save(saveData);
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



        private void MauThuDao_DonHangId_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var donHangId = MauThuDao_DonHangId.SelectedValue;
            if (donHangId != null){
                if (CurrentDonHang == (long)donHangId) return;
                var donHang = SF.Get<DonHangViewModel>().GetDetail((long)donHangId);
                if (donHang == null) return;
                if (DaoList.Contains(donHang.MaHang.Split('-')[1]))
                {
                    MauThuDao_NgayBatDau.Enabled = false;
                    MauThuDao_NgayHoanThanh.Enabled = false;
                    lblThuDao.Visible = true;
                }
                else
                {
                    MauThuDao_NgayBatDau.Enabled = true;
                    MauThuDao_NgayHoanThanh.Enabled = true;
                    lblThuDao.Visible = false;
                }
            }
        }

    }
}
