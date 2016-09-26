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
        public static BindingList<ChiTietDonHang> ChiTietDonhang = new BindingList<ChiTietDonHang>();

        public static Dictionary<string, string> GopYDict = new Dictionary<string, string>()
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
            ChiTietDonhang.Clear();
            InitializeComponent();

            DonHang_KhachHangId.DisplayMember = "TenCongTy";
            DonHang_KhachHangId.ValueMember = "Id";
            DonHang_KhachHangId.DataSource = new BindingSource(SF.Get<KhachHangViewModel>().GetList(), null);

            var listNguyenLieu = SF.Get<NguyenLieuViewModel>().GetList();

            DonHang_MaPhomId.DisplayMember = "MaNguyenLieu";
            DonHang_MaPhomId.ValueMember = "Id";
            DonHang_MaPhomId.DataSource = new BindingSource(listNguyenLieu.Where(s => s.LoaiNguyenLieu.Ten == "PHOM").ToList(), null);

            DonHang_DatLotTayId.DisplayMember = "MaNguyenLieu";
            DonHang_DatLotTayId.ValueMember = "Id";
            DonHang_DatLotTayId.DataSource = new BindingSource(listNguyenLieu, null);

            DonHang_DeId.DisplayMember = "MaNguyenLieu";
            DonHang_DeId.ValueMember = "Id";
            DonHang_DeId.DataSource = new BindingSource(listNguyenLieu, null);

            DonHang_LotId.DisplayMember = "MaNguyenLieu";
            DonHang_LotId.ValueMember = "Id";
            DonHang_LotId.DataSource = new BindingSource(listNguyenLieu, null);

            DonHang_MuId.DisplayMember = "MaNguyenLieu";
            DonHang_MuId.ValueMember = "Id";
            DonHang_MuId.DataSource = new BindingSource(listNguyenLieu, null);

            HideAllGopY();
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

            repositoryItemLookUpEdit1.NullText = "";
            repositoryItemLookUpEdit1.Properties.DataSource = SF.Get<DanhMucViewModel>().GetList(Define.LoaiDanhMuc.MAU).Select(s => new { s.Ten, s.Id }).ToList();
            repositoryItemLookUpEdit1.PopulateColumns();
            repositoryItemLookUpEdit1.ShowHeader = false;
            repositoryItemLookUpEdit1.Columns["Id"].Visible = false;
            repositoryItemLookUpEdit1.Properties.DisplayMember = "Ten";
            repositoryItemLookUpEdit1.Properties.ValueMember = "Id";
            repositoryItemLookUpEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            gridControl.DataSource = ChiTietDonhang;
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
            DonHang_GopYQC.Hide();

            lblGopY.Text = "";
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(string.Format("{0} {1}!", "Không được phép để trống", validateResult));
                return false;
            }
            var saveData = CRUD.GetFormObject<DonHang>(FormControls);
            using (var transaction = new TransactionScope())
            {
                SF.Get<DonHangViewModel>().Save(saveData);
                var id = saveData.Id;

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
                               khachHang.Gia = (int)donHangKhachHang.Where(s => s.Gia > 0).Average(s => s.Gia);
                               khachHang.DungThoiGian = (int)donHangKhachHang.Where(s => s.DungThoiGian > 0).Average(s => s.DungThoiGian);
                               khachHang.DungYeuCauKyThuat = (int)donHangKhachHang.Where(s => s.DungYeuCauKyThuat > 0).Average(s => s.DungYeuCauKyThuat);
                               khachHang.DungMau = (int)donHangKhachHang.Where(s => s.DungMau > 0).Average(s => s.DungMau);
                               khachHang.Khac = (int)donHangKhachHang.Where(s => s.Khac > 0).Average(s => s.Khac);
                               khachHang.DatTestLy = (int)donHangKhachHang.Where(s => s.DatTestLy > 0).Average(s => s.DatTestLy);
                               khachHang.DatTestHoa = (int)donHangKhachHang.Where(s => s.DatTestHoa > 0).Average(s => s.DatTestHoa);
                               khachHang.DichVuGiaoHang = (int)donHangKhachHang.Where(s => s.DichVuGiaoHang > 0).Average(s => s.DichVuGiaoHang);
                               khachHang.DichVuHauMai = (int)donHangKhachHang.Where(s => s.DichVuHauMai > 0).Average(s => s.DichVuHauMai);
                               context.KhachHangs.AddOrUpdate(khachHang);
                               context.SaveChanges();
                           }
                       }
                   });
            }
            return true;
        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(DonHang_KhachHangId.Text))
            {
                return lblKhacHangId.Text;
            }
            if (string.IsNullOrEmpty(DonHang_MaHang.Text))
            {
                return lblMaHang.Text;
            }
            if (string.IsNullOrEmpty(DonHang_OrderNo.Text))
            {
                return lblOrderNo.Text;
            }
            if (string.IsNullOrEmpty(DonHang_NgayNhan.Text))
            {
                return lblNgayNhan.Text;
            }
            if (string.IsNullOrEmpty(DonHang_NgayXuat.Text))
            {
                return lblNgayXuat.Text;
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
                    DonHang_GopYQC.Show();
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
            GopYDict["QC"] = DonHang_GopYQC.Text;
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

            DanhGiaTongThe.Rating = updateData.Average();
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
    }
}
