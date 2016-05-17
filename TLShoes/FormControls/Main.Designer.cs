namespace TLShoes
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.navBarControlMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarMauDoi = new DevExpress.XtraNavBar.NavBarGroup();
            this.navMauDoi = new DevExpress.XtraNavBar.NavBarItem();
            this.navMauTest = new DevExpress.XtraNavBar.NavBarItem();
            this.navMauSanXuat = new DevExpress.XtraNavBar.NavBarItem();
            this.navMauThuDao = new DevExpress.XtraNavBar.NavBarItem();
            this.navDanhMucGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navDanhMuc = new DevExpress.XtraNavBar.NavBarItem();
            this.navNguyenLieu = new DevExpress.XtraNavBar.NavBarItem();
            this.navDonHangGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navKhachHang = new DevExpress.XtraNavBar.NavBarItem();
            this.navDonHang = new DevExpress.XtraNavBar.NavBarItem();
            this.navTestGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navCongNgheSanXuat = new DevExpress.XtraNavBar.NavBarItem();
            this.navKeHoach = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBaoCaoPhanXuong = new DevExpress.XtraNavBar.NavBarItem();
            this.navKeHoachSanXuat = new DevExpress.XtraNavBar.NavBarItem();
            this.navHuongDanGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBangThongSo = new DevExpress.XtraNavBar.NavBarItem();
            this.navChiLenh = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarControlUltils = new DevExpress.XtraNavBar.NavBarControl();
            this.navGroupUltils = new DevExpress.XtraNavBar.NavBarGroup();
            this.navContainerUltils = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.navContainerList = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.navGroupList = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navUltils = new DevExpress.XtraNavBar.NavBarGroup();
            this.navTongHop = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlUltils)).BeginInit();
            this.navBarControlUltils.SuspendLayout();
            this.navContainerUltils.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarControlMenu
            // 
            this.navBarControlMenu.ActiveGroup = this.navBarMauDoi;
            this.navBarControlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControlMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navDanhMucGroup,
            this.navDonHangGroup,
            this.navTestGroup,
            this.navKeHoach,
            this.navHuongDanGroup,
            this.navBarMauDoi});
            this.navBarControlMenu.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navDanhMuc,
            this.navKhachHang,
            this.navDonHang,
            this.navMauTest,
            this.navCongNgheSanXuat,
            this.navBaoCaoPhanXuong,
            this.navKeHoachSanXuat,
            this.navNguyenLieu,
            this.navBangThongSo,
            this.navChiLenh,
            this.navMauSanXuat,
            this.navMauThuDao,
            this.navTongHop});
            this.navBarControlMenu.Location = new System.Drawing.Point(0, 0);
            this.navBarControlMenu.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.navBarControlMenu.Name = "navBarControlMenu";
            this.navBarControlMenu.OptionsNavPane.ExpandedWidth = 208;
            this.navBarControlMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControlMenu.Size = new System.Drawing.Size(208, 753);
            this.navBarControlMenu.TabIndex = 2;
            this.navBarControlMenu.Text = "navBarControl1";
            this.navBarControlMenu.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Office 2013 Light Gray");
            // 
            // navBarMauDoi
            // 
            this.navBarMauDoi.Caption = "Mẫu Đối";
            this.navBarMauDoi.Expanded = true;
            this.navBarMauDoi.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navMauDoi),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navMauTest),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navMauSanXuat),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navMauThuDao),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navTongHop)});
            this.navBarMauDoi.Name = "navBarMauDoi";
            // 
            // navMauDoi
            // 
            this.navMauDoi.Caption = "Mẫu Đối";
            this.navMauDoi.Name = "navMauDoi";
            this.navMauDoi.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navMauDoi_LinkClicked);
            // 
            // navMauTest
            // 
            this.navMauTest.Caption = "Mẫu Test";
            this.navMauTest.Name = "navMauTest";
            this.navMauTest.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navMauTest_LinkClicked);
            // 
            // navMauSanXuat
            // 
            this.navMauSanXuat.Caption = "Mẫu Sản Xuất";
            this.navMauSanXuat.Name = "navMauSanXuat";
            this.navMauSanXuat.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navMauSanXuat_LinkClicked);
            // 
            // navMauThuDao
            // 
            this.navMauThuDao.Caption = "Mẫu Thử Dao";
            this.navMauThuDao.Name = "navMauThuDao";
            this.navMauThuDao.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navMauThuDao_LinkClicked);
            // 
            // navDanhMucGroup
            // 
            this.navDanhMucGroup.Caption = "Danh Mục";
            this.navDanhMucGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navDanhMuc),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navNguyenLieu)});
            this.navDanhMucGroup.Name = "navDanhMucGroup";
            // 
            // navDanhMuc
            // 
            this.navDanhMuc.Caption = "Danh Mục";
            this.navDanhMuc.Name = "navDanhMuc";
            this.navDanhMuc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navDanhMuc_LinkClicked);
            // 
            // navNguyenLieu
            // 
            this.navNguyenLieu.Caption = "Nguyên Liệu";
            this.navNguyenLieu.Name = "navNguyenLieu";
            this.navNguyenLieu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navNguyenLieu_LinkClicked);
            // 
            // navDonHangGroup
            // 
            this.navDonHangGroup.Caption = "Đơn Hàng";
            this.navDonHangGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navKhachHang),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navDonHang)});
            this.navDonHangGroup.Name = "navDonHangGroup";
            // 
            // navKhachHang
            // 
            this.navKhachHang.Caption = "Khách Hàng";
            this.navKhachHang.Name = "navKhachHang";
            this.navKhachHang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navKhachHang_LinkClicked);
            // 
            // navDonHang
            // 
            this.navDonHang.Caption = "Đơn Hàng";
            this.navDonHang.Name = "navDonHang";
            this.navDonHang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navDonHang_LinkClicked);
            // 
            // navTestGroup
            // 
            this.navTestGroup.Caption = "Kết Quả Test";
            this.navTestGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navCongNgheSanXuat)});
            this.navTestGroup.Name = "navTestGroup";
            // 
            // navCongNgheSanXuat
            // 
            this.navCongNgheSanXuat.Caption = "Công Nghệ";
            this.navCongNgheSanXuat.Name = "navCongNgheSanXuat";
            this.navCongNgheSanXuat.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navCongNgheSanXuat_LinkClicked);
            // 
            // navKeHoach
            // 
            this.navKeHoach.Caption = "Kế Hoạch/Giám Sát";
            this.navKeHoach.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBaoCaoPhanXuong),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navKeHoachSanXuat)});
            this.navKeHoach.Name = "navKeHoach";
            // 
            // navBaoCaoPhanXuong
            // 
            this.navBaoCaoPhanXuong.Caption = "Báo Cáo Phân Xưởng";
            this.navBaoCaoPhanXuong.Name = "navBaoCaoPhanXuong";
            this.navBaoCaoPhanXuong.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBaoCaoPhanXuong_LinkClicked);
            // 
            // navKeHoachSanXuat
            // 
            this.navKeHoachSanXuat.Caption = "Kế Hoạch Sản Xuất";
            this.navKeHoachSanXuat.Name = "navKeHoachSanXuat";
            this.navKeHoachSanXuat.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navKeHoachSanXuat_LinkClicked);
            // 
            // navHuongDanGroup
            // 
            this.navHuongDanGroup.Caption = "Hướng Dẫn/Chỉ Lệnh";
            this.navHuongDanGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBangThongSo),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navChiLenh)});
            this.navHuongDanGroup.Name = "navHuongDanGroup";
            // 
            // navBangThongSo
            // 
            this.navBangThongSo.Caption = "Bảng Thông Số";
            this.navBangThongSo.Name = "navBangThongSo";
            this.navBangThongSo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBangThongSo_LinkClicked);
            // 
            // navChiLenh
            // 
            this.navChiLenh.Caption = "Chỉ Lệnh";
            this.navChiLenh.Name = "navChiLenh";
            this.navChiLenh.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navChiLenh_LinkClicked);
            // 
            // navBarControlUltils
            // 
            this.navBarControlUltils.ActiveGroup = this.navGroupUltils;
            this.navBarControlUltils.Controls.Add(this.navContainerUltils);
            this.navBarControlUltils.Controls.Add(this.navContainerList);
            this.navBarControlUltils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControlUltils.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navGroupUltils,
            this.navGroupList});
            this.navBarControlUltils.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1});
            this.navBarControlUltils.Location = new System.Drawing.Point(208, 0);
            this.navBarControlUltils.Name = "navBarControlUltils";
            this.navBarControlUltils.OptionsNavPane.ExpandedWidth = 1374;
            this.navBarControlUltils.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControlUltils.Size = new System.Drawing.Size(1374, 753);
            this.navBarControlUltils.TabIndex = 4;
            this.navBarControlUltils.Text = "navBarControl2";
            this.navBarControlUltils.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Office 2013 Light Gray");
            // 
            // navGroupUltils
            // 
            this.navGroupUltils.Caption = "Các Tiện Ích";
            this.navGroupUltils.ControlContainer = this.navContainerUltils;
            this.navGroupUltils.Expanded = true;
            this.navGroupUltils.GroupClientHeight = 50;
            this.navGroupUltils.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupUltils.Name = "navGroupUltils";
            // 
            // navContainerUltils
            // 
            this.navContainerUltils.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navContainerUltils.Appearance.Options.UseBackColor = true;
            this.navContainerUltils.Controls.Add(this.panelControl1);
            this.navContainerUltils.Name = "navContainerUltils";
            this.navContainerUltils.Size = new System.Drawing.Size(1364, 41);
            this.navContainerUltils.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(1150, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(214, 41);
            this.panelControl1.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(120, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm Mới ";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Thêm";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // navContainerList
            // 
            this.navContainerList.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navContainerList.Appearance.Options.UseBackColor = true;
            this.navContainerList.Name = "navContainerList";
            this.navContainerList.Size = new System.Drawing.Size(1364, 586);
            this.navContainerList.TabIndex = 2;
            // 
            // navGroupList
            // 
            this.navGroupList.Caption = "Danh Sách";
            this.navGroupList.ControlContainer = this.navContainerList;
            this.navGroupList.Expanded = true;
            this.navGroupList.GroupClientHeight = 595;
            this.navGroupList.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupList.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1)});
            this.navGroupList.Name = "navGroupList";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "navBarItem1";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navUltils
            // 
            this.navUltils.Caption = "navBarGroup1";
            this.navUltils.Name = "navUltils";
            // 
            // navTongHop
            // 
            this.navTongHop.Caption = "Tổng Hợp";
            this.navTongHop.Name = "navTongHop";
            this.navTongHop.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navTongHop_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.navBarControlUltils);
            this.Controls.Add(this.navBarControlMenu);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlUltils)).EndInit();
            this.navBarControlUltils.ResumeLayout(false);
            this.navContainerUltils.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControlMenu;
        private DevExpress.XtraNavBar.NavBarGroup navDanhMucGroup;
        private DevExpress.XtraNavBar.NavBarGroup navDonHangGroup;
        private DevExpress.XtraNavBar.NavBarGroup navTestGroup;
        private DevExpress.XtraNavBar.NavBarItem navDanhMuc;
        private DevExpress.XtraNavBar.NavBarControl navBarControlUltils;
        private DevExpress.XtraNavBar.NavBarGroup navUltils;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navContainerUltils;
        private DevExpress.XtraNavBar.NavBarGroup navGroupUltils;
        private DevExpress.XtraNavBar.NavBarGroup navGroupList;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navContainerList;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarItem navKhachHang;
        private DevExpress.XtraNavBar.NavBarItem navDonHang;
        private DevExpress.XtraNavBar.NavBarItem navMauTest;
        private DevExpress.XtraNavBar.NavBarItem navCongNgheSanXuat;
        private DevExpress.XtraNavBar.NavBarGroup navKeHoach;
        private DevExpress.XtraNavBar.NavBarItem navBaoCaoPhanXuong;
        private DevExpress.XtraNavBar.NavBarItem navKeHoachSanXuat;
        private DevExpress.XtraNavBar.NavBarItem navNguyenLieu;
        private DevExpress.XtraNavBar.NavBarGroup navHuongDanGroup;
        private DevExpress.XtraNavBar.NavBarItem navBangThongSo;
        private DevExpress.XtraNavBar.NavBarItem navChiLenh;
        private DevExpress.XtraNavBar.NavBarGroup navBarMauDoi;
        private DevExpress.XtraNavBar.NavBarItem navMauSanXuat;
        private DevExpress.XtraNavBar.NavBarItem navMauThuDao;
        private DevExpress.XtraNavBar.NavBarItem navMauDoi;
        private DevExpress.XtraNavBar.NavBarItem navTongHop;
    }
}

