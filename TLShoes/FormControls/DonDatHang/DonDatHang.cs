using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TLShoes.FormControls.DonDatHang
{
    public partial class ucDonDatHang : BaseUserControl
    {
        BindingList<DonDatHangViewModel.VatTuDonGia> DatHangVatTuList = new BindingList<DonDatHangViewModel.VatTuDonGia>();
        List<TLShoes.ToTrinh> ToTrinhList = new List<TLShoes.ToTrinh>();
        List<long> SelectedList = new List<long>();
        private TLShoes.DonDatHang _donDatHang = null;

        public ucDonDatHang(TLShoes.DonDatHang data = null)
        {
            InitializeComponent();

            var lstNhaCungCap = SF.Get<NhaCungCapViewModel>().GetList();
            SetComboboxDataSource(DonDatHang_NhaCungCapId,lstNhaCungCap,"TenCongTy");

            Init(data);
            ToTrinhList = SF.Get<ToTrinhViewModel>().GetList(data);
            if (data != null)
            {
                SF.Get<DonDatHangViewModel>().GetChiTietDatHang(data, ref DatHangVatTuList);
                btnExport.Visible = true;
                SelectedList = ToTrinhList.Where(s => s.DonDatHangFormatList.Contains(data.Id)).Select(s => s.Id).ToList();
                _donDatHang = data;
            }
            gridToTrinh.DataSource = ToTrinhList;
            gridNguyenLieu.DataSource = DatHangVatTuList;

            SetRepositoryItem(NguyenLieuLookUp, SF.Get<NguyenLieuViewModel>().GetList(), "Ten");

            btnDeleteNguyenLieu.Click += btnDeleteNguyenLieu_Click;

            InitAuthorize();
        }

        private void InitAuthorize()
        {
            btnCancel.Enabled = false;
            btnDuyet.Enabled = true;
            btnDuyet.Visible = false;
            btnExport.Visible = false;
            btnSave.Enabled = true;

            if (_donDatHang != null)
            {
                lblSoPhieu.Text = string.Format("Số Đơn Hàng: {0}", _donDatHang.SoDH);
                var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_donDatHang.TrangThai);

                if (trangThai <= Define.TrangThai.HUY)
                {
                    if (Authorization.LoginUser.LoaiNguoiDung == Define.LoaiNguoiDung.TRUONG_PVT.ToString())
                    {
                        btnDuyet.Visible = true;
                    }
                }

                // Check verify authorize
                if (trangThai == Define.TrangThai.DUYET)
                {
                    if (Authorization.LoginUser.LoaiNguoiDung == Define.LoaiNguoiDung.GDSX.ToString())
                    {
                        btnDuyet.Visible = true;
                        btnCancel.Enabled = true;
                    }
                }

                // Can't save if verified
                if (trangThai > Define.TrangThai.HUY)
                {
                    btnSave.Enabled = false;
                }

                // Allow export after final verify
                if (trangThai == Define.TrangThai.DUYET_PVT)
                {
                    btnExport.Visible = true;
                    btnDuyet.Visible = true;
                    btnDuyet.Enabled = false;
                }

                var verifyAuthorize = Authorization.CheckAuthorization("DonDatHang", Define.Authorization.VERIFY);
                btnDuyet.Visible &= verifyAuthorize;
            }
        }



        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }

            // Save Don hang
            using (var transaction = new TransactionScope())
            {
                var saveData = CRUD.GetFormObject(FormControls, _donDatHang);
                saveData.SoLuongDat = DatHangVatTuList.Sum(s => s.SoLuong);
                CRUD.DecorateSaveData(saveData, _donDatHang == null);
                SF.Get<DonDatHangViewModel>().Save(saveData);

                // Clear deleted data
                var listChiTietDelete = SF.Get<DonDatHangViewModel>().GetList(saveData.Id);
                foreach (var deleteItem in listChiTietDelete)
                {
                    if (DatHangVatTuList.All(s => s.Id != deleteItem.Id))
                    {
                        SF.Get<DonDatHangViewModel>().Delete(deleteItem);
                    }
                }

                // Update danh sach cac to trinh da duoc dat hang
                foreach (var totrinh in ToTrinhList)
                {
                    var isUpdateToTrinh = false;
                    if (SelectedList.Contains(totrinh.Id))
                    {
                        if (!totrinh.DonDatHangFormatList.Contains(saveData.Id))
                        {
                            totrinh.DonDatHangList += saveData.Id + ",";
                            isUpdateToTrinh = true;
                        }
                    }
                    else if (!string.IsNullOrEmpty(totrinh.DonDatHangList))
                    {
                        totrinh.DonDatHangList = "";
                        isUpdateToTrinh = true;
                    }

                    if (isUpdateToTrinh)
                    {
                        SF.Get<ToTrinhViewModel>().Save(totrinh);
                    }
                }

                // Save nguyen lieu chi lenh
                foreach (var nguyenlieu in DatHangVatTuList)
                {
                    var chitietDonDatHang = new ChiTietDonDatHang();
                    if (nguyenlieu.Id != 0)
                    {
                        chitietDonDatHang.Id = nguyenlieu.Id;
                    }
                    chitietDonDatHang.DonDatHangId = saveData.Id;
                    chitietDonDatHang.NguyenLieuId = nguyenlieu.NguyenLieuId;
                    chitietDonDatHang.NhaCungCapId = nguyenlieu.NhaCungCapId;
                    chitietDonDatHang.DonGia = nguyenlieu.DonGia;
                    chitietDonDatHang.GhiChu = nguyenlieu.GhiChu;
                    chitietDonDatHang.SoLuong = nguyenlieu.SoLuong;
                    chitietDonDatHang.SoLuongThuc = nguyenlieu.SoLuongThuc;

                    CRUD.DecorateSaveData(chitietDonDatHang);
                    SF.Get<DonDatHangViewModel>().Save(chitietDonDatHang);
                }

                transaction.Complete();
            }


            // Update danh gia nha cung cap
            if (DonDatHang_NhaCungCapId.SelectedValue != null)
            {
                var nhaCungCapId = (long)DonDatHang_NhaCungCapId.SelectedValue;
                ThreadHelper.RunBackground(() =>
                {
                    using (var context = new GiayTLEntities())
                    {
                        var nhaCungCap = context.NhaCungCaps.Find(nhaCungCapId);
                        if (nhaCungCap != null)
                        {
                            var donHangNhaCungCap = context.DonDatHangs.Where(s => s.NhaCungCapId == nhaCungCapId).ToList();
                            var gia = donHangNhaCungCap.Where(s => s.Gia > 0).ToList();
                            if (gia.Any())
                            {
                                nhaCungCap.Gia = (int)gia.Average(s => s.Gia);                                
                            }

                            var dungThoiGian = donHangNhaCungCap.Where(s => s.DungThoiGian > 0).ToList();
                            if (dungThoiGian.Any())
                            {
                                nhaCungCap.DungThoiGian = (int)dungThoiGian.Average(s => s.DungThoiGian);
                            }

                            var dungYeuCauKyThuat = donHangNhaCungCap.Where(s => s.DungYeuCauKyThuat > 0).ToList();
                            if (dungYeuCauKyThuat.Any())
                            {
                                nhaCungCap.DungYeuCauKyThuat = (int)dungYeuCauKyThuat.Average(s => s.DungYeuCauKyThuat);                                
                            }

                            var dungMau = donHangNhaCungCap.Where(s => s.DungMau > 0).ToList();
                            if (dungMau.Any())
                            {
                                nhaCungCap.DungMau = (int)dungMau.Average(s => s.DungMau);                                
                            }

                            var khac = donHangNhaCungCap.Where(s => s.Khac > 0).ToList();
                            if (khac.Any())
                            {
                                nhaCungCap.Khac = (int)khac.Average(s => s.Khac);                                
                            }

                            var datTestLy = donHangNhaCungCap.Where(s => s.DatTestLy > 0).ToList();
                            if (datTestLy.Any())
                            {
                                nhaCungCap.DatTestLy = (int)datTestLy.Average(s => s.DatTestLy);                                
                            }

                            var datTestHoa = donHangNhaCungCap.Where(s => s.DatTestHoa > 0).ToList();
                            if (datTestHoa.Any())
                            {
                                nhaCungCap.DatTestHoa = (int)datTestHoa.Average(s => s.DatTestHoa);                                
                            }

                            var dichVuGiaoHang = donHangNhaCungCap.Where(s => s.DichVuGiaoHang > 0).ToList();
                            if (dichVuGiaoHang.Any())
                            {
                                nhaCungCap.DichVuGiaoHang = (int)dichVuGiaoHang.Average(s => s.DichVuGiaoHang);                                
                            }

                            var dichVuHauMai = donHangNhaCungCap.Where(s => s.DichVuHauMai > 0).ToList();
                            if (dichVuHauMai.Any())
                            {
                                nhaCungCap.DichVuHauMai = (int)dichVuHauMai.Average(s => s.DichVuHauMai);                                
                            }
                            context.NhaCungCaps.AddOrUpdate(nhaCungCap);
                            context.SaveChanges();
                        }
                    }
                });
            }

            return true;
        }

        public string ValidateInput()
        {
            if (DatHangVatTuList.Any(s => s.DonGia.Equals(0f)))
            {
                return "Chưa lấy giá vậy tư từ Nhà Cung Cấp!";
            }

            return string.Empty;
        }


        private void btnDeleteNguyenLieu_Click(object sender, EventArgs e)
        {
            int selectedRow = gridViewNguyenLieu.FocusedRowHandle;
            gridViewNguyenLieu.DeleteRow(selectedRow);
            dynamic data = gridViewNguyenLieu.GetRow(selectedRow);
            if (data != null && SelectedList.Contains(data.ToTrinhId))
            {
                SelectedList.Remove(data.ToTrinhId);
            }
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
                        vatTu.DonViTinh = nhaCungCapVatTu.NguyenLieu.DVT.Ten;
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

            if (updateData.Count > 0)
            {
                DanhGiaTongThe.Rating = updateData.Average();
            }
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
                    nguyenLieu.ToTrinhId = data.Id;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_donDatHang == null) return;
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = Define.EXPORT_EXTENSION;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ThreadHelper.LoadForm(() =>
                {
                    //Start Excel and get Application object.
                    var excel = new Application();

                    //Get a new workbook.
                    var workBook = excel.Workbooks.Open(Path.Combine(FileHelper.TemplatePath, Define.TEMPLATE_DON_DAT_HANG));
                    var workSheet = (_Worksheet)workBook.ActiveSheet;

                    try
                    {
                        var donDatHang = _donDatHang;
                        var chitietDatHang = donDatHang.ChiTietDonDatHangs.ToList();
                        for (int i = 0; i < chitietDatHang.Count; i++)
                        {
                            workSheet.Cells[11 + i, 1] = i + 1;
                            workSheet.Cells[11 + i, 2] = chitietDatHang[i].NguyenLieu.Ten;
                            workSheet.Cells[11 + i, 6] = chitietDatHang[i].NguyenLieu.QuyCach;
                            workSheet.Cells[11 + i, 7] = chitietDatHang[i].NguyenLieu.Mau != null
                                ? chitietDatHang[i].NguyenLieu.Mau.Ten
                                : "";
                            workSheet.Cells[11 + i, 8] = chitietDatHang[i].NguyenLieu.DVT != null
                                ? chitietDatHang[i].NguyenLieu.DVT.Ten
                                : "";
                            workSheet.Cells[11 + i, 9] = chitietDatHang[i].SoLuong;
                            var giaVatTu = chitietDatHang[i].NhaCungCap.NhaCungCapVatTus.FirstOrDefault(s => s.NguyenLieuId == chitietDatHang[i].NguyenLieuId);
                            if (giaVatTu != null) workSheet.Cells[11 + i, 10] = giaVatTu.DonGia;
                            workSheet.Cells[11 + i, 11] = chitietDatHang[i].NguyenLieu.GhiChu;

                            if (11 + i > 20)
                            {
                                var row = (Range)workSheet.Rows[11 + i + 1];
                                row.Insert(XlInsertShiftDirection.xlShiftDown);
                            }
                        }

                        workBook.SaveAs(saveDialog.FileName);
                    }
                    finally
                    {
                        workBook.Close();
                    }
                });

                var confirmDialog = MessageBox.Show(Define.MESSAGE_EXPORT_SUCCESS_TEXT, Define.MESSAGE_EXPORT_SUCCESS_TITLE, MessageBoxButtons.YesNo);
                if (confirmDialog == DialogResult.Yes)
                {
                    Process.Start(saveDialog.FileName);
                }
                this.ParentForm.Close();
            }
        }

        public override void btnCancel_Click(object sender, EventArgs e)
        {
            if (_donDatHang != null)
            {
                _donDatHang.TrangThai = Define.TrangThai.HUY.ToString();
                _donDatHang.NgayDuyet = TimeHelper.Current();
                _donDatHang.NguoiDuyetId = Authorization.LoginUser.Id;
                InitAuthorize();
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (_donDatHang != null)
            {
                using (var transaction = new TransactionScope())
                {
                    var trangThai = PrimitiveConvert.StringToEnum<Define.TrangThai>(_donDatHang.TrangThai);
                    var ngayDuyet = TimeHelper.Current();
                    // Lock item

                    if (trangThai <= Define.TrangThai.HUY)
                    {
                        _donDatHang.NgayLap = ngayDuyet;
                        _donDatHang.NguoiLapId = Authorization.LoginUser.Id;
                        _donDatHang.TrangThai = Define.TrangThai.DUYET.ToString();
                    }

                    // Verify
                    if (trangThai == Define.TrangThai.DUYET)
                    {
                        _donDatHang.SoDH = SF.Get<DonDatHangViewModel>().GenerateSoPhieu();
                        _donDatHang.TrangThai = Define.TrangThai.DUYET_PVT.ToString();
                        _donDatHang.NgayDuyet = ngayDuyet;
                        _donDatHang.NguoiDuyetId = Authorization.LoginUser.Id;
                    }

                    SF.Get<DonDatHangViewModel>().Save(_donDatHang);
                    transaction.Complete();
                }
                InitAuthorize();
            }
        }
    }
}
