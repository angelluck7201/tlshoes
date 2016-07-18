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

namespace TLShoes.FormControls.DonDatHang
{
    public partial class ucDonDatHang : BaseUserControl
    {
        BindingList<DonDatHangViewModel.VatTuDonGia> DatHangVatTuList = new BindingList<DonDatHangViewModel.VatTuDonGia>();
        public ucDonDatHang(TLShoes.DonDatHang data = null)
        {
            InitializeComponent();

            DonDatHang_NhaCungCapId.DataSource = new BindingSource(SF.Get<NhaCungCapViewModel>().GetList(), null);
            DonDatHang_NhaCungCapId.DisplayMember = "TenCongTy";
            DonDatHang_NhaCungCapId.ValueMember = "Id";

            Init(data);
            if (data != null)
            {
                SF.Get<DonDatHangViewModel>().GetChiTietDatHang(data, ref DatHangVatTuList);
            }

            gridNguyenLieu.DataSource = DatHangVatTuList;

            NguyenLieuLookUp.NullText = "";
            NguyenLieuLookUp.Properties.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuLookUp.PopulateColumns();
            NguyenLieuLookUp.ShowHeader = false;
            NguyenLieuLookUp.Columns["Id"].Visible = false;
            NguyenLieuLookUp.Properties.DisplayMember = "Ten";
            NguyenLieuLookUp.Properties.ValueMember = "Id";
            NguyenLieuLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

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
            var saveData = CRUD.GetFormObject<TLShoes.DonDatHang>(FormControls);
            SF.Get<DonDatHangViewModel>().Save(saveData);

            // Save nguyen lieu chi lenh
            foreach (var nguyenlieu in DatHangVatTuList)
            {
                var chitietDonDatHang = new ChiTietDonDatHang();
                chitietDonDatHang.DonDatHangId = saveData.Id;
                chitietDonDatHang.NguyenLieuId = nguyenlieu.NguyenLieuId;
                chitietDonDatHang.NhaCungCapId = nguyenlieu.NhaCungCapId;
                chitietDonDatHang.GhiChu = nguyenlieu.GhiChu;
                chitietDonDatHang.SoLuong = nguyenlieu.SoLuong;
                chitietDonDatHang.SoLuongThuc = nguyenlieu.SoLuongThuc;

                CRUD.DecorateSaveData(chitietDonDatHang);
                SF.Get<DonDatHangViewModel>().Save(chitietDonDatHang);
            }

            // Clear deleted data
            var listChiTietDelete = saveData.ChiTietDonDatHangs;
            foreach (var deleteItem in listChiTietDelete)
            {
                if (DatHangVatTuList.All(s => s.Id != deleteItem.Id))
                {
                    SF.Get<DonDatHangViewModel>().Delete(deleteItem);
                }
            }
            return true;
        }

        public string ValidateInput()
        {
            return string.Empty;
        }


        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            gridViewNguyenLieu.DeleteRow(gridViewNguyenLieu.FocusedRowHandle);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            var nhaCungCapId = DonDatHang_NhaCungCapId.SelectedValue;
            if (nhaCungCapId != null)
            {
                var nhaCungCap = SF.Get<NhaCungCapViewModel>().GetDetail((long)nhaCungCapId);
                foreach (var vatTu in DatHangVatTuList)
                {
                    var nhaCungCapVatTu = nhaCungCap.NhaCungCapVatTus.FirstOrDefault(s => s.NguyenLieuId == vatTu.NguyenLieuId);
                    if (nhaCungCapVatTu != null)
                    {
                        vatTu.NhaCungCapId = (long)nhaCungCapId;
                        vatTu.DonViTien = nhaCungCapVatTu.DonVi;
                        vatTu.DonViTinh = nhaCungCapVatTu.NguyenLieu.DanhMuc.Ten;
                        vatTu.DonGia = (float)nhaCungCapVatTu.DonGia;
                    }
                    else
                    {
                        vatTu.GhiChu = string.Format("Nhà cung cấp {0} hiện không có vật tư này", nhaCungCap.TenCongTy);
                    }
                }
                gridNguyenLieu.RefreshDataSource();
            }
        }
    }
}
