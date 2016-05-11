using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.BangThongSo
{
    public partial class ucBangThongSo : BaseUserControl
    {
        public static BindingList<ChiTietThongSo> ChiTietThongSo = new BindingList<ChiTietThongSo>();
        public ucBangThongSo(TLShoes.BangThongSo data = null)
        {
            InitializeComponent();

            BangThongSo_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);
            BangThongSo_DonHangId.DisplayMember = "MaHang";
            BangThongSo_DonHangId.ValueMember = "Id";

            BangThongSo_MaPhomId.DataSource = new BindingSource(SF.Get<NguyenLieuViewModel>().GetList().Where(s => s.LoaiNguyenLieu.Ten == "PHOM").ToList(), null);
            BangThongSo_MaPhomId.DisplayMember = "MaNguyenLieu";
            BangThongSo_MaPhomId.ValueMember = "Id";

            BangThongSo_PhanXuongId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.PHAN_XUONG), null);
            BangThongSo_PhanXuongId.DisplayMember = "Ten";
            BangThongSo_PhanXuongId.ValueMember = "Id";

            if (data != null)
            {
                InitFormData(data);
                //BangThongSo_DonHangId.SelectedValue = data.DonHangId;
                //BangThongSo_MaPhomId.SelectedValue = data.MaPhomId;
                //BangThongSo_PhanXuongId.SelectedValue = data.PhanXuongId;
                //BangThongSo_NgayKy.Text = TimeHelper.TimestampToString(data.NgayKy);
                //BangThongSo_NgayXacNhan.Text = TimeHelper.TimestampToString(data.NgayXacNhan);

                //ChiTietThongSo = new BindingList<ChiTietThongSo>(data.ChiTietThongSoes.ToList());
                //defaultInfo.Controls["Id"].Text = data.Id.ToString();
                //defaultInfo.Controls["AuthorId"].Text = data.AuthorId.ToString();
                //defaultInfo.Controls["CreatedDate"].Text = TimeHelper.TimestampToString(data.CreatedDate);
                //defaultInfo.Controls["ModifiedDate"].Text = TimeHelper.TimestampToString(data.ModifiedDate);
            }

            repositoryItemLookUpEdit1.NullText = "";
            repositoryItemLookUpEdit1.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(DanhMucViewModel.LoaiDanhMuc.CHI_TIET).Select(s => new { s.Ten, s.Id }).ToList();
            repositoryItemLookUpEdit1.PopulateColumns();
            repositoryItemLookUpEdit1.ShowHeader = false;
            repositoryItemLookUpEdit1.Columns["Id"].Visible = false;
            repositoryItemLookUpEdit1.Properties.DisplayMember = "Ten";
            repositoryItemLookUpEdit1.Properties.ValueMember = "Id";
            repositoryItemLookUpEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            gridControl.DataSource = ChiTietThongSo;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var test = CRUD.GetFormObject<TLShoes.BangThongSo>(this);
            var id = CommonHelper.StringToInt(defaultInfo.Controls["Id"].Text);
            // Save Don hang
            var saveData = SF.Get<BangThongSoViewModel>().GetDetail(id);
            if (saveData == null)
            {
                saveData = new TLShoes.BangThongSo();
            }

            saveData.DonHangId = (long)BangThongSo_DonHangId.SelectedValue;
            saveData.MaPhomId = (long)BangThongSo_MaPhomId.SelectedValue;
            saveData.PhanXuongId = (long)BangThongSo_PhanXuongId.SelectedValue;
            saveData.NgayKy = TimeHelper.DateTimeToTimeStamp(BangThongSo_NgayKy.Value);
            saveData.NgayXacNhan = TimeHelper.DateTimeToTimeStamp(BangThongSo_NgayXacNhan.Value);
            CRUD.DecorateSaveData(saveData);
            SF.Get<BangThongSoViewModel>().Save(saveData);
            id = saveData.Id;

            // Save Chi Tiet Don Hang
            foreach (var chitiet in ChiTietThongSo)
            {
                chitiet.BangThongSoId = id;
                CRUD.DecorateSaveData(chitiet);
                SF.Get<ChiTietThongSoViewModel>().Save(chitiet);
            }

            return true;
        }

        //public override void ClearData()
        //{
        //    defaultInfo.Controls["Id"].Text = "";
        //    defaultInfo.Controls["AuthorId"].Text = "";
        //    defaultInfo.Controls["CreatedDate"].Text = "";
        //    defaultInfo.Controls["ModifiedDate"].Text = "";

        //    BangThongSo_PhanXuongId.SelectedIndex = 0;
        //    BangThongSo_DonHangId.SelectedIndex = 0;
        //    BangThongSo_MaPhomId.SelectedIndex = 0;
        //    BangThongSo_NgayKy.Text = "";
        //    BangThongSo_NgayXacNhan.Text = "";

        //    ChiTietThongSo.Clear();
        //}
    }
}
