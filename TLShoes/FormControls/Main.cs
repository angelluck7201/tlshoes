using System;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using TLShoes.Form;
using TLShoes.FormControls.BaoCaoPhanXuong;
using TLShoes.FormControls.ChiLenh;
using TLShoes.FormControls.CongNgheSanXuat;
using TLShoes.FormControls.DanhGia;
using TLShoes.FormControls.DonDatHang;
using TLShoes.FormControls.DonHang;
using TLShoes.FormControls.KeHoachSanXuat;
using TLShoes.FormControls.MauDanhGia;
using TLShoes.FormControls.MauSanXuat;
using TLShoes.FormControls.MauTest;
using TLShoes.FormControls.MauThuDao;
using TLShoes.FormControls.NguyenLieu;
using TLShoes.FormControls.NhaCungCap;
using TLShoes.FormControls.NhapKho;
using TLShoes.FormControls.TongHopMauTest;
using TLShoes.FormControls.ToTrinh;
using TLShoes.FormControls.XuatKho;

namespace TLShoes
{
    public partial class Main : System.Windows.Forms.Form
    {
        public const string CURRENT_VERSION = "1.0";

        private static GiayTLEntities dbContext;
        public static Type currentModel;
        public static string currentForm;
        public static Type currentControl;
        public static string currentFormName = "";

        public Main()
        {
            InitializeComponent();

            InitDefault<ucDanhMucList, ucDanhMuc, DanhMuc>("Danh Mục");
        }

        private void InitDefault<T, T1, T2>(string formName = "") where T : UserControl, new()
        {
            var ucList = FormFactory<T>.Get();
            currentControl = typeof(T1);
            currentModel = typeof(T2);
            currentForm = typeof(T).Name;
            currentFormName = formName;

            groupBoxView.Text = string.Format("{0} {1}", "Danh sách", formName);
            GenerateUltilsForm(ucList);
        }

        private void GenerateUltilsForm(UserControl controlList)
        {
            groupBoxView.Controls.Add(controlList);
            controlList.Dock = DockStyle.Fill;
            controlList.BringToFront();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ObserverControl.PulishAction("Refresh");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShowPopupInfo();
        }

        public void ShowPopupInfo(object data = null)
        {
            var addForm = (UserControl)Activator.CreateInstance(currentControl, data);

            var defaultForm = new DefaultForm();

            defaultForm.Height = addForm.Height + 50;
            defaultForm.Width = addForm.Width + 15;
            defaultForm.Text = currentFormName;

            defaultForm.Controls.Add(addForm);
            addForm.Dock = DockStyle.Fill;
            defaultForm.Show();

            this.Enabled = false;
            ObserverControl.Regist("Close", currentForm, () => { this.Enabled = true; });
        }

        private void navDanhMuc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            InitDefault<ucDanhMucList, ucDanhMuc, DanhMuc>("Danh Mục");
        }

        private void navKhachHang_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucKhachHangList, ucKhachHang, KhachHang>("Khách Hàng");
        }

        private void navDonHang_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucDonHangList, ucDonHang, DonHang>("Đơn Hàng");
        }

        private void navMauDoi_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucMauDoiList, ucMauDoi, MauDoi>("Mẫu Đối");
        }

        private void navMauTest_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucMauTestList, ucMauTest, MauTest>("Mẫu Test");
        }

        private void navCongNgheSanXuat_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucCongNgheSanXuatList, ucCongNgheSanXuat, CongNgheSanXuat>("Công Nghệ Sản Xuất");
        }

        private void navBaoCaoPhanXuong_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucBaoCaoPhanXuongList, ucBaoCaoPhanXuong, BaoCaoPhanXuong>("Báo Cáo Phân Xưởng");
        }

        private void navKeHoachSanXuat_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucKeHoachSanXuatList, ucKeHoachSanXuat, KeHoachSanXuat>("Kế Hoạch Sản Xuất");
        }

        private void navNguyenLieu_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucNguyenLieuList, ucNguyenLieu, NguyenLieu>("Nguyên Liệu");
        }

        private void navBangThongSo_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            // InitDefault<ucBangThongSoList, ucBangThongSo, BangThongSo>();
        }

        private void navChiLenh_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucChiLenhList, ucChiLenh, ChiLenh>("Chỉ Lệnh");
        }

        private void navMauSanXuat_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucMauSanXuatList, ucMauSanXuat, MauSanXuat>("Mẫu Sản Xuất");
        }

        private void navMauThuDao_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucMauThuDaoList, ucMauThuDao, MauThuDao>("Mẫu Thử Dao");
        }

        private void navTongHop_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var ucList = FormFactory<ucTongHopMauTestList>.Get();
            currentForm = typeof(ucTongHopMauTestList).Name;
            currentControl = typeof(ucTongHopMauTest);
            GenerateUltilsForm(ucList);
            ObserverControl.PulishAction("Refresh");
        }

        private void navPhieuNhapKho_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucNhapKhoList, ucNhapKho, PhieuNhapKho>("Phiếu Nhập Kho");
        }

        private void navPhieuXuatKho_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucXuatKhoList, ucXuatKho, PhieuXuatKho>("Phiếu Xuất Kho");
        }

        private void navToTrinh_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucToTrinhList, ucToTrinh, ToTrinh>("Tờ Trình");
        }

        private void navTongHopBaoCao_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var ucList = new ucBaoCaoTongHop();
            currentControl = typeof(ucBaoCaoTongHop);
            GenerateUltilsForm(ucList);
        }

        private void navNhaCungCap_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucNhaCungCapList, ucNhaCungCap, NhaCungCap>("Nhà Cung Cấp");
        }

        private void navDonDatHang_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucDonDatHangList, ucDonDatHang, DonDatHang>("Đơn Đặt Hàng");
        }

        private void navMauDanhGia_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucMauDanhGiaList, ucMauDanhGia, MauDanhGia>("Mẫu Đánh Giá");
        }

        private void navDanhGia_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucDanhGiaList, ucDanhGia, DanhGia>("QC Đánh Giá");
        }
    }
}



