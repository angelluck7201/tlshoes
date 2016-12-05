namespace TLShoes.FormControls.NhapKho
{
    partial class ucNhapKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNhapKho));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lblSoDonHang = new DevExpress.XtraEditors.LabelControl();
            this.lblDanhGiaId = new DevExpress.XtraEditors.LabelControl();
            this.PhieuNhapKho_DanhGiaId = new System.Windows.Forms.ComboBox();
            this.PhieuNhapKho_Kho = new System.Windows.Forms.ComboBox();
            this.PhieuNhapKho_DiaChi = new System.Windows.Forms.RichTextBox();
            this.PhieuNhapKho_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.PhieuNhapKho_NguoiGiao = new System.Windows.Forms.TextBox();
            this.lblNguoiGiao = new DevExpress.XtraEditors.LabelControl();
            this.lblDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.PhieuNhapKho_LyDo = new System.Windows.Forms.RichTextBox();
            this.lblLyDo = new DevExpress.XtraEditors.LabelControl();
            this.lblNgayNhap = new DevExpress.XtraEditors.LabelControl();
            this.lblKho = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gridNguyenLieu = new DevExpress.XtraGrid.GridControl();
            this.gridViewNguyenLieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NguyenLieuLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDeleteNguyenLieu = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuyet = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.lblSoPhieu = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNguyenLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNguyenLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteNguyenLieu)).BeginInit();
            this.SuspendLayout();
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
            this.xtraTabControl1.Size = new System.Drawing.Size(708, 596);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
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
            this.xtraTabPage2.Controls.Add(this.lblSoPhieu);
            this.xtraTabPage2.Controls.Add(this.lblSoDonHang);
            this.xtraTabPage2.Controls.Add(this.lblDanhGiaId);
            this.xtraTabPage2.Controls.Add(this.PhieuNhapKho_DanhGiaId);
            this.xtraTabPage2.Controls.Add(this.PhieuNhapKho_Kho);
            this.xtraTabPage2.Controls.Add(this.PhieuNhapKho_DiaChi);
            this.xtraTabPage2.Controls.Add(this.PhieuNhapKho_NgayNhap);
            this.xtraTabPage2.Controls.Add(this.PhieuNhapKho_NguoiGiao);
            this.xtraTabPage2.Controls.Add(this.lblNguoiGiao);
            this.xtraTabPage2.Controls.Add(this.lblDiaChi);
            this.xtraTabPage2.Controls.Add(this.PhieuNhapKho_LyDo);
            this.xtraTabPage2.Controls.Add(this.lblLyDo);
            this.xtraTabPage2.Controls.Add(this.lblNgayNhap);
            this.xtraTabPage2.Controls.Add(this.lblKho);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(701, 560);
            this.xtraTabPage2.Text = "Phiếu Nhập Kho";
            // 
            // lblSoDonHang
            // 
            this.lblSoDonHang.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblSoDonHang.Location = new System.Drawing.Point(420, 490);
            this.lblSoDonHang.Name = "lblSoDonHang";
            this.lblSoDonHang.Size = new System.Drawing.Size(24, 16);
            this.lblSoDonHang.TabIndex = 118;
            this.lblSoDonHang.Text = "Kho";
            // 
            // lblDanhGiaId
            // 
            this.lblDanhGiaId.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblDanhGiaId.Location = new System.Drawing.Point(30, 488);
            this.lblDanhGiaId.Name = "lblDanhGiaId";
            this.lblDanhGiaId.Size = new System.Drawing.Size(113, 17);
            this.lblDanhGiaId.TabIndex = 117;
            this.lblDanhGiaId.Text = "Phiếu Giao Hàng";
            // 
            // PhieuNhapKho_DanhGiaId
            // 
            this.PhieuNhapKho_DanhGiaId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.PhieuNhapKho_DanhGiaId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PhieuNhapKho_DanhGiaId.FormattingEnabled = true;
            this.PhieuNhapKho_DanhGiaId.Location = new System.Drawing.Point(179, 488);
            this.PhieuNhapKho_DanhGiaId.Name = "PhieuNhapKho_DanhGiaId";
            this.PhieuNhapKho_DanhGiaId.Size = new System.Drawing.Size(180, 24);
            this.PhieuNhapKho_DanhGiaId.TabIndex = 5;
            this.PhieuNhapKho_DanhGiaId.SelectedIndexChanged += new System.EventHandler(this.NhapKho_DanhGiaId_SelectedIndexChanged);
            // 
            // PhieuNhapKho_Kho
            // 
            this.PhieuNhapKho_Kho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.PhieuNhapKho_Kho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PhieuNhapKho_Kho.FormattingEnabled = true;
            this.PhieuNhapKho_Kho.Location = new System.Drawing.Point(180, 256);
            this.PhieuNhapKho_Kho.Name = "PhieuNhapKho_Kho";
            this.PhieuNhapKho_Kho.Size = new System.Drawing.Size(508, 24);
            this.PhieuNhapKho_Kho.TabIndex = 2;
            // 
            // PhieuNhapKho_DiaChi
            // 
            this.PhieuNhapKho_DiaChi.Location = new System.Drawing.Point(179, 135);
            this.PhieuNhapKho_DiaChi.Name = "PhieuNhapKho_DiaChi";
            this.PhieuNhapKho_DiaChi.Size = new System.Drawing.Size(509, 96);
            this.PhieuNhapKho_DiaChi.TabIndex = 1;
            this.PhieuNhapKho_DiaChi.Text = "";
            // 
            // PhieuNhapKho_NgayNhap
            // 
            this.PhieuNhapKho_NgayNhap.Location = new System.Drawing.Point(179, 305);
            this.PhieuNhapKho_NgayNhap.Name = "PhieuNhapKho_NgayNhap";
            this.PhieuNhapKho_NgayNhap.Size = new System.Drawing.Size(509, 23);
            this.PhieuNhapKho_NgayNhap.TabIndex = 3;
            // 
            // PhieuNhapKho_NguoiGiao
            // 
            this.PhieuNhapKho_NguoiGiao.Location = new System.Drawing.Point(179, 85);
            this.PhieuNhapKho_NguoiGiao.Name = "PhieuNhapKho_NguoiGiao";
            this.PhieuNhapKho_NguoiGiao.Size = new System.Drawing.Size(509, 23);
            this.PhieuNhapKho_NguoiGiao.TabIndex = 0;
            // 
            // lblNguoiGiao
            // 
            this.lblNguoiGiao.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNguoiGiao.Location = new System.Drawing.Point(28, 85);
            this.lblNguoiGiao.Name = "lblNguoiGiao";
            this.lblNguoiGiao.Size = new System.Drawing.Size(76, 17);
            this.lblNguoiGiao.TabIndex = 80;
            this.lblNguoiGiao.Text = "Người Giao";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblDiaChi.Location = new System.Drawing.Point(30, 138);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(48, 17);
            this.lblDiaChi.TabIndex = 88;
            this.lblDiaChi.Text = "Địa Chỉ";
            // 
            // PhieuNhapKho_LyDo
            // 
            this.PhieuNhapKho_LyDo.Location = new System.Drawing.Point(179, 361);
            this.PhieuNhapKho_LyDo.Name = "PhieuNhapKho_LyDo";
            this.PhieuNhapKho_LyDo.Size = new System.Drawing.Size(509, 96);
            this.PhieuNhapKho_LyDo.TabIndex = 4;
            this.PhieuNhapKho_LyDo.Text = "";
            // 
            // lblLyDo
            // 
            this.lblLyDo.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblLyDo.Location = new System.Drawing.Point(28, 364);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(36, 16);
            this.lblLyDo.TabIndex = 99;
            this.lblLyDo.Text = "Lý Do";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNgayNhap.Location = new System.Drawing.Point(30, 311);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(77, 17);
            this.lblNgayNhap.TabIndex = 105;
            this.lblNgayNhap.Text = "Ngày Nhập";
            // 
            // lblKho
            // 
            this.lblKho.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblKho.Location = new System.Drawing.Point(30, 259);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(24, 16);
            this.lblKho.TabIndex = 102;
            this.lblKho.Text = "Kho";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.BackColor = System.Drawing.Color.Silver;
            this.xtraTabPage1.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.defaultInfo);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(701, 560);
            this.xtraTabPage1.Text = "Thông tin người dùng";
            // 
            // defaultInfo
            // 
            this.defaultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultInfo.Location = new System.Drawing.Point(0, 0);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(701, 560);
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
            this.xtraTabPage3.Controls.Add(this.gridNguyenLieu);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(701, 560);
            this.xtraTabPage3.Text = "Chi Tiết";
            // 
            // gridNguyenLieu
            // 
            this.gridNguyenLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNguyenLieu.Location = new System.Drawing.Point(0, 0);
            this.gridNguyenLieu.MainView = this.gridViewNguyenLieu;
            this.gridNguyenLieu.Name = "gridNguyenLieu";
            this.gridNguyenLieu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.NguyenLieuLookUp,
            this.btnDeleteNguyenLieu});
            this.gridNguyenLieu.Size = new System.Drawing.Size(701, 560);
            this.gridNguyenLieu.TabIndex = 59;
            this.gridNguyenLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNguyenLieu});
            // 
            // gridViewNguyenLieu
            // 
            this.gridViewNguyenLieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn14});
            this.gridViewNguyenLieu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridViewNguyenLieu.GridControl = this.gridNguyenLieu;
            this.gridViewNguyenLieu.Name = "gridViewNguyenLieu";
            this.gridViewNguyenLieu.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewNguyenLieu.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridViewNguyenLieu.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridViewNguyenLieu.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewNguyenLieu.OptionsView.ShowGroupPanel = false;
            this.gridViewNguyenLieu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "Id";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Nguyên Liệu";
            this.gridColumn6.ColumnEdit = this.NguyenLieuLookUp;
            this.gridColumn6.FieldName = "NguyenLieuId";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 275;
            // 
            // NguyenLieuLookUp
            // 
            this.NguyenLieuLookUp.AutoHeight = false;
            this.NguyenLieuLookUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NguyenLieuLookUp.Name = "NguyenLieuLookUp";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.Caption = "Số Lượng";
            this.gridColumn8.FieldName = "SoLuong";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 337;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn14.AppearanceHeader.Options.UseFont = true;
            this.gridColumn14.ColumnEdit = this.btnDeleteNguyenLieu;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 52;
            // 
            // btnDeleteNguyenLieu
            // 
            this.btnDeleteNguyenLieu.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteNguyenLieu.Appearance.Image")));
            this.btnDeleteNguyenLieu.Appearance.Options.UseImage = true;
            this.btnDeleteNguyenLieu.AutoHeight = false;
            serializableAppearanceObject3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            serializableAppearanceObject3.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            serializableAppearanceObject3.Image = ((System.Drawing.Image)(resources.GetObject("serializableAppearanceObject3.Image")));
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject3.Options.UseBorderColor = true;
            serializableAppearanceObject3.Options.UseImage = true;
            this.btnDeleteNguyenLieu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.Default, ((System.Drawing.Image)(resources.GetObject("btnDeleteNguyenLieu.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Nhấp đúp để xóa", null, null, true)});
            this.btnDeleteNguyenLieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.btnDeleteNguyenLieu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeleteNguyenLieu.Name = "btnDeleteNguyenLieu";
            this.btnDeleteNguyenLieu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
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
            this.btnSave.Location = new System.Drawing.Point(630, 626);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            // 
            // btnDuyet
            // 
            this.btnDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuyet.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDuyet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDuyet.Appearance.Options.UseBackColor = true;
            this.btnDuyet.Appearance.Options.UseFont = true;
            this.btnDuyet.Appearance.Options.UseForeColor = true;
            this.btnDuyet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDuyet.Location = new System.Drawing.Point(96, 626);
            this.btnDuyet.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnDuyet.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(107, 30);
            this.btnDuyet.TabIndex = 124;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.Visible = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCancel.Location = new System.Drawing.Point(15, 626);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 123;
            this.btnCancel.Text = "Hủy";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExport.Location = new System.Drawing.Point(214, 626);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 30);
            this.btnExport.TabIndex = 122;
            this.btnExport.Text = "Export";
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoPhieu.Location = new System.Drawing.Point(28, 32);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(88, 24);
            this.lblSoPhieu.TabIndex = 125;
            this.lblSoPhieu.Text = "Số Phiếu";
            // 
            // ucNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ucNhapKho";
            this.Size = new System.Drawing.Size(715, 690);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNguyenLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNguyenLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteNguyenLieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.TextBox PhieuNhapKho_NguoiGiao;
        private DevExpress.XtraEditors.LabelControl lblNguoiGiao;
        private DevExpress.XtraEditors.LabelControl lblDiaChi;
        private System.Windows.Forms.RichTextBox PhieuNhapKho_LyDo;
        private DevExpress.XtraEditors.LabelControl lblLyDo;
        private DevExpress.XtraEditors.LabelControl lblNgayNhap;
        private DevExpress.XtraEditors.LabelControl lblKho;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Form.DefaultInfo defaultInfo;
        private System.Windows.Forms.DateTimePicker PhieuNhapKho_NgayNhap;
        private System.Windows.Forms.RichTextBox PhieuNhapKho_DiaChi;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gridNguyenLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNguyenLieu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit NguyenLieuLookUp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDeleteNguyenLieu;
        private System.Windows.Forms.ComboBox PhieuNhapKho_Kho;
        private System.Windows.Forms.ComboBox PhieuNhapKho_DanhGiaId;
        private DevExpress.XtraEditors.LabelControl lblDanhGiaId;
        private DevExpress.XtraEditors.LabelControl lblSoDonHang;
        private DevExpress.XtraEditors.SimpleButton btnDuyet;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.LabelControl lblSoPhieu;
    }
}
