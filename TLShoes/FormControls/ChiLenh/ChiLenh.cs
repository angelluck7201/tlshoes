using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ChiLenh
{
    public partial class ucChiLenh : BaseUserControl
    {
        private int currentRow = -1;
        private BindingList<NguyenLieuChiLenhViewModel.ShowData> NguyenLieuChiLenhList = new BindingList<NguyenLieuChiLenhViewModel.ShowData>();
        public ucChiLenh(TLShoes.ChiLenh data = null)
        {
            InitializeComponent();

            ChiLenh_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            ChiLenh_DonHangId.DisplayMember = "MaHang";
            ChiLenh_DonHangId.ValueMember = "Id";

            if (data != null)
            {
                ChiLenh_DonHangId.SelectedValue = data.DonHangId;
                SF.Get<NguyenLieuChiLenhViewModel>().GetDataSource(NguyenLieuChiLenhList);

                defaultInfo.Controls["Id"].Text = data.Id.ToString();
                defaultInfo.Controls["AuthorId"].Text = data.AuthorId.ToString();
                defaultInfo.Controls["CreatedDate"].Text = TimeHelper.TimestampToString(data.CreatedDate);
                defaultInfo.Controls["ModifiedDate"].Text = TimeHelper.TimestampToString(data.ModifiedDate);
            }
            
           gridControl.DataSource = NguyenLieuChiLenhList;

            MauLookUp.NullText = "";
            MauLookUp.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.MAU).Select(s => new { s.Ten, s.Id }).ToList();
            MauLookUp.PopulateColumns();
            MauLookUp.ShowHeader = false;
            MauLookUp.Columns["Id"].Visible = false;
            MauLookUp.Properties.DisplayMember = "Ten";
            MauLookUp.Properties.ValueMember = "Id";
            MauLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            PhanXuongLookUp.NullText = "";
            PhanXuongLookUp.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_XUONG).Select(s => new { s.Ten, s.Id }).ToList();
            PhanXuongLookUp.PopulateColumns();
            PhanXuongLookUp.ShowHeader = false;
            PhanXuongLookUp.Columns["Id"].Visible = false;
            PhanXuongLookUp.Properties.DisplayMember = "Ten";
            PhanXuongLookUp.Properties.ValueMember = "Id";
            PhanXuongLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

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
            // Save Don hang
            var saveData = SF.Get<ChiLenhViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new TLShoes.ChiLenh();
            }

            saveData.DonHangId= (long)ChiLenh_DonHangId.SelectedValue;
            CRUD.DecorateSaveData(saveData);
            SF.Get<ChiLenhViewModel>().Save(saveData);
            id = saveData.Id;

            // Save Chi Tiet Don Hang
            foreach (var chitiet in NguyenLieuChiLenhList)
            {
                //chitiet. = id;
                CRUD.DecorateSaveData(chitiet);
                SF.Get<ChiTietDonHangViewModel>().Save(chitiet);
            }
            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }

        private void gridView_Click(object sender, EventArgs e)
        {
            var columnName = gridView.FocusedColumn.FieldName;
            if (columnName == "NguyenLieu")
            {
                currentRow = gridView.FocusedRowHandle;
                var data = gridView.GetRow(currentRow) as NguyenLieuChiLenh;

                var defaultForm = new ChiTietNguyenLieuForm(this, data);
                defaultForm.Show();
            }
        }

        public void OnClosePopup(List<ChiTietNguyenLieu> data = null)
        {
            if (data != null)
            {
                gridView.SetRowCellValue(currentRow, "NguyenLieu", SF.Get<NguyenLieuChiLenhViewModel>().NguyenLieuFormat(data));

                gridControl.Refresh();
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.ParentForm.Close();
            }
        }

        public override void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ClearData();
            }
        }

        public override void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}

