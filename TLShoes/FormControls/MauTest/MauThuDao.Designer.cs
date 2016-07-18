namespace TLShoes.FormControls.MauThuDao
{
    partial class ucMauThuDao
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
            this.MauThuDao_DonHangId = new System.Windows.Forms.ComboBox();
            this.lblDonHangId = new DevExpress.XtraEditors.LabelControl();
            this.MauThuDao_NgayHoanThanh = new System.Windows.Forms.DateTimePicker();
            this.lblNgayHoanThanh = new DevExpress.XtraEditors.LabelControl();
            this.MauThuDao_NgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayBatDau = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.txtGopY = new System.Windows.Forms.RichTextBox();
            this.lblGopY = new DevExpress.XtraEditors.LabelControl();
            this.gridGopY = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            this.lblThuDao = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGopY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // MauThuDao_DonHangId
            // 
            this.MauThuDao_DonHangId.FormattingEnabled = true;
            this.MauThuDao_DonHangId.Location = new System.Drawing.Point(165, 42);
            this.MauThuDao_DonHangId.Name = "MauThuDao_DonHangId";
            this.MauThuDao_DonHangId.Size = new System.Drawing.Size(529, 24);
            this.MauThuDao_DonHangId.TabIndex = 0;
            this.MauThuDao_DonHangId.SelectedIndexChanged += new System.EventHandler(this.MauThuDao_DonHangId_SelectedIndexChanged);
            // 
            // lblDonHangId
            // 
            this.lblDonHangId.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblDonHangId.Location = new System.Drawing.Point(35, 44);
            this.lblDonHangId.Name = "lblDonHangId";
            this.lblDonHangId.Size = new System.Drawing.Size(56, 16);
            this.lblDonHangId.TabIndex = 39;
            this.lblDonHangId.Text = "Mã Hàng";
            // 
            // MauThuDao_NgayHoanThanh
            // 
            this.MauThuDao_NgayHoanThanh.Location = new System.Drawing.Point(163, 132);
            this.MauThuDao_NgayHoanThanh.Name = "MauThuDao_NgayHoanThanh";
            this.MauThuDao_NgayHoanThanh.Size = new System.Drawing.Size(529, 23);
            this.MauThuDao_NgayHoanThanh.TabIndex = 2;
            // 
            // lblNgayHoanThanh
            // 
            this.lblNgayHoanThanh.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNgayHoanThanh.Location = new System.Drawing.Point(33, 134);
            this.lblNgayHoanThanh.Name = "lblNgayHoanThanh";
            this.lblNgayHoanThanh.Size = new System.Drawing.Size(112, 16);
            this.lblNgayHoanThanh.TabIndex = 41;
            this.lblNgayHoanThanh.Text = "Ngày Hoàn Thành";
            // 
            // MauThuDao_NgayBatDau
            // 
            this.MauThuDao_NgayBatDau.Location = new System.Drawing.Point(165, 87);
            this.MauThuDao_NgayBatDau.Name = "MauThuDao_NgayBatDau";
            this.MauThuDao_NgayBatDau.Size = new System.Drawing.Size(529, 23);
            this.MauThuDao_NgayBatDau.TabIndex = 1;
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNgayBatDau.Location = new System.Drawing.Point(35, 89);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(96, 17);
            this.lblNgayBatDau.TabIndex = 68;
            this.lblNgayBatDau.Text = "Ngày Bắt Đầu";
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
            this.xtraTabControl1.Size = new System.Drawing.Size(708, 456);
            this.xtraTabControl1.TabIndex = 70;
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
            this.xtraTabPage2.Controls.Add(this.lblThuDao);
            this.xtraTabPage2.Controls.Add(this.lblDonHangId);
            this.xtraTabPage2.Controls.Add(this.MauThuDao_NgayBatDau);
            this.xtraTabPage2.Controls.Add(this.MauThuDao_DonHangId);
            this.xtraTabPage2.Controls.Add(this.lblNgayBatDau);
            this.xtraTabPage2.Controls.Add(this.lblNgayHoanThanh);
            this.xtraTabPage2.Controls.Add(this.MauThuDao_NgayHoanThanh);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(701, 420);
            this.xtraTabPage2.Text = "Mẫu Thử Dao";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.BackColor = System.Drawing.Color.Silver;
            this.xtraTabPage1.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.defaultInfo);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(701, 420);
            this.xtraTabPage1.Text = "Thông tin người dùng";
            // 
            // defaultInfo
            // 
            this.defaultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultInfo.Location = new System.Drawing.Point(0, 0);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(701, 420);
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
            this.xtraTabPage3.Controls.Add(this.txtGopY);
            this.xtraTabPage3.Controls.Add(this.lblGopY);
            this.xtraTabPage3.Controls.Add(this.gridGopY);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(701, 420);
            this.xtraTabPage3.Text = "Góp Ý";
            // 
            // txtGopY
            // 
            this.txtGopY.Location = new System.Drawing.Point(156, 303);
            this.txtGopY.Name = "txtGopY";
            this.txtGopY.Size = new System.Drawing.Size(529, 96);
            this.txtGopY.TabIndex = 72;
            this.txtGopY.Text = "";
            this.txtGopY.Leave += new System.EventHandler(this.txtGopY_Leave);
            // 
            // lblGopY
            // 
            this.lblGopY.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblGopY.Location = new System.Drawing.Point(36, 303);
            this.lblGopY.Name = "lblGopY";
            this.lblGopY.Size = new System.Drawing.Size(17, 16);
            this.lblGopY.TabIndex = 71;
            this.lblGopY.Text = "QC";
            // 
            // gridGopY
            // 
            this.gridGopY.Location = new System.Drawing.Point(15, 14);
            this.gridGopY.MainView = this.gridView1;
            this.gridGopY.Name = "gridGopY";
            this.gridGopY.Size = new System.Drawing.Size(670, 269);
            this.gridGopY.TabIndex = 70;
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
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Bộ Phận";
            this.gridColumn4.FieldName = "BoPhan";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 147;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Góp Ý";
            this.gridColumn5.FieldName = "GopY";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 482;
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
            this.btnCancel.Location = new System.Drawing.Point(4, 476);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 2;
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
            this.btnSave.Location = new System.Drawing.Point(451, 476);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
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
            this.btnSaveContinue.Location = new System.Drawing.Point(532, 476);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(179, 30);
            this.btnSaveContinue.TabIndex = 1;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            // 
            // lblThuDao
            // 
            this.lblThuDao.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblThuDao.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblThuDao.Location = new System.Drawing.Point(247, 189);
            this.lblThuDao.Name = "lblThuDao";
            this.lblThuDao.Size = new System.Drawing.Size(167, 17);
            this.lblThuDao.TabIndex = 69;
            this.lblThuDao.Text = "Dao này đã được thử rồi";
            // 
            // ucMauThuDao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ucMauThuDao";
            this.Size = new System.Drawing.Size(718, 542);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGopY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox MauThuDao_DonHangId;
        private DevExpress.XtraEditors.LabelControl lblDonHangId;
        private System.Windows.Forms.DateTimePicker MauThuDao_NgayHoanThanh;
        private DevExpress.XtraEditors.LabelControl lblNgayHoanThanh;
        private System.Windows.Forms.DateTimePicker MauThuDao_NgayBatDau;
        private DevExpress.XtraEditors.LabelControl lblNgayBatDau;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Form.DefaultInfo defaultInfo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gridGopY;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.RichTextBox txtGopY;
        private DevExpress.XtraEditors.LabelControl lblGopY;
        private DevExpress.XtraEditors.LabelControl lblThuDao;
    }
}
