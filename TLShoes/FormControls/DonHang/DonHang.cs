using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.Common;
using TLShoes.FormControls;
using TLShoes.ViewModels;


namespace TLShoes
{
    public partial class ucDonHang : BaseUserControl
    {
        public DonHang _domainData;
        public BindingList<ChiTietDonHang> ChiTietDonhang = new BindingList<ChiTietDonHang>();

        public Dictionary<string, string> GopYDict = new Dictionary<string, string>()
        {
            {"Bp Vật Tư",""},
            {"Px Chặt",""},
            {"Px May",""},
            {"Px Gò",""},
            {"Px Đe",""},
            {"QC",""},
            {"Công Nghệ",""},
            {"Mẫu",""},
            {"Kho Vật Tư",""}, 
            {"Tổ Phụ Trợ",""},
            {"Kho Thành Phẩm",""},
        };

        public ucDonHang(DonHang data = null)
        {
            InitializeComponent();

            var lstKhachHang = SF.Get<KhachHangViewModel>().GetList();
            SetComboboxDataSource(DonHang_KhachHangId, lstKhachHang, "TenCongTy");

            var lstNguyenLieu = SF.Get<NguyenLieuViewModel>().GetList();

            var lstPhom = lstNguyenLieu.Where(s => s.LoaiNguyenLieu.Ten == "PHOM").ToList();
            SetComboboxDataSource(DonHang_MaPhomId, lstPhom, "MaNguyenLieu");

            var lstDaLotTay = lstNguyenLieu.Where(s => s.LoaiNguyenLieu.Ten == "DA LÓT TẨY").ToList();
            SetComboboxDataSource(DonHang_DatLotTayId, lstDaLotTay, "MaNguyenLieu");

            var lstDe = lstNguyenLieu.Where(s => s.LoaiNguyenLieu.Ten == "ĐẾ").ToList();
            SetComboboxDataSource(DonHang_DeId, lstDe, "MaNguyenLieu");

            var lstLot = lstNguyenLieu.Where(s => s.LoaiNguyenLieu.Ten == "LÓT").ToList();
            SetComboboxDataSource(DonHang_LotId, lstLot, "MaNguyenLieu");

            var lstMu = lstNguyenLieu.Where(s => s.LoaiNguyenLieu.Ten == "MŨ").ToList();
            SetComboboxDataSource(DonHang_MuId, lstMu, "MaNguyenLieu");

            HideAllGopY();
            _domainData = data;
            Init(data);
            if (data != null)
            {
                GopYDict["BP Vật Tư"] = data.GopYVatTu;
                GopYDict["Px Chặt"] = data.GopYXuongChat;
                GopYDict["Px May"] = data.GopYXuongMay;
                GopYDict["Px Gò"] = data.GopYXuongGo;
                GopYDict["Px Đe"] = data.GopYXuongDe;
                GopYDict["QC"] = data.GopYQc;
                GopYDict["Công Nghệ"] = data.GopYCongNghe;
                GopYDict["Mẫu"] = data.GopYMau;
                GopYDict["Kho Vật Tư"] = data.GopYKhoVatTu;
                GopYDict["Tổ Phụ Trợ"] = data.GopYPhuTro;
                GopYDict["Kho Thành Phẩm"] = data.GopYKhoThanhPham;

                ChiTietDonhang = new BindingList<ChiTietDonHang>(data.ChiTietDonHangs.ToList());
            }

            gridGopY.DataSource = GopYDict;

            var lstMau = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.MAU);
            SetRepositoryItem(repositoryItemLookUpEdit1, lstMau, "Ten");

            gridControl.DataSource = ChiTietDonhang;
            btnDelete.Click += btnDelete_Click;
            InitAuthorize();
        }

