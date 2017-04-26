using System;
using System.ComponentModel;
using System.Globalization;
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
        readonly BindingList<ChiTietDanhGia> _chiTietDanhGia = new BindingList<ChiTietDanhGia>();
        private readonly TLShoes.DanhGia _domainData;

        public ucDanhGia(TLShoes.DanhGia data = null)
        {
            InitializeComponent();

            var lstDonDatHang = SF.Get<DonDatHangViewModel>().GetList();
            SetComboboxDataSource(DanhGia_DonDatHangId,lstDonDatHang,"SoDH");

            var lstMauDanhGia = SF.Get<MauDanhGiaViewModel>().GetList();
            SetComboboxDataSource(DanhGia_MauDanhGiaId, lstMauDanhGia, "TenMau");

            _domainData = data;
            Init(data);
            if (data != null)
            {
                _chiTietDanhGia = new BindingList<ChiTietDanhGia>(data.ChiTietDanhGias.ToList());
                DanhGia_MauDanhGiaId.Enabled = false;
            }

            gridTieuChi.DataSource = _chiTietDanhGia;

            var lstTieuChi = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.TIEU_CHI_QC);
            SetRepositoryItem(TieuChiLookUp, lstTieuChi,"Ten");

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
            var saveData = CRUD.GetFormObject(FormControls, _domainData);

            using (var transaction = new TransactionScope())
            {
                CRUD.DecorateSaveData(saveData, _domainData == null);
                SF.Get<DanhGiaViewModel>().Save(saveData);

                foreach (var chitiet in _chiTietDanhGia)
                {
                    chitiet.DanhGiaId = saveData.Id;
                    CRUD.DecorateSaveData(chitiet);
                    SF.Get<DanhGiaViewModel>().Save(chitiet);
                }

                // Clear deleted data
                var listChiTietDelete = saveData.ChiTietDanhGias;
                foreach (var deleteItem in listChiTietDelete)
                {
                    if (_chiTietDanhGia.All(s => s.Id != deleteItem.Id))
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
                        if (_chiTietDanhGia.All(s => s.DanhGiaId != tieuChi.Id))
                        {
                            var danhgia = new ChiTietDanhGia();
                            danhgia.TieuChiId = tieuChi.Id;
                            _chiTietDanhGia.Add(danhgia);
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
                    SoLuongDat.Text = donHang.ChiTietDonDatHangs.Sum(s => s.SoLuong).ToString(CultureInfo.InvariantCulture);
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
