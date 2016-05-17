using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraNavBar;
using TLShoes.Form;
using TLShoes.FormControls.BangThongSo;
using TLShoes.FormControls.BaoCaoPhanXuong;
using TLShoes.FormControls.ChiLenh;
using TLShoes.FormControls.CongNgheSanXuat;
using TLShoes.FormControls.DonHang;
using TLShoes.FormControls.KeHoachSanXuat;
using TLShoes.FormControls.MauSanXuat;
using TLShoes.FormControls.MauTest;
using TLShoes.FormControls.MauThuDao;
using TLShoes.FormControls.NguyenLieu;
using TLShoes.FormControls.TongHopMauTest;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class Main : System.Windows.Forms.Form
    {
        private static GiayTLEntities dbContext;
        public static Type currentModel;
        public static string currentForm;
        public static Type currentControl;
        public static string currentFormName = "";

        public Main()
        {
            InitializeComponent();

            InitDefault<ucDanhMucList, ucDanhMuc, DanhMuc>();
        }

        private void InitDefault<T, T1, T2>(string formName = "") where T : UserControl, new()
        {
            var ucList = FormFactory<T>.Get();
            currentControl = typeof(T1);
            currentModel = typeof(T2);
            currentForm = typeof(T).Name;
            currentFormName = formName;
            GenerateUltilsForm(ucList);
        }

        private void GenerateUltilsForm(UserControl controlList)
        {
            navGroupList.GroupClientHeight = this.Height;

            navContainerList.Controls.Add(controlList);
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

        public static void ShowPopupInfo(object data = null)
        {
            var addForm = (UserControl)Activator.CreateInstance(currentControl, data);

            var defaultForm = new DefaultForm();
            defaultForm.Height = addForm.Height + 50;
            defaultForm.Width = addForm.Width + 50;
            defaultForm.Text = currentFormName;

            defaultForm.Controls.Add(addForm);
            addForm.Dock = DockStyle.Fill;
            defaultForm.Show();
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
            //InitDefault<ucChiLenhList, ucChiLenh, ChiLenh>("Chỉ Lệnh");
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
            GenerateUltilsForm(ucList);
            ObserverControl.PulishAction("Refresh");
        }
    }
}



 