        private void InitAuthorize()
        {
            btnSave.Enabled = false;
            btnDone.Enabled = false;
            lblMessage.Visible = false;

            if (_domainData != null)
            {
                if (_domainData.TrangThai == Define.TrangThai.DUYET.ToString())
                {
                    if (Authorization.LoginUser.LoaiNguoiDung == Define.LoaiNguoiDung.GDSX.ToString())
                    {
                        btnDone.Enabled = true;
                    }
                    SetMessage(Define.MESSAGE_NOT_AVAILABLE_DON_HANG_DUYET);
                }
                if (string.IsNullOrEmpty(_domainData.TrangThai) || _domainData.TrangThai == Define.TrangThai.MOI.ToString())
                {
                    btnSave.Enabled = true;
                }
                if (_domainData.TrangThai == Define.TrangThai.DONE.ToString())
                {
                    SetMessage(Define.MESSAGE_NOT_AVAILABLE_DON_HANG_DONE);
                }
            }
        }

        private void SetMessage(string messsage)
        {
            lblMessage.Visible = true;
            lblMessage.Text = messsage;
        }

        private void HideAllGopY()
        {
            DonHang_GopYCongNghe.Hide();
            DonHang_GopYKhoVatTu.Hide();
            DonHang_GopYKhoThanhPham.Hide();
            DonHang_GopYMau.Hide();
            DonHang_GopYPhuTro.Hide();
            DonHang_GopYXuongGo.Hide();
            DonHang_GopYXuongChat.Hide();
            DonHang_GopYXuongDe.Hide();
            DonHang_GopYXuongMay.Hide();
            DonHang_GopYVatTu.Hide();
            DonHang_GopYQc.Hide();

            lblGopY.Text = "";
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }

            using (var transaction = new TransactionScope())
            {
                var saveData = CRUD.GetFormObject(FormControls, _domainData);
                saveData.SoLuong = ChiTietDonhang.Sum(s => s.SoLuong);
                SF.Get<DonHangViewModel>().Save(saveData);
                var id = saveData.Id;

                // Clear old data
                if (_domainData != null && _domainData.ChiTietDonHangs != null)
                {
                    foreach (var chiTietDonHang in _domainData.ChiTietDonHangs.ToList())
                    {
                        if (ChiTietDonhang.All(s => s.Id != chiTietDonHang.Id))
                        {
                            SF.Get<ChiTietDonHangViewModel>().Delete(chiTietDonHang);
                        }
                    }
                }

                // Save Chi Tiet Don Hang
                foreach (var chitiet in ChiTietDonhang)
                {
                    chitiet.DonHangId = id;
                    CRUD.DecorateSaveData(chitiet);
                    SF.Get<ChiTietDonHangViewModel>().Save(chitiet);
                }
                transaction.Complete();
            }

            // Update danh gia nha cung cap
            UpdateDanhGiaDonHang();

