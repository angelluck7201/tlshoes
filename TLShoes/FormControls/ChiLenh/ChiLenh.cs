using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ChiLenh
{
    public partial class ucChiLenh : BaseUserControl
    {
        private BindingList<NguyenLieuChiLenhViewModel.ShowData> NguyenLieuChiLenhList = new BindingList<NguyenLieuChiLenhViewModel.ShowData>();
        private BindingList<ChiTietNguyenLieu> ChiTietNguyenLieuList = new BindingList<ChiTietNguyenLieu>();
        private static int TongDonHang = 0;

        public ucChiLenh(TLShoes.ChiLenh data = null)
        {
            InitializeComponent();

            ChiLenh_DonHangId.DisplayMember = "MaHang";
            ChiLenh_DonHangId.ValueMember = "Id";
            ChiLenh_DonHangId.DataSource = new BindingSource(SF.Get<DonHangViewModel>().GetList(), null);

            NguyenLieuChiLenh_PhanXuongId.DisplayMember = "Ten";
            NguyenLieuChiLenh_PhanXuongId.ValueMember = "Id";
            NguyenLieuChiLenh_PhanXuongId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.PHAN_XUONG), null);

            NguyenLieuChiLenh_MauId.DisplayMember = "Ten";
            NguyenLieuChiLenh_MauId.ValueMember = "Id";
            NguyenLieuChiLenh_MauId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.MAU), null);

            NguyenLieuChiLenh_ChiTietId.DisplayMember = "Ten";
            NguyenLieuChiLenh_ChiTietId.ValueMember = "Id";
            NguyenLieuChiLenh_ChiTietId.DataSource = new BindingSource(SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.CHI_TIET), null);

            Init(data);

            if (data != null)
            {
                SF.Get<NguyenLieuChiLenhViewModel>().GetDataSource(data.Id, ref NguyenLieuChiLenhList);
                SF.Get<NhatKyThayDoiViewModel>().GetDataSource(gridNhatKy, Define.ModelType.CHILENH, data.Id);
            }

            gridControl.DataSource = NguyenLieuChiLenhList;
            gridNguyenLieu.DataSource = ChiTietNguyenLieuList;

            NguyenLieuLookUp.NullText = "";
            NguyenLieuLookUp.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuLookUp.PopulateColumns();
            NguyenLieuLookUp.ShowHeader = false;
            NguyenLieuLookUp.Columns["Id"].Visible = false;
            NguyenLieuLookUp.DisplayMember = "Ten";
            NguyenLieuLookUp.ValueMember = "Id";
            NguyenLieuLookUp.TextEditStyle = TextEditStyles.DisableTextEditor;

            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }

            // Save Don hang
            var saveData = CRUD.GetFormObject<TLShoes.ChiLenh>(FormControls);
            SF.Get<ChiLenhViewModel>().Save(saveData);

            // Save nguyen lieu chi lenh
            foreach (var nguyenlieu in NguyenLieuChiLenhList)
            {
                var nguyenlieuChiLenh = new NguyenLieuChiLenh();
                nguyenlieuChiLenh.Id = nguyenlieu.Id;
                nguyenlieuChiLenh.PhanXuongId = nguyenlieu.PhanXuongId;
                nguyenlieuChiLenh.ChiLenhId = saveData.Id;
                nguyenlieuChiLenh.ChiTietId = nguyenlieu.ChiTietId;
                nguyenlieuChiLenh.QuyCach = nguyenlieu.QuyCach;
                nguyenlieuChiLenh.MauId = nguyenlieu.MauId;
                nguyenlieuChiLenh.DinhMucChuan = nguyenlieu.DinhMucChuan;
                nguyenlieuChiLenh.DinhMucThuc = nguyenlieu.DinhMucThuc;

                CRUD.DecorateSaveData(nguyenlieuChiLenh);
                SF.Get<NguyenLieuChiLenhViewModel>().Save(nguyenlieuChiLenh);

                // Save chi tiet nguyen lieu
                var currentItem = new List<long>();
                foreach (var chitiet in nguyenlieu.ChiTietNguyenLieuList)
                {
                    var chitietNguyenLieu = new ChiTietNguyenLieu();
                    chitietNguyenLieu.Id = chitiet.Id;
                    chitietNguyenLieu.ChiTietNguyenLieuId = chitiet.ChiTietNguyenLieuId;
                    chitietNguyenLieu.NguyenLieuChiLenhId = nguyenlieuChiLenh.Id;
                    chitietNguyenLieu.GhiChu = chitiet.GhiChu;
                    CRUD.DecorateSaveData(chitietNguyenLieu);
                    SF.Get<ChiTietNguyenLieuViewModel>().Save(chitietNguyenLieu);
                    currentItem.Add(chitietNguyenLieu.Id);
                }

                // Clear deleted data
                var listChiTietDelete = SF.Get<ChiTietNguyenLieuViewModel>().GetList().Where(s => s.NguyenLieuChiLenhId == nguyenlieuChiLenh.Id);
                foreach (var deleteItem in listChiTietDelete)
                {
                    if (!currentItem.Contains(deleteItem.Id))
                    {
                        SF.Get<ChiTietNguyenLieuViewModel>().Delete(deleteItem.Id);
                    }
                }
            }

            var nhatKyThayDoi = new NhatKyThayDoi();
            nhatKyThayDoi.GhiChu = LyDoThayDoi.Text;
            nhatKyThayDoi.ModelName = Define.ModelType.CHILENH.ToString();
            nhatKyThayDoi.ItemId = saveData.Id;
            CRUD.DecorateSaveData(nhatKyThayDoi);
            SF.Get<NhatKyThayDoiViewModel>().Save(nhatKyThayDoi);
            return true;
        }

        public string ValidateInput()
        {
            if (!string.IsNullOrEmpty(defaultInfo.Controls["Id"].Text))
            {
                if (string.IsNullOrEmpty(LyDoThayDoi.Text))
                {
                    return "lý do thay đổi";
                }
            }
            return string.Empty;
        }

        private void gridView_Click(object sender, EventArgs e)
        {
            var data = gridView.GetRow(gridView.FocusedRowHandle) as NguyenLieuChiLenhViewModel.ShowData;
            NguyenLieuChiLenh_ChiTietId.SelectedValue = data.ChiTietId;
            NguyenLieuChiLenh_DinhMucChuan.Text = data.DinhMucChuan.ToString();
            NguyenLieuChiLenh_DinhMucThuc.Text = data.DinhMucThuc.ToString();
            NguyenLieuChiLenh_MauId.SelectedValue = data.MauId;
            NguyenLieuChiLenh_QuyCach.Text = data.QuyCach;
            NguyenLieuChiLenh_PhanXuongId.SelectedValue = data.PhanXuongId;
            ChiTietNguyenLieuList = new BindingList<ChiTietNguyenLieu>(data.ChiTietNguyenLieuList.ToList());

            gridNguyenLieu.DataSource = ChiTietNguyenLieuList;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var saveData = CRUD.GetFormObject<NguyenLieuChiLenh>(FormControls);
            var tenNguyenLieu = SF.Get<NguyenLieuChiLenhViewModel>().NguyenLieuFormat(ChiTietNguyenLieuList.ToList());

            var chitiet = NguyenLieuChiLenhList.FirstOrDefault(s => s.ChiTietId == saveData.ChiTietId);
            if (chitiet == null)
            {
                chitiet = new NguyenLieuChiLenhViewModel.ShowData();
                NguyenLieuChiLenhList.Add(chitiet);
            }
            chitiet.ChiTiet = SF.Get<DanhMucViewModel>().GetDetail((long)saveData.ChiTietId).Ten;
            chitiet.PhanXuong = SF.Get<DanhMucViewModel>().GetDetail((long)saveData.PhanXuongId).Ten;
            chitiet.Mau = SF.Get<DanhMucViewModel>().GetDetail((long)saveData.MauId).Ten;
            chitiet.NguyenLieu = tenNguyenLieu;
            chitiet.QuyCach = saveData.QuyCach;
            chitiet.DinhMucChuan = (float)saveData.DinhMucChuan;
            chitiet.DinhMucThuc = (float)saveData.DinhMucThuc;
            chitiet.ChiTietNguyenLieuList = new BindingList<ChiTietNguyenLieu>(ChiTietNguyenLieuList.ToList());
            chitiet.ChiTietId = saveData.ChiTietId;
            chitiet.PhanXuongId = saveData.PhanXuongId;
            chitiet.MauId = saveData.MauId;

            gridControl.RefreshDataSource();

            ChiTietNguyenLieuList.Clear();
            ClearData("NguyenLieuChiLenh");
        }

        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewNguyenLieu.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }

        private void NguyenLieuChiLenh_DinhMucChuan_TextChanged(object sender, EventArgs e)
        {
            var editDinhMucChuan = PrimitiveConvert.StringToFloat(NguyenLieuChiLenh_DinhMucChuan.Text);
            NguyenLieuChiLenh_DinhMucThuc.Text = (TongDonHang * editDinhMucChuan / 1000f).ToString();
        }

        private void ChiLenh_DonHangId_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ChiLenh_DonHangId.SelectedValue != null)
            {
                TongDonHang = SF.Get<DonHangViewModel>().TongDonHang((long)ChiLenh_DonHangId.SelectedValue);
                lblDinhMucThuc.Text = string.Format("{0} {1}", "Định Mức", TongDonHang);
                gridView.Columns[7].Caption = lblDinhMucThuc.Text;
            }
        }
    }
}

