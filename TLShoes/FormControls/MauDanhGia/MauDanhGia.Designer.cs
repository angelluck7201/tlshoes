namespace TLShoes.FormControls.MauDanhGia
{
    partial class ucMauDanhGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMauDanhGia));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridTieuChi = new DevExpress.XtraGrid.GridControl();
            this.gridViewTieuChi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TieuChiLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDeleteTieuChi = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.MauDanhGia_GhiChu = new System.Windows.Forms.RichTextBox();
            this.lblMauDanhGia = new DevExpress.XtraEditors.LabelControl();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.MauDanhGia_TenMau = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTieuChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTieuChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TieuChiLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTieuChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MauDanhGia_TenMau.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
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
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(698, 677);
            this.xtraTabControl1.TabIndex = 15;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
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
            this.xtraTabPage2.Controls.Add(this.gridTieuChi);
            this.xtraTabPage2.Controls.Add(this.MauDanhGia_GhiChu);
            this.xtraTabPage2.Controls.Add(this.lblMauDanhGia);
            this.xtraTabPage2.Controls.Add(this.lblGhiChu);
            this.xtraTabPage2.Controls.Add(this.MauDanhGia_TenMau);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(691, 641);
            this.xtraTabPage2.Text = "Mẫu Đánh Giá";
            // 
            // gridTieuChi
            // 
            this.gridTieuChi.Location = new System.Drawing.Point(22, 233);
            this.gridTieuChi.MainView = this.gridViewTieuChi;
            this.gridTieuChi.Name = "gridTieuChi";
            this.gridTieuChi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TieuChiLookUp,
            this.btnDeleteTieuChi});
            this.gridTieuChi.Size = new System.Drawing.Size(658, 405);
            this.gridTieuChi.TabIndex = 2;
            this.gridTieuChi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTieuChi});
            // 
            // gridViewTieuChi
            // 
            this.gridViewTieuChi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn14});
            this.gridViewTieuChi.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridViewTieuChi.GridControl = this.gridTieuChi;
            this.gridViewTieuChi.Name = "gridViewTieuChi";
            this.gridViewTieuChi.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewTieuChi.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridViewTieuChi.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridViewTieuChi.OptionsCustomization.AllowGroup = false;
            this.gridViewTieuChi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridViewTieuChi.OptionsView.ShowGroupPanel = false;
            this.gridViewTieuChi.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tiêu Chí Đánh Giá";
            this.gridColumn6.ColumnEdit = this.TieuChiLookUp;
            this.gridColumn6.FieldName = "TieuChiId";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 592;
            // 
            // TieuChiLookUp
            // 
            this.TieuChiLookUp.AutoHeight = false;
            this.TieuChiLookUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TieuChiLookUp.Name = "TieuChiLookUp";
            // 
            // gridColumn14
            // 
            this.gridColumn14.ColumnEdit = this.btnDeleteTieuChi;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 46;
            // 
            // btnDeleteTieuChi
            // 
            this.btnDeleteTieuChi.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTieuChi.Appearance.Image")));
            this.btnDeleteTieuChi.Appearance.Options.UseImage = true;
            this.btnDeleteTieuChi.AutoHeight = false;
            serializableAppearanceObject1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            serializableAppearanceObject1.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            serializableAppearanceObject1.Image = ((System.Drawing.Image)(resources.GetObject("serializableAppearanceObject1.Image")));
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject1.Options.UseBorderColor = true;
            serializableAppearanceObject1.Options.UseImage = true;
            this.btnDeleteTieuChi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.Default, ((System.Drawing.Image)(resources.GetObject("btnDeleteTieuChi.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Nhấp đúp để xóa", null, null, true)});
            this.btnDeleteTieuChi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.btnDeleteTieuChi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeleteTieuChi.Name = "btnDeleteTieuChi";
            this.btnDeleteTieuChi.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // MauDanhGia_GhiChu
            // 
            this.MauDanhGia_GhiChu.Location = new System.Drawing.Point(151, 63);
            this.MauDanhGia_GhiChu.Name = "MauDanhGia_GhiChu";
            this.MauDanhGia_GhiChu.Size = new System.Drawing.Size(529, 148);
            this.MauDanhGia_GhiChu.TabIndex = 1;
            this.MauDanhGia_GhiChu.Text = "";
            // 
            // lblMauDanhGia
            // 
            this.lblMauDanhGia.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblMauDanhGia.Location = new System.Drawing.Point(22, 25);
            this.lblMauDanhGia.Name = "lblMauDanhGia";
            this.lblMauDanhGia.Size = new System.Drawing.Size(59, 17);
            this.lblMauDanhGia.TabIndex = 0;
            this.lblMauDanhGia.Text = "Tên Mẫu";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.Location = new System.Drawing.Point(22, 63);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 16);
            this.lblGhiChu.TabIndex = 1;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // MauDanhGia_TenMau
            // 
            this.MauDanhGia_TenMau.Location = new System.Drawing.Point(151, 23);
            this.MauDanhGia_TenMau.Name = "MauDanhGia_TenMau";
            this.MauDanhGia_TenMau.Size = new System.Drawing.Size(529, 22);
            this.MauDanhGia_TenMau.TabIndex = 0;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.BackColor = System.Drawing.Color.Silver;
            this.xtraTabPage1.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.defaultInfo);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(691, 641);
            this.xtraTabPage1.Text = "Thông tin người dùng";
            // 
            // defaultInfo
            // 
            this.defaultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultInfo.Location = new System.Drawing.Point(0, 0);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(691, 641);
            this.defaultInfo.TabIndex = 11;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.ForestGreen;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButton1.Location = new System.Drawing.Point(517, 697);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(179, 30);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Lưu Và Tiếp Tục";
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
            this.btnSave.Location = new System.Drawing.Point(431, 697);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
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
            this.btnCancel.Location = new System.Drawing.Point(9, 697);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            // 
            // ucMauDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ucMauDanhGia";
            this.Size = new System.Drawing.Size(703, 751);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTieuChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTieuChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TieuChiLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTieuChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MauDanhGia_TenMau.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.RichTextBox MauDanhGia_GhiChu;
        private DevExpress.XtraEditors.LabelControl lblMauDanhGia;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.TextEdit MauDanhGia_TenMau;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Form.DefaultInfo defaultInfo;
        private DevExpress.XtraGrid.GridControl gridTieuChi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTieuChi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit TieuChiLookUp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDeleteTieuChi;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