            return true;
        }

        private void UpdateDanhGiaDonHang()
        {
            if (DonHang_KhachHangId.SelectedValue != null)
            {
                var khachHangId = (long)DonHang_KhachHangId.SelectedValue;
                ThreadHelper.RunBackground(() =>
                {
                    using (var context = new GiayTLEntities())
                    {
                        var khachHang = context.KhachHangs.Find(khachHangId);
                        if (khachHang != null)
                        {
                            var donHangKhachHang = khachHang.DonHangs;
                            var gia = donHangKhachHang.Where(s => s.Gia > 0).ToList();
                            if (gia.Any())
                            {
                                khachHang.Gia = (int)gia.Average(s => s.Gia);
                            }

                            var dungThoiGian = donHangKhachHang.Where(s => s.DungThoiGian > 0).ToList();
                            if (dungThoiGian.Any())
                            {
                                khachHang.DungThoiGian = (int)dungThoiGian.Average(s => s.DungThoiGian);
                            }

                            var dungYeuCauKyThuat = donHangKhachHang.Where(s => s.DungYeuCauKyThuat > 0).ToList();
                            if (dungYeuCauKyThuat.Any())
                            {
                                khachHang.DungYeuCauKyThuat = (int)dungYeuCauKyThuat.Average(s => s.DungYeuCauKyThuat);
                            }

                            var dungMau = donHangKhachHang.Where(s => s.DungMau > 0).ToList();
                            if (dungMau.Any())
                            {
                                khachHang.DungMau = (int)dungMau.Average(s => s.DungMau);
                            }

                            var khac = donHangKhachHang.Where(s => s.Khac > 0).ToList();
                            if (khac.Any())
                            {
                                khachHang.Khac = (int)khac.Average(s => s.Khac);
                            }

                            var datTestLy = donHangKhachHang.Where(s => s.DatTestLy > 0).ToList();
                            if (datTestLy.Any())
                            {
                                khachHang.DatTestLy = (int)datTestLy.Average(s => s.DatTestLy);
                            }

                            var datTestHoa = donHangKhachHang.Where(s => s.DatTestHoa > 0).ToList();
                            if (datTestHoa.Any())
                            {
                                khachHang.DatTestHoa = (int)datTestHoa.Average(s => s.DatTestHoa);
                            }

                            var dichVuGiaoHang = donHangKhachHang.Where(s => s.DichVuGiaoHang > 0).ToList();
                            if (dichVuGiaoHang.Any())
                            {
                                khachHang.DichVuGiaoHang = (int)dichVuGiaoHang.Average(s => s.DichVuGiaoHang);
                            }

                            var dichVuHauMai = donHangKhachHang.Where(s => s.DichVuHauMai > 0).ToList();
                            if (dichVuHauMai.Any())
                            {
                                khachHang.DichVuHauMai = (int)dichVuHauMai.Average(s => s.DichVuHauMai);
                            }
                            context.KhachHangs.AddOrUpdate(khachHang);
                            context.SaveChanges();
                        }
                    }
                });
            }
        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(DonHang_KhachHangId.Text))
            {
                return "Không được phép để trống Khách Hàng";
            }
            if (string.IsNullOrEmpty(DonHang_MaHang.Text))
            {
                return "Không được phép để trống Mã Hàng";
            }
            if (string.IsNullOrEmpty(DonHang_OrderNo.Text))
            {
                return "Không được phép để trống Số ĐH";
            }
            if (string.IsNullOrEmpty(DonHang_MaGiay.Text))
            {
                return "Không được phép để trống Mã Giày";
            }

            return string.Empty;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            int selectedRow = gridView1.FocusedRowHandle;
            dynamic data = gridView1.GetRow(selectedRow);
            HideAllGopY();
            switch ((string)data.Key)
            {
                case "Bp Vật Tư":
                    DonHang_GopYVatTu.Show();
                    lblGopY.Text = "Vật Tư";
                    break;
                case "Px Chặt":
                    DonHang_GopYXuongChat.Show();
                    lblGopY.Text = "Xưởng Chặt";
                    break;
                case "Px May":
                    DonHang_GopYXuongMay.Show();
                    lblGopY.Text = "Xưởng May";
                    break;
                case "Px Gò":
                    DonHang_GopYXuongGo.Show();
                    lblGopY.Text = "Xưởng Gò";
                    break;
                case "Px Đe":
                    DonHang_GopYXuongDe.Show();
                    lblGopY.Text = "Xưởng Đe";
                    break;
                case "QC":
                    DonHang_GopYQc.Show();
                    lblGopY.Text = "Bp QC";
                    break;
                case "Công Nghệ":
                    DonHang_GopYCongNghe.Show();
                    lblGopY.Text = "Công Nghệ";
                    break;
                case "Mẫu":
                    DonHang_GopYMau.Show();
                    lblGopY.Text = "Mẫu";
                    break;
                case "Kho Vật Tư":
                    DonHang_GopYKhoVatTu.Show();
                    lblGopY.Text = "Kho Vật Tư";
                    break;
                case "Tổ Phụ Trợ":
                    DonHang_GopYPhuTro.Show();
                    lblGopY.Text = "Tổ Phụ Trợ";
                    break;
                case "Kho Thành Phẩm":
                    DonHang_GopYKhoThanhPham.Show();
                    lblGopY.Text = "Kho Thành Phẩm";
                    break;
            }
            GopYDict["Bp Vật Tư"] = DonHang_GopYVatTu.Text;
            GopYDict["Px Chặt"] = DonHang_GopYXuongChat.Text;
            GopYDict["Px May"] = DonHang_GopYXuongMay.Text;
            GopYDict["Px Gò"] = DonHang_GopYXuongGo.Text;
            GopYDict["Px Đe"] = DonHang_GopYXuongDe.Text;
            GopYDict["QC"] = DonHang_GopYQc.Text;
            GopYDict["Công Nghệ"] = DonHang_GopYCongNghe.Text;
            GopYDict["Mẫu"] = DonHang_GopYMau.Text;
            GopYDict["Kho Vật Tư"] = DonHang_GopYKhoVatTu.Text;
            GopYDict["Tổ Phụ Trợ"] = DonHang_GopYPhuTro.Text;
            GopYDict["Kho Thành Phẩm"] = DonHang_GopYKhoThanhPham.Text;

            gridGopY.DataSource = null;
            gridGopY.DataSource = GopYDict;
            gridView1.FocusedRowHandle = selectedRow;
        }

        #region Update total assessment

        private void UpdateTotalAssessment()
        {
            var updateData = new List<decimal>();
            if (DonHang_DungThoiGian.Rating > 0)
            {
                updateData.Add(DonHang_DungThoiGian.Rating);
            }
            if (DonHang_DatTestHoa.Rating > 0)
            {
                updateData.Add(DonHang_DatTestHoa.Rating);
            }
            if (DonHang_DatTestLy.Rating > 0)
            {
                updateData.Add(DonHang_DatTestLy.Rating);
            }
            if (DonHang_DichVuGiaoHang.Rating > 0)
            {
                updateData.Add(DonHang_DichVuGiaoHang.Rating);
            }
            if (DonHang_DichVuHauMai.Rating > 0)
            {
                updateData.Add(DonHang_DichVuHauMai.Rating);
            }
            if (DonHang_DungMau.Rating > 0)
            {
                updateData.Add(DonHang_DungMau.Rating);
            }
            if (DonHang_DungYeuCauKyThuat.Rating > 0)
            {
                updateData.Add(DonHang_DungYeuCauKyThuat.Rating);
            }
            if (DonHang_Gia.Rating > 0)
            {
                updateData.Add(DonHang_Gia.Rating);
            }
            if (DonHang_Khac.Rating > 0)
            {
                updateData.Add(DonHang_Khac.Rating);
            }

            if (updateData.Count > 0)
            {
                DanhGiaTongThe.Rating = updateData.Average();
            }
        }

        private void DonHang_DungThoiGian_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonHang_DungMau_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonHang_DatTestLy_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonHang_DatTestHoa_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonHang_DungYeuCauKyThuat_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonHang_Gia_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonHang_DichVuGiaoHang_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonHang_DichVuHauMai_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }

        private void DonHang_Khac_EditValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAssessment();
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gridView.DeleteRow(gridView.FocusedRowHandle);
        }

        private void DonHang_MaGiay_EditValueChanged(object sender, EventArgs e)
        {
            UpdateMaHang();
        }

        private void DonHang_MaPhomId_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateMaHang();
        }

        private void UpdateMaHang()
        {
            var maPhom = DonHang_MaPhomId.Text;
            var maGiay = DonHang_MaGiay.Text;
            DonHang_MaHang.Text = string.Format("{0}-{1}", maPhom, maGiay);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (_domainData != null)
            {
                var confirmDialog = MessageBox.Show("Đánh dấu đơn hàng đã hoàn thành. Đơn hàng sau khi đã hoàn thành thì tất cả những dữ liệu liên quan không thể thay đổi nữa," +
                                                    " bạn có chắc muốn lưu lại!", "Hoàn thành đơn hàng", MessageBoxButtons.YesNo);
                if (confirmDialog == DialogResult.Yes)
                {
                    SF.Get<DonHangViewModel>().UpdateTrangThai(Define.TrangThai.DONE, _domainData.Id);
                    InitAuthorize();
                }
            }
        }
    }
}
