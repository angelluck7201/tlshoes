using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauTest
{
    public partial class ucMauTest : UserControl
    {
        public ucMauTest(TLShoes.MauTest data)
        {
            InitializeComponent();
            MauTest_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            MauTest_DonHangId.DisplayMember = "MaHang";
            MauTest_DonHangId.ValueMember = "Id";

            MauTest_PhanLoaiTestHoaId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            MauTest_PhanLoaiTestHoaId.DisplayMember = "Ten";
            MauTest_PhanLoaiTestHoaId.ValueMember = "Id";

            MauTest_PhanLoaiTestLyId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_LOAI_TEST), null);
            MauTest_PhanLoaiTestLyId.DisplayMember = "Ten";
            MauTest_PhanLoaiTestLyId.ValueMember = "Id";


            if (data != null)
            {
                MauTest_DonHangId.SelectedValue = data.DonHangId;
                MauTest_KetQuaTestHoa.Text = data.KetQuaTestHoa;
                MauTest_PhanLoaiTestHoaId.SelectedValue = data.PhanLoaiTestHoaId;
                MauTest_NgayKetQuaTestHoa.Text = TimeHelper.TimestampToString(data.NgayKetquaTestHoa);

                MauTest_KetQuaTestLy.Text = data.KetQuaTestLy;
                MauTest_PhanLoaiTestLyId.SelectedValue = data.PhanLoaiTestLyId;
                MauTest_NgayKetQuaTestLy.Text = TimeHelper.TimestampToString(data.NgayKetquaTestLy);

                defaultInfo.Controls["Id"].Text = data.Id.ToString();
                defaultInfo.Controls["AuthorId"].Text = data.AuthorId.ToString();
                defaultInfo.Controls["CreatedDate"].Text = TimeHelper.TimestampToString(data.CreatedDate);
                defaultInfo.Controls["ModifiedDate"].Text = TimeHelper.TimestampToString(data.ModifiedDate);
            }
        }

        public bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var id = CommonHelper.StringToInt(defaultInfo.Controls["Id"].Text);

            var saveData = SF.Get<MauTestViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new TLShoes.MauTest();
            }

            saveData.DonHangId = (long)MauTest_DonHangId.SelectedValue;
            saveData.KetQuaTestHoa = MauTest_KetQuaTestHoa.Text;
            saveData.NgayKetquaTestHoa = TimeHelper.DateTimeToTimeStamp(MauTest_NgayKetQuaTestHoa.Value);
            saveData.PhanLoaiTestHoaId = (long)MauTest_PhanLoaiTestHoaId.SelectedValue;

            saveData.KetQuaTestLy = MauTest_KetQuaTestLy.Text;
            saveData.NgayKetquaTestLy = TimeHelper.DateTimeToTimeStamp(MauTest_NgayKetQuaTestLy.Value);
            saveData.PhanLoaiTestLyId = (long)MauTest_PhanLoaiTestLyId.SelectedValue;

            CRUD.DecorateSaveData(saveData);
            SF.Get<MauTestViewModel>().Save(saveData);
            return true;
        }

        public void ClearData()
        {
            defaultInfo.Controls["Id"].Text = "";
            defaultInfo.Controls["AuthorId"].Text = "";
            defaultInfo.Controls["CreatedDate"].Text = "";
            defaultInfo.Controls["ModifiedDate"].Text = "";
            MauTest_DonHangId.SelectedIndex = 0;
            MauTest_KetQuaTestHoa.Text = "";
            MauTest_PhanLoaiTestHoaId.SelectedIndex = 0;
            MauTest_NgayKetQuaTestHoa.Text = "";

            MauTest_KetQuaTestLy.Text = "";
            MauTest_PhanLoaiTestLyId.SelectedIndex = 0;
            MauTest_NgayKetQuaTestLy.Text = "";
        }

        public string ValidateInput()
        {
           return string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.ParentForm.Close();
            }
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ClearData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
