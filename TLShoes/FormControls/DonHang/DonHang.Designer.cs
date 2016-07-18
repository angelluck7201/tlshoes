namespace TLShoes
{
    partial class ucDonHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHinh = new DevExpress.XtraEditors.LabelControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChiTietDonHang_Mau = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.DonHang_HinhAnh = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.DonHang_MaPhomId = new System.Windows.Forms.ComboBox();
            this.DonHang_KhachHangId = new System.Windows.Forms.ComboBox();
            this.DonHang_NgayXuat = new System.Windows.Forms.DateTimePicker();
            this.DonHang_NgayNhan = new System.Windows.Forms.DateTimePicker();
            this.lblNgayNhan = new DevExpress.XtraEditors.LabelControl();
            this.DonHang_OrderNo = new DevExpress.XtraEditors.TextEdit();
            this.lblOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.lblKhacHangId = new DevExpress.XtraEditors.LabelControl();
            this.DonHang_MaHang = new DevExpress.XtraEditors.TextEdit();
            this.lblNgayXuat = new DevExpress.XtraEditors.LabelControl();
            this.lblMaHang = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gridGopY = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonHang_GopYKhoThanhPham = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYPhuTro = new System.Windows.Forms.RichTextBox();
            this.lblGopY = new DevExpress.XtraEditors.LabelControl();
            this.DonHang_GopYKhoVatTu = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYQC = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYMau = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYVatTu = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYCongNghe = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYXuongChat = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYXuongGo = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYXuongMay = new System.Windows.Forms.RichTextBox();
            this.DonHang_GopYXuongDe = new System.Windows.Forms.RichTextBox();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietDonHang_Mau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonHang_HinhAnh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DonHang_OrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonHang_MaHang.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGopY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHinh
            // 
            this.lblHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblHinh.Location = new System.Drawing.Point(305, 227);
            this.lblHinh.Name = "lblHinh";
            this.lblHinh.Size = new System.Drawing.Size(64, 17);
            this.lblHinh.TabIndex = 35;
            this.lblHinh.Text = "Hình Ảnh";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(16, 13);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ChiTietDonHang_Mau,
            this.repositoryItemLookUpEdit1});
            this.gridControl.Size = new System.Drawing.Size(690, 497);
            this.gridControl.TabIndex = 39;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.colSize,
            this.colMau,
            this.colSoLuong});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 1;
            this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuong", null, "(TỔNG={0:0.##})")});
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupedColumns = true;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMau, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // colSize
            // 
            this.colSize.Caption = "Size";
            this.colSize.FieldName = "Size";
            this.colSize.Name = "colSize";
            this.colSize.Visible = true;
            this.colSize.VisibleIndex = 0;
            // 
            // colMau
            // 
            this.colMau.Caption = "Màu";
            this.colMau.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colMau.FieldName = "MauId";
            this.colMau.Name = "colMau";
            this.colMau.Visible = true;
            this.colMau.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số Lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuong", "TỔNG={0:0.##}")});
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 2;
            // 
            // ChiTietDonHang_Mau
            // 
            this.ChiTietDonHang_Mau.AutoHeight = false;
            this.ChiTietDonHang_Mau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ChiTietDonHang_Mau.Name = "ChiTietDonHang_Mau";
            // 
            // DonHang_HinhAnh
            // 
            this.DonHang_HinhAnh.Location = new System.Drawing.Point(159, 21);
            this.DonHang_HinhAnh.Name = "DonHang_HinhAnh";
            this.DonHang_HinhAnh.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.DonHang_HinhAnh.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.DonHang_HinhAnh.Size = new System.Drawing.Size(355, 188);
            this.DonHang_HinhAnh.TabIndex = 37;
            this.DonHang_HinhAnh.TabStop = true;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl1.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.xtraTabControl1.Appearance.Options.UseBorderColor = true;
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.Appearance.Options.UseForeColor = true;
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(728, 591);
            this.xtraTabControl1.TabIndex = 54;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Appearance.Header.BackColor = System.Drawing.SystemColors.Highlight;
            this.xtraTabPage2.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage2.Appearance.Header.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.xtraTabPage2.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage2.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage2.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabPage2.Appearance.HeaderActive.BackColor = System.Drawing.SystemColors.Highlight;
            this.xtraTabPage2.Appearance.HeaderActive.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage2.Appearance.HeaderActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.xtraTabPage2.Appearance.HeaderActive.Options.UseBackColor = true;
            this.xtraTabPage2.Appearance.HeaderActive.Options.UseFont = true;
            this.xtraTabPage2.Appearance.HeaderActive.Options.UseForeColor = true;
            this.xtraTabPage2.Controls.Add(this.DonHang_MaPhomId);
            this.xtraTabPage2.Controls.Add(this.DonHang_KhachHangId);
            this.xtraTabPage2.Controls.Add(this.DonHang_NgayXuat);
            this.xtraTabPage2.Controls.Add(this.lblHinh);
            this.xtraTabPage2.Controls.Add(this.DonHang_NgayNhan);
            this.xtraTabPage2.Controls.Add(this.lblNgayNhan);
            this.xtraTabPage2.Controls.Add(this.DonHang_OrderNo);
            this.xtraTabPage2.Controls.Add(this.lblOrderNo);
            this.xtraTabPage2.Controls.Add(this.DonHang_HinhAnh);
            this.xtraTabPage2.Controls.Add(this.lblKhacHangId);
            this.xtraTabPage2.Controls.Add(this.DonHang_MaHang);
            this.xtraTabPage2.Controls.Add(this.lblNgayXuat);
            this.xtraTabPage2.Controls.Add(this.lblMaHang);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(721, 556);
            this.xtraTabPage2.Text = "Thông tin đơn hàng";
            // 
            // DonHang_MaPhomId
            // 
            this.DonHang_MaPhomId.FormattingEnabled = true;
            this.DonHang_MaPhomId.Location = new System.Drawing.Point(159, 325);
            this.DonHang_MaPhomId.Name = "DonHang_MaPhomId";
            this.DonHang_MaPhomId.Size = new System.Drawing.Size(228, 24);
            this.DonHang_MaPhomId.TabIndex = 1;
            // 
            // DonHang_KhachHangId
            // 
            this.DonHang_KhachHangId.FormattingEnabled = true;
            this.DonHang_KhachHangId.Location = new System.Drawing.Point(159, 285);
            this.DonHang_KhachHangId.Name = "DonHang_KhachHangId";
            this.DonHang_KhachHangId.Size = new System.Drawing.Size(529, 24);
            this.DonHang_KhachHangId.TabIndex = 0;
            // 
            // DonHang_NgayXuat
            // 
            this.DonHang_NgayXuat.Location = new System.Drawing.Point(159, 454);
            this.DonHang_NgayXuat.Name = "DonHang_NgayXuat";
            this.DonHang_NgayXuat.Size = new System.Drawing.Size(529, 23);
            this.DonHang_NgayXuat.TabIndex = 5;
            // 
            // DonHang_NgayNhan
            // 
            this.DonHang_NgayNhan.Location = new System.Drawing.Point(159, 413);
            this.DonHang_NgayNhan.Name = "DonHang_NgayNhan";
            this.DonHang_NgayNhan.Size = new System.Drawing.Size(529, 23);
            this.DonHang_NgayNhan.TabIndex = 4;
            // 
            // lblNgayNhan
            // 
            this.lblNgayNhan.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNgayNhan.Location = new System.Drawing.Point(31, 412);
            this.lblNgayNhan.Name = "lblNgayNhan";
            this.lblNgayNhan.Size = new System.Drawing.Size(103, 17);
            this.lblNgayNhan.TabIndex = 60;
            this.lblNgayNhan.Text = "Ngày Nhận ĐH";
            // 
            // DonHang_OrderNo
            // 
            this.DonHang_OrderNo.Location = new System.Drawing.Point(159, 368);
            this.DonHang_OrderNo.Name = "DonHang_OrderNo";
            this.DonHang_OrderNo.Size = new System.Drawing.Size(529, 22);
            this.DonHang_OrderNo.TabIndex = 3;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblOrderNo.Location = new System.Drawing.Point(31, 370);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(44, 17);
            this.lblOrderNo.TabIndex = 58;
            this.lblOrderNo.Text = "Số ĐH";
            // 
            // lblKhacHangId
            // 
            this.lblKhacHangId.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblKhacHangId.Location = new System.Drawing.Point(31, 288);
            this.lblKhacHangId.Name = "lblKhacHangId";
            this.lblKhacHangId.Size = new System.Drawing.Size(76, 16);
            this.lblKhacHangId.TabIndex = 57;
            this.lblKhacHangId.Text = "Khách Hàng";
            // 
            // DonHang_MaHang
            // 
            this.DonHang_MaHang.Location = new System.Drawing.Point(415, 327);
            this.DonHang_MaHang.Name = "DonHang_MaHang";
            this.DonHang_MaHang.Size = new System.Drawing.Size(273, 22);
            this.DonHang_MaHang.TabIndex = 2;
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNgayXuat.Location = new System.Drawing.Point(31, 454);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(99, 17);
            this.lblNgayXuat.TabIndex = 55;
            this.lblNgayXuat.Text = "Ngày Xuất ĐH";
            // 
            // lblMaHang
            // 
            this.lblMaHang.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblMaHang.Location = new System.Drawing.Point(31, 329);
            this.lblMaHang.Name = "lblMaHang";
            this.lblMaHang.Size = new System.Drawing.Size(56, 16);
            this.lblMaHang.TabIndex = 54;
            this.lblMaHang.Text = "Mã Hàng";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.BackColor = System.Drawing.Color.Silver;
            this.xtraTabPage1.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.defaultInfo);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(721, 556);
            this.xtraTabPage1.Text = "Thông tin người dùng";
            // 
            // defaultInfo
            // 
            this.defaultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultInfo.Location = new System.Drawing.Point(0, 0);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(721, 556);
            this.defaultInfo.TabIndex = 11;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Appearance.Header.BackColor = System.Drawing.SystemColors.Highlight;
            this.xtraTabPage3.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage3.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage3.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage3.Appearance.HeaderActive.BackColor = System.Drawing.SystemColors.Highlight;
            this.xtraTabPage3.Appearance.HeaderActive.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage3.Appearance.HeaderActive.Options.UseBackColor = true;
            this.xtraTabPage3.Appearance.HeaderActive.Options.UseFont = true;
            this.xtraTabPage3.Controls.Add(this.gridGopY);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYKhoThanhPham);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYPhuTro);
            this.xtraTabPage3.Controls.Add(this.lblGopY);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYKhoVatTu);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYQC);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYMau);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYVatTu);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYCongNghe);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYXuongChat);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYXuongGo);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYXuongMay);
            this.xtraTabPage3.Controls.Add(this.DonHang_GopYXuongDe);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(721, 556);
            this.xtraTabPage3.Text = "Góp ý";
            // 
            // gridGopY
            // 
            this.gridGopY.Location = new System.Drawing.Point(44, 12);
            this.gridGopY.MainView = this.gridView1;
            this.gridGopY.Name = "gridGopY";
            this.gridGopY.Size = new System.Drawing.Size(649, 387);
            this.gridGopY.TabIndex = 69;
            this.gridGopY.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridGopY;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Bộ Phận";
            this.gridColumn4.FieldName = "Key";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 147;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Góp Ý";
            this.gridColumn5.FieldName = "Value";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 482;
            // 
            // DonHang_GopYKhoThanhPham
            // 
            this.DonHang_GopYKhoThanhPham.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYKhoThanhPham.Name = "DonHang_GopYKhoThanhPham";
            this.DonHang_GopYKhoThanhPham.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYKhoThanhPham.TabIndex = 68;
            this.DonHang_GopYKhoThanhPham.Text = "";
            // 
            // DonHang_GopYPhuTro
            // 
            this.DonHang_GopYPhuTro.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYPhuTro.Name = "DonHang_GopYPhuTro";
            this.DonHang_GopYPhuTro.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYPhuTro.TabIndex = 67;
            this.DonHang_GopYPhuTro.Text = "";
            // 
            // lblGopY
            // 
            this.lblGopY.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblGopY.Location = new System.Drawing.Point(44, 423);
            this.lblGopY.Name = "lblGopY";
            this.lblGopY.Size = new System.Drawing.Size(17, 16);
            this.lblGopY.TabIndex = 52;
            this.lblGopY.Text = "QC";
            // 
            // DonHang_GopYKhoVatTu
            // 
            this.DonHang_GopYKhoVatTu.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYKhoVatTu.Name = "DonHang_GopYKhoVatTu";
            this.DonHang_GopYKhoVatTu.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYKhoVatTu.TabIndex = 66;
            this.DonHang_GopYKhoVatTu.Text = "";
            // 
            // DonHang_GopYQC
            // 
            this.DonHang_GopYQC.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYQC.Name = "DonHang_GopYQC";
            this.DonHang_GopYQC.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYQC.TabIndex = 58;
            this.DonHang_GopYQC.Text = "";
            // 
            // DonHang_GopYMau
            // 
            this.DonHang_GopYMau.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYMau.Name = "DonHang_GopYMau";
            this.DonHang_GopYMau.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYMau.TabIndex = 65;
            this.DonHang_GopYMau.Text = "";
            // 
            // DonHang_GopYVatTu
            // 
            this.DonHang_GopYVatTu.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYVatTu.Name = "DonHang_GopYVatTu";
            this.DonHang_GopYVatTu.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYVatTu.TabIndex = 59;
            this.DonHang_GopYVatTu.Text = "";
            // 
            // DonHang_GopYCongNghe
            // 
            this.DonHang_GopYCongNghe.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYCongNghe.Name = "DonHang_GopYCongNghe";
            this.DonHang_GopYCongNghe.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYCongNghe.TabIndex = 64;
            this.DonHang_GopYCongNghe.Text = "";
            // 
            // DonHang_GopYXuongChat
            // 
            this.DonHang_GopYXuongChat.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYXuongChat.Name = "DonHang_GopYXuongChat";
            this.DonHang_GopYXuongChat.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYXuongChat.TabIndex = 60;
            this.DonHang_GopYXuongChat.Text = "";
            // 
            // DonHang_GopYXuongGo
            // 
            this.DonHang_GopYXuongGo.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYXuongGo.Name = "DonHang_GopYXuongGo";
            this.DonHang_GopYXuongGo.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYXuongGo.TabIndex = 63;
            this.DonHang_GopYXuongGo.Text = "";
            // 
            // DonHang_GopYXuongMay
            // 
            this.DonHang_GopYXuongMay.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYXuongMay.Name = "DonHang_GopYXuongMay";
            this.DonHang_GopYXuongMay.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYXuongMay.TabIndex = 61;
            this.DonHang_GopYXuongMay.Text = "";
            // 
            // DonHang_GopYXuongDe
            // 
            this.DonHang_GopYXuongDe.Location = new System.Drawing.Point(164, 423);
            this.DonHang_GopYXuongDe.Name = "DonHang_GopYXuongDe";
            this.DonHang_GopYXuongDe.Size = new System.Drawing.Size(529, 96);
            this.DonHang_GopYXuongDe.TabIndex = 62;
            this.DonHang_GopYXuongDe.Text = "";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Appearance.Header.BackColor = System.Drawing.SystemColors.Highlight;
            this.xtraTabPage4.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage4.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage4.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage4.Appearance.HeaderActive.BackColor = System.Drawing.SystemColors.Highlight;
            this.xtraTabPage4.Appearance.HeaderActive.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.xtraTabPage4.Appearance.HeaderActive.Options.UseBackColor = true;
            this.xtraTabPage4.Appearance.HeaderActive.Options.UseFont = true;
            this.xtraTabPage4.Controls.Add(this.gridControl);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(721, 556);
            this.xtraTabPage4.Text = "Đơn hàng";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnCancel.Location = new System.Drawing.Point(4, 611);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "Hủy";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnSave.Location = new System.Drawing.Point(465, 611);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Lưu";
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSaveContinue.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveContinue.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveContinue.Appearance.Options.UseBackColor = true;
            this.btnSaveContinue.Appearance.Options.UseFont = true;
            this.btnSaveContinue.Appearance.Options.UseForeColor = true;
            this.btnSaveContinue.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnSaveContinue.Location = new System.Drawing.Point(546, 611);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(179, 30);
            this.btnSaveContinue.TabIndex = 57;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            // 
            // ucDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ucDonHang";
            this.Size = new System.Drawing.Size(737, 656);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietDonHang_Mau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonHang_HinhAnh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DonHang_OrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DonHang_MaHang.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGopY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHinh;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraGrid.Columns.GridColumn colMau;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ChiTietDonHang_Mau;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.PictureEdit DonHang_HinhAnh;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.ComboBox DonHang_MaPhomId;
        private System.Windows.Forms.ComboBox DonHang_KhachHangId;
        private System.Windows.Forms.DateTimePicker DonHang_NgayXuat;
        private System.Windows.Forms.DateTimePicker DonHang_NgayNhan;
        private DevExpress.XtraEditors.LabelControl lblNgayNhan;
        private DevExpress.XtraEditors.TextEdit DonHang_OrderNo;
        private DevExpress.XtraEditors.LabelControl lblOrderNo;
        private DevExpress.XtraEditors.LabelControl lblKhacHangId;
        private DevExpress.XtraEditors.TextEdit DonHang_MaHang;
        private DevExpress.XtraEditors.LabelControl lblNgayXuat;
        private DevExpress.XtraEditors.LabelControl lblMaHang;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Form.DefaultInfo defaultInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraGrid.GridControl gridGopY;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.RichTextBox DonHang_GopYKhoThanhPham;
        private System.Windows.Forms.RichTextBox DonHang_GopYPhuTro;
        private DevExpress.XtraEditors.LabelControl lblGopY;
        private System.Windows.Forms.RichTextBox DonHang_GopYKhoVatTu;
        private System.Windows.Forms.RichTextBox DonHang_GopYQC;
        private System.Windows.Forms.RichTextBox DonHang_GopYMau;
        private System.Windows.Forms.RichTextBox DonHang_GopYVatTu;
        private System.Windows.Forms.RichTextBox DonHang_GopYCongNghe;
        private System.Windows.Forms.RichTextBox DonHang_GopYXuongChat;
        private System.Windows.Forms.RichTextBox DonHang_GopYXuongGo;
        private System.Windows.Forms.RichTextBox DonHang_GopYXuongMay;
        private System.Windows.Forms.RichTextBox DonHang_GopYXuongDe;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
    }
}
