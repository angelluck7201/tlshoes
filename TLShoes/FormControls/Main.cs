﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Mvvm.Native;
using DevExpress.Utils.Drawing;
using DevExpress.XtraNavBar;
using DevExpress.XtraSplashScreen;
using TLShoes.Common;
using TLShoes.Form;
using TLShoes.FormControls.BaoCaoPhanXuong;
using TLShoes.FormControls.ChiLenh;
using TLShoes.FormControls.CongNgheSanXuat;
using TLShoes.FormControls.DanhGia;
using TLShoes.FormControls.DonDatHang;
using TLShoes.FormControls.DonHang;
using TLShoes.FormControls.HuongDanDongGoi;
using TLShoes.FormControls.KeHoachSanXuat;
using TLShoes.FormControls.MauDanhGia;
using TLShoes.FormControls.MauSanXuat;
using TLShoes.FormControls.MauTest;
using TLShoes.FormControls.MauThuDao;
using TLShoes.FormControls.NguyenLieu;
using TLShoes.FormControls.NhaCungCap;
using TLShoes.FormControls.NhapKho;
using TLShoes.FormControls.QuanLyNguoiDung;
using TLShoes.FormControls.TheKho;
using TLShoes.FormControls.TongHopMauTest;
using TLShoes.FormControls.ToTrinh;
using TLShoes.FormControls.XuatKho;

namespace TLShoes
{
    public partial class Main : System.Windows.Forms.Form
    {
        public static Type currentModel;
        public static string currentForm;
        public static Type currentControl;
        public static string currentFormName = "";

        public Dictionary<string, Control> FeaturesDict = new Dictionary<string, Control>();

        public Main()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(6f, 13f);

            FeaturesDict.Add(btnSave.Name, btnSave);
            FeaturesDict.Add(btnRefresh.Name, btnRefresh);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Check update
            if (VersionControl.IsNeedUpdate())
            {
                VersionControl.CheckAndUpdateApp();
            }
            else
            {
                // Disable main form
                this.Enabled = false;

                // Check login
                var loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        public void InitLogin()
        {
            var loginUser = Authorization.LoginUser;
            this.Text = string.Format("{0} - {1} - {2}", "TL Shoes", loginUser.TenNguoiDung, loginUser.LoaiNguoiDung);

            // Validate view authorization
            var isInitClickItem = false;
            foreach (NavBarGroup group in navBarControlMenu.Groups)
            {
                var countVisible = 0;
                foreach (NavBarItemLink itemLink in group.ItemLinks)
                {
                    var modelName = itemLink.ItemName.Replace("nav", "");
                    var viewAuthorization = Authorization.CheckAuthorization(modelName, Define.Authorization.VIEW);
                    itemLink.Visible = viewAuthorization;
                    if (viewAuthorization)
                    {
                        if (!isInitClickItem)
                        {
                            group.Expanded = true;
                            group.SelectedLink = itemLink;
                            itemLink.PerformClick();
                            isInitClickItem = true;
                        }
                        countVisible++;
                    }
                }
                if (countVisible == 0)
                {
                    group.Visible = false;
                }
            }

            this.Enabled = true;
        }


        private void InitDefault<T, T1>(string formName = "", List<string> buttonList = null) where T : UserControl, new()
        {
            // Stop timer off old user controls
            TimerControl.StopTimer();

            var ucList = new T();
            currentControl = typeof(T1);
            // Su dung de pushlish cac action
            currentForm = typeof(T).Name;
            currentFormName = formName;

            groupBoxView.Text = string.Format("{0} {1}", "Danh sách", formName);
            GenerateUltilsForm(ucList, buttonList);
        }

        public void InitDefault<T, T1, T2>(string formName = "", List<string> buttonList = null) where T : UserControl, new()
        {
            // Stop timer off old user controls
            TimerControl.StopTimer();

            var ucList = new T();
            currentControl = typeof(T1);
            currentModel = typeof(T2);
            // Su dung de pushlish cac action
            currentForm = typeof(T).Name;

            currentFormName = formName;

            groupBoxView.Text = string.Format("{0} {1}", "Danh sách", formName);
            if (!Authorization.CheckAuthorization(currentModel.Name, Define.Authorization.WRITE))
            {
                if (buttonList == null)
                {
                    buttonList = new List<string>();
                }
                buttonList.Add("btnSave");
            }
            GenerateUltilsForm(ucList, buttonList);
        }

        private void GenerateUltilsForm(UserControl controlList, List<string> buttonList = null)
        {
            // Custome button
            var parentControls = this.splitContainerControl1.Panel1.Controls;
            foreach (Control control in parentControls)
            {
                if (buttonList != null && buttonList.Contains(control.Name))
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
            }

            groupBoxView.Controls.Clear();
            groupBoxView.Controls.Add(controlList);
            controlList.Dock = DockStyle.Fill;
            controlList.BringToFront();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ObserverControl.PulishAction(Define.ActionType.REFRESH);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ShowPopupInfo();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel |*.xls";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ObserverControl.PulishAction(Define.ActionType.EXPORT, saveDialog.FileName);
            }
        }

        public void ShowPopupInfo(object data = null)
        {
            this.Enabled = false;

            var addForm = (UserControl)Activator.CreateInstance(currentControl, data);
            var defaultForm = new DefaultForm();

            defaultForm.Height = addForm.Height + 50;
            defaultForm.Width = addForm.Width + 15;
            defaultForm.Text = currentFormName;

            defaultForm.Controls.Add(addForm);
            addForm.Dock = DockStyle.Fill;
            defaultForm.Focus();
            defaultForm.CustomShow(this);
        }

        private void navDanhMuc_LinkClicked(object sender, NavBarLinkEventArgs e)
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

        private void navTongHopMauTest_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucTongHopMauTestList, ucTongHopMauTest>("Tổng Hợp Mẫu Test", new List<string>() { "btnSave" });
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
            groupBoxView.Text = "Tổng Hợp Báo Cáo";
            GenerateUltilsForm(ucList, new List<string>() { "btnSave" });
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

        private void navMauHuongDanDongGoi_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucMauHuongDanDongGoiList, ucMauHuongDanDongGoi, MauHuongDanDongGoi>("Mẫu Hướng Dẫn Đóng Gói");
        }

        private void navHuongDanDongGoi_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucHuongDanDongGoiList, ucHuongDanDongGoi, HuongDanDongGoi>("Hướng Dẫn Đóng Gói");
        }

        private void navTongHopNguyenLieu_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var ucList = new ucTongHopNhaCungCap();
            currentControl = typeof(ucNhaCungCap);
            groupBoxView.Text = "Tổng Hợp Nhà Cung Cấp";
            GenerateUltilsForm(ucList, new List<string>() { "btnSave" });
        }

        private void navTheKho_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var ucList = new ucTheKhoList();
            currentControl = typeof(ucTheKhoList);
            groupBoxView.Text = "Thẻ kho";
            GenerateUltilsForm(ucList, new List<string>() { "btnSave" });
        }

        private void navNguoiDung_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucUserAccountList, ucUserAccount, UserAccount>("Người Dùng");

        }

        private void navPhanQuyen_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            InitDefault<ucPhanQuyenList, ucPhanQuyen, PhanQuyenNguoiDung>("Phân Quyền");
        }
    }
}



