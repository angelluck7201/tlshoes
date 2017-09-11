using System;
using System.Collections.Generic;
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


            using (var transaction = new TransactionScope())
            {
                // Save Don hang
                var saveData = CRUD.GetFormObject(FormControls, _domainData);
                saveData.SoLuongKem = _chiTietDanhGia.Sum(s => s.SoLuongKem);
                CRUD.DecorateSaveData(saveData);
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
                        // Add them cac tieu chi khong co trong list tieu chi hien tai 
                        // Xu ly cho truong hop co update them moi tieu chi danh gia trong mau danh gia 
                        // Chi xu ly voi cac tieu chi duoc them vao, van giu nguyen neu cac tieu chi bi xoa di
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
                    SoLuongDat.Text = donHang.SoLuongDat.ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void btnChonDDH_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void btnChonMDG_Click(object sender, EventArgs e)
        {
            if (_chiTietDanhGia != null && _chiTietDanhGia.Count > 0)
            {
                var confirmDialog = MessageBox.Show("Đơn đặt hàng này hiện tại đã được đánh giá rồi. Nếu thay đổi mẫu đánh giá khác thì những đánh giá hiện tại sẽ bị thay thế. Bạn có chắc không?",
                    "Xác nhận đổi mẫu đánh giá", MessageBoxButtons.YesNo);
                if (confirmDialog == DialogResult.Yes)
                {
                    _chiTietDanhGia.Clear();
                    LoadTieuChi();
                }
            }
            else
            {
                LoadTieuChi();
            }
        }
    }
}
