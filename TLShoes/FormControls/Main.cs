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
using TLShoes.FormControls.MauTest;
using TLShoes.FormControls.NguyenLieu;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class Main : System.Windows.Forms.Form
    {
        private static GiayTLEntities dbContext;
        public static Type currentModel;
        public static string currentForm;
        public static Type currentControl;

        public Main()
        {
            InitializeComponent();

            InitDanhMuc();
        }

        private void InitDanhMuc()
        {
            var ucList = FormFactory<ucDanhMucList>.Get();
            currentControl = typeof(ucDanhMuc);
            currentModel = typeof(DanhMuc);
            currentForm = "ucDanhMucList";
            GenerateUltilsForm(ucList);
        }

        private void InitKhacHang()
        {
            var ucList = FormFactory<ucKhachHangList>.Get();
            currentControl = typeof(ucKhachHang);
            currentModel = typeof(KhachHang);
            currentForm = "ucKhachHangList";
            GenerateUltilsForm(ucList);
        }

        private void InitDonHang()
        {
            var ucList = FormFactory<ucDonHangList>.Get();
            currentControl = typeof(ucDonHang);
            currentModel = typeof(DonHang);
            currentForm = "ucDonHangList";
            GenerateUltilsForm(ucList);
        }

        private void InitMauDoi()
        {
            var ucList = FormFactory<ucMauDoiList>.Get();
            currentControl = typeof(ucMauDoi);
            currentModel = typeof(MauDoi);
            currentForm = "ucMauDoiList";
            GenerateUltilsForm(ucList);
        }

        private void InitDefault<T, T1, T2>() where T : UserControl, new()
        {
            var ucList = FormFactory<T>.Get();
            currentControl = typeof(T1);
            currentModel = typeof(T2);
            currentForm = typeof(T).Name;
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

            defaultForm.Controls.Add(addForm);
            addForm.Dock = DockStyle.Fill;
            defaultForm.Show();
        }

        private void navDanhMuc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            InitDanhMuc();
        }

        private void navKhachHang_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitKhacHang();
        }

        private void navDonHang_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDonHang();
        }

        private void navMauDoi_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitMauDoi();
        }

        private void navMauTest_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucMauTestList, ucMauTest, MauTest>();
        }

        private void navCongNgheSanXuat_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucCongNgheSanXuatList, ucCongNgheSanXuat, CongNgheSanXuat>();
        }

        private void navBaoCaoPhanXuong_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucBaoCaoPhanXuongList, ucBaoCaoPhanXuong, BaoCaoPhanXuong>();
        }

        private void navKeHoachSanXuat_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucKeHoachSanXuatList, ucKeHoachSanXuat, KeHoachSanXuat>();
        }

        private void navNguyenLieu_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucNguyenLieuList, ucNguyenLieu, NguyenLieu>();
        }

        private void navBangThongSo_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucBangThongSoList, ucBangThongSo, BangThongSo>();
        }

        private void navChiLenh_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucChiLenhList, ucChiLenh, ChiLenh>();
        }
    }
}



 