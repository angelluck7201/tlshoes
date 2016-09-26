using System;
using System.ComponentModel;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.DanhGia
{
    public partial class ucDanhGia : BaseUserControl
    {
        BindingList<ChiTietDanhGia> ChiTietDanhGia = new BindingList<ChiTietDanhGia>();
        public ucDanhGia(TLShoes.DanhGia data = null)
        {
            InitializeComponent();

            DanhGia_DonDatHangId.DisplayMember = "SoDH";
            DanhGia_DonDatHangId.ValueMember = "Id";
            DanhGia_DonDatHangId.DataSource = new BindingSource(SF.Get<DonDatHangViewModel>().GetList(), null);

            DanhGia_MauDanhGiaId.DisplayMember = "TenMau";
            DanhGia_MauDanhGiaId.ValueMember = "Id";
            DanhGia_MauDanhGiaId.DataSource = new BindingSource(SF.Get<MauDanhGiaViewModel>().GetList(), null);

            Init(data);
            if (data != null)
            {
                ChiTietDanhGia = new BindingList<ChiTietDanhGia>(data.ChiTietDanhGias.ToList());
                DanhGia_MauDanhGiaId.Enabled = false;
            }

            gridTieuChi.DataSource = ChiTietDanhGia;


            TieuChiLookUp.NullText = "";
            TieuChiLookUp.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.TIEU_CHI_QC).Select(s => new { s.Ten, s.Id }).ToList();
            TieuChiLookUp.PopulateColumns();
            TieuChiLookUp.ShowHeader = false;
            TieuChiLookUp.Columns["Id"].Visible = false;
            TieuChiLookUp.Properties.DisplayMember = "Ten";
            TieuChiLookUp.Properties.ValueMember = "Id";
            TieuChiLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            LoadTieuChi();
            LoadDonHang();
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
            var saveData = CRUD.GetFormObject<TLShoes.DanhGia>(FormControls);

            using (var transaction = new TransactionScope())
            {
                SF.Get<DanhGiaViewModel>().Save(saveData);

                foreach (var chitiet in ChiTietDanhGia)
                {
                    chitiet.DanhGiaId = saveData.Id;
                    CRUD.DecorateSaveData(chitiet);
                    SF.Get<DanhGiaViewModel>().Save(chitiet);
                }

                // Clear deleted data
                var listChiTietDelete = saveData.ChiTietDanhGias;
                foreach (var deleteItem in listChiTietDelete)
                {
                    if (ChiTietDanhGia.All(s => s.Id != deleteItem.Id))
                    {
                        SF.Get<DanhGiaViewModel>().Delete(deleteItem);
                    }
                }
                transaction.Complete();
            }

            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }

        private void LoadTieuChi()
        {
            var mauDanhGiaId = DanhGia_MauDanhGiaId.SelectedValue;
            if (mauDanhGiaId != null)
            {
                var mauDanhGia = SF.Get<MauDanhGiaViewModel>().GetDetail((long)mauDanhGiaId);
                if (mauDanhGia != null)
                {

                    var tieuChiList = mauDanhGia.ChiTietMauDanhGias.Select(s => s.DanhMuc);
                    foreach (var tieuChi in tieuChiList)
                    {
                        if (ChiTietDanhGia.All(s => s.DanhGiaId != tieuChi.Id))
                        {
                            var danhgia = new ChiTietDanhGia();
                            danhgia.TieuChiId = tieuChi.Id;
                            ChiTietDanhGia.Add(danhgia);
                        }
                    }
                }
            }
        }

        private void LoadDonHang()
        {
            var donHangId = DanhGia_DonDatHangId.SelectedValue;
            if (donHangId != null)
            {
                var donHang = SF.Get<DonDatHangViewModel>().GetDetail((long)donHangId);
                if (donHang != null)
                {
                    SoLuongDat.Text = donHang.ChiTietDonDatHangs.Sum(s => s.SoLuong).ToString();
                }
            }
        }

        private void DanhGia_DonDatHangId_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void DanhGia_MauDanhGiaId_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTieuChi();
        }


    }
}
