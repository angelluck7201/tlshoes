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
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.DonDatHang
{
    public partial class ucDonDatHang : BaseUserControl
    {
        BindingList<DonDatHangViewModel.VatTuDonGia> DatHangVatTuList = new BindingList<DonDatHangViewModel.VatTuDonGia>();
        List<TLShoes.ToTrinh> ToTrinhList = new List<TLShoes.ToTrinh>();
        List<long> SelectedList = new List<long>();

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
            ToTrinhList = SF.Get<ToTrinhViewModel>().GetList();
            SF.Get<ToTrinhViewModel>().GetDataSource(gridToTrinh);

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

            // Update danh gia nha cung cap
            // ToDo dua chay vao trong thread
            if (DonDatHang_NhaCungCapId.SelectedValue != null)
            {
                var nhaCungCap = SF.Get<NhaCungCapViewModel>().GetDetail((long)DonDatHang_NhaCungCapId.SelectedValue);
                if (nhaCungCap != null)
                {
                    var donHangNhaCungCap = SF.Get<DonDatHangViewModel>().GetListByNhaCungCap(nhaCungCap.Id);
                    nhaCungCap.Gia = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.Gia);
                    nhaCungCap.DungThoiGian = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.DungThoiGian);
                    nhaCungCap.DungYeuCauKyThuat = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.DungYeuCauKyThuat);
                    nhaCungCap.DungMau = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.DungMau);
                    nhaCungCap.Khac = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.Khac);
                    nhaCungCap.DatTestLy = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.DatTestLy);
                    nhaCungCap.DatTestHoa = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.DatTestHoa);
                    nhaCungCap.DichVuGiaoHang = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.DichVuGiaoHang);
                    nhaCungCap.DichVuHauMai = (int)donHangNhaCungCap.Where(s => s.Gia > 0).Average(s => s.DichVuHauMai);
                    SF.Get<NhaCungCapViewModel>().Save(nhaCungCap);
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
                        vatTu.GhiChu = nhaCungCapVatTu.NguyenLieu.GhiChu;
                    }
                    else
                    {
                        vatTu.GhiChu = string.Format("Nhà cung cấp {0} hiện không có vật tư này", nhaCungCap.TenCongTy);
                    }
                }
                gridNguyenLieu.RefreshDataSource();
            }
        }



        #region Update total assessment

        private void UpdateTotalAssessment()
        {
            var updateData = new List<decimal>();
            if (DonDatHang_DungThoiGian.Rating > 0)
            {
                updateData.Add(DonDatHang_DungThoiGian.Rating);
            }
            if (DonDatHang_DatTestHoa.Rating > 0)
            {
                updateData.Add(DonDatHang_DatTestHoa.Rating);
            }
            if (DonDatHang_DatTestLy.Rating > 0)
            {
                updateData.Add(DonDatHang_DatTestLy.Rating);
            }
            if (DonDatHang_DichVuGiaoHang.Rating > 0)
            {
                updateData.Add(DonDatHang_DichVuGiaoHang.Rating);
            }
            if (DonDatHang_DichVuHauMai.Rating > 0)
            {
                updateData.Add(DonDatHang_DichVuHauMai.Rating);
            }
            if (DonDatHang_DungMau.Rating > 0)
            {
                updateData.Add(DonDatHang_DungMau.Rating);
            }
            if (DonDatHang_DungYeuCauKyThuat.Rating > 0)
            {
                updateData.Add(DonDatHang_DungYeuCauKyThuat.Rating);
            }
            if (DonDatHang_Gia.Rating > 0)
            {
                updateData.Add(DonDatHang_Gia.Rating);
            }
            if (DonDatHang_Khac.Rating > 0)
            {
                updateData.Add(DonDatHang_Khac.Rating);
            }

            DanhGiaTongThe.Rating = updateData.Average();
        }

        private void DonDatHang_DungThoiGian_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonDatHang_DungMau_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonDatHang_DatTestLy_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonDatHang_DatTestHoa_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonDatHang_DungYeuCauKyThuat_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonDatHang_Gia_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonDatHang_DichVuGiaoHang_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonDatHang_DichVuHauMai_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonDatHang_Khac_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }
        #endregion

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            int selectedRow = gridView2.FocusedRowHandle;
            dynamic data = gridView2.GetRow(selectedRow);
            if (data != null)
            {
                var nguyenLieu = DatHangVatTuList.FirstOrDefault(s => s.NguyenLieuId == data.NguyenLieuId);
                if (nguyenLieu == null)
                {
                    nguyenLieu = new DonDatHangViewModel.VatTuDonGia();
                    nguyenLieu.SoLuong = 0;
                    nguyenLieu.NguyenLieuId = data.NguyenLieuId;
                    DatHangVatTuList.Add(nguyenLieu);
                }
                if (SelectedList.Contains(data.Id))
                {
                    nguyenLieu.SoLuong -= data.DuKien;
                    if (nguyenLieu.SoLuong <= 0)
                    {
                        DatHangVatTuList.Remove(nguyenLieu);
                    }
                    SelectedList.Remove(data.Id);
                }
                else
                {
                    nguyenLieu.SoLuong += data.DuKien;
                    SelectedList.Add(data.Id);
                }
                gridNguyenLieu.RefreshDataSource();
            }
        }

        private void gridView2_RowStyle(object sender, RowStyleEventArgs e)
        {
            var row = gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["Id"]);
            if (row == null) return;

            if (SelectedList.Contains((long)row))
            {
                e.Appearance.BackColor = Color.LightBlue;
                e.Appearance.ForeColor = Color.White;
            }
        }

      
    }
}
