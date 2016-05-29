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
            this.navTongHop = new DevExpress.XtraNavBar.NavBarItem();
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
            this.navUltils = new DevExpress.XtraNavBar.NavBarGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarControlMenu
            // 
            this.navBarControlMenu.ActiveGroup = this.navDanhMucGroup;
            this.navBarControlMenu.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.navBarControlMenu.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBarControlMenu.Appearance.Item.Font = new System.Drawing.Font("Tahoma", 9F);
            this.navBarControlMenu.Appearance.Item.Options.UseFont = true;
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
            this.navBarControlMenu.Name = "navBarControlMenu";
            this.navBarControlMenu.OptionsNavPane.ExpandedWidth = 333;
            this.navBarControlMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControlMenu.Size = new System.Drawing.Size(333, 753);
            this.navBarControlMenu.TabIndex = 2;
            this.navBarControlMenu.Text = "navBarControl1";
            this.navBarControlMenu.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Visual Studio 2013 Dark");
            // 
            // navBarMauDoi
            // 
            this.navBarMauDoi.Caption = "Mẫu Đối";
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
            // navTongHop
            // 
            this.navTongHop.Caption = "Tổng Hợp";
            this.navTongHop.Name = "navTongHop";
            this.navTongHop.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navTongHop_LinkClicked);
            // 
            // navDanhMucGroup
            // 
            this.navDanhMucGroup.Caption = "Danh Mục";
            this.navDanhMucGroup.Expanded = true;
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
            // navUltils
            // 
            this.navUltils.Caption = "navBarGroup1";
            this.navUltils.Name = "navUltils";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(333, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSave);
            this.splitContainerControl1.Panel1.Text = "panelButton";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupBoxView);
            this.splitContainerControl1.Panel2.Text = "panelView";
            this.splitContainerControl1.Size = new System.Drawing.Size(1249, 753);
            this.splitContainerControl1.SplitterPosition = 64;
            this.splitContainerControl1.TabIndex = 9;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(132, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 31);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Làm Mới ";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnSave.Location = new System.Drawing.Point(19, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 31);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Thêm";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBoxView
            // 
            this.groupBoxView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxView.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxView.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBoxView.Location = new System.Drawing.Point(0, 0);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(1249, 683);
            this.groupBoxView.TabIndex = 0;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "groupBox1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.navBarControlMenu);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TL Shoes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.navBarControlMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControlMenu;
        private DevExpress.XtraNavBar.NavBarGroup navDanhMucGroup;
        private DevExpress.XtraNavBar.NavBarGroup navDonHangGroup;
        private DevExpress.XtraNavBar.NavBarGroup navTestGroup;
        private DevExpress.XtraNavBar.NavBarItem navDanhMuc;
        private DevExpress.XtraNavBar.NavBarGroup navUltils;
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.GroupBox groupBoxView;
    }
}

