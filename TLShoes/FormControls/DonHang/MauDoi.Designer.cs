using System;

namespace TLShoes.FormControls.DonHang
{
    partial class ucMauDoi
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
            this.MauDoi_DonHangId = new System.Windows.Forms.ComboBox();
            this.lblDonHangId = new DevExpress.XtraEditors.LabelControl();
            this.MauDoi_MauNgay = new System.Windows.Forms.DateTimePicker();
            this.MauDoi_NgayNhan = new System.Windows.Forms.DateTimePicker();
            this.lblNgayNhan = new DevExpress.XtraEditors.LabelControl();
            this.lblMauNgay = new DevExpress.XtraEditors.LabelControl();
            this.MauDoi_GhiChu = new System.Windows.Forms.RichTextBox();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.lblHinh = new DevExpress.XtraEditors.LabelControl();
            this.MauDoi_HinhAnh = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.HinhId = new System.Windows.Forms.RichTextBox();
            this.btnSaveHinh = new DevExpress.XtraEditors.SimpleButton();
            this.GhiChuHinh = new System.Windows.Forms.RichTextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridHinhAnh = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HinhHinh = new DevExpress.XtraEditors.PictureEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.MauDoi_HinhAnh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HinhHinh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MauDoi_DonHangId
            // 
            this.MauDoi_DonHangId.FormattingEnabled = true;
            this.MauDoi_DonHangId.Location = new System.Drawing.Point(179, 34);
            this.MauDoi_DonHangId.Name = "MauDoi_DonHangId";
            this.MauDoi_DonHangId.Size = new System.Drawing.Size(486, 24);
            this.MauDoi_DonHangId.TabIndex = 0;
            // 
            // lblDonHangId
            // 
            this.lblDonHangId.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblDonHangId.Location = new System.Drawing.Point(39, 34);
            this.lblDonHangId.Name = "lblDonHangId";
            this.lblDonHangId.Size = new System.Drawing.Size(56, 16);
            this.lblDonHangId.TabIndex = 39;
            this.lblDonHangId.Text = "Mã Hàng";
            // 
            // MauDoi_MauNgay
            // 
            this.MauDoi_MauNgay.Location = new System.Drawing.Point(179, 127);
            this.MauDoi_MauNgay.Name = "MauDoi_MauNgay";
            this.MauDoi_MauNgay.Size = new System.Drawing.Size(486, 23);
            this.MauDoi_MauNgay.TabIndex = 3;
            // 
            // MauDoi_NgayNhan
            // 
            this.MauDoi_NgayNhan.Location = new System.Drawing.Point(179, 77);
            this.MauDoi_NgayNhan.Name = "MauDoi_NgayNhan";
            this.MauDoi_NgayNhan.Size = new System.Drawing.Size(486, 23);
            this.MauDoi_NgayNhan.TabIndex = 1;
            // 
            // lblNgayNhan
            // 
            this.lblNgayNhan.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblNgayNhan.Location = new System.Drawing.Point(39, 77);
            this.lblNgayNhan.Name = "lblNgayNhan";
            this.lblNgayNhan.Size = new System.Drawing.Size(106, 17);
            this.lblNgayNhan.TabIndex = 42;
            this.lblNgayNhan.Text = "Ngày Xác Nhận";
            // 
            // lblMauNgay
            // 
            this.lblMauNgay.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblMauNgay.Location = new System.Drawing.Point(43, 127);
            this.lblMauNgay.Name = "lblMauNgay";
            this.lblMauNgay.Size = new System.Drawing.Size(69, 17);
            this.lblMauNgay.TabIndex = 41;
            this.lblMauNgay.Text = "Mẫu Ngày";
            // 
            // MauDoi_GhiChu
            // 
            this.MauDoi_GhiChu.Location = new System.Drawing.Point(179, 175);
            this.MauDoi_GhiChu.Name = "MauDoi_GhiChu";
            this.MauDoi_GhiChu.Size = new System.Drawing.Size(486, 96);
            this.MauDoi_GhiChu.TabIndex = 4;
            this.MauDoi_GhiChu.Text = "";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.Location = new System.Drawing.Point(43, 175);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 16);
            this.lblGhiChu.TabIndex = 59;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // lblHinh
            // 
            this.lblHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblHinh.Location = new System.Drawing.Point(327, 518);
            this.lblHinh.Name = "lblHinh";
            this.lblHinh.Size = new System.Drawing.Size(64, 17);
            this.lblHinh.TabIndex = 64;
            this.lblHinh.Text = "Hình Ảnh";
            // 
            // MauDoi_HinhAnh
            // 
            this.MauDoi_HinhAnh.Location = new System.Drawing.Point(257, 298);
            this.MauDoi_HinhAnh.Name = "MauDoi_HinhAnh";
            this.MauDoi_HinhAnh.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.MauDoi_HinhAnh.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.MauDoi_HinhAnh.Size = new System.Drawing.Size(214, 214);
            this.MauDoi_HinhAnh.TabIndex = 5;
            this.MauDoi_HinhAnh.TabStop = true;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl1.Appearance.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.xtraTabControl1.Appearance.Options.UseBorderColor = true;
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.Appearance.Options.UseForeColor = true;
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(708, 594);
            this.xtraTabControl1.TabIndex = 66;
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
            this.xtraTabPage2.Controls.Add(this.MauDoi_GhiChu);
            this.xtraTabPage2.Controls.Add(this.lblHinh);
            this.xtraTabPage2.Controls.Add(this.lblDonHangId);
            this.xtraTabPage2.Controls.Add(this.MauDoi_HinhAnh);
            this.xtraTabPage2.Controls.Add(this.MauDoi_DonHangId);
            this.xtraTabPage2.Controls.Add(this.lblMauNgay);
            this.xtraTabPage2.Controls.Add(this.lblNgayNhan);
            this.xtraTabPage2.Controls.Add(this.MauDoi_NgayNhan);
            this.xtraTabPage2.Controls.Add(this.MauDoi_MauNgay);
            this.xtraTabPage2.Controls.Add(this.lblGhiChu);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(701, 558);
            this.xtraTabPage2.Text = "Mẫu đối";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.BackColor = System.Drawing.Color.Silver;
            this.xtraTabPage1.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.defaultInfo);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(701, 558);
            this.xtraTabPage1.Text = "Thông tin người dùng";
            // 
            // defaultInfo
            // 
            this.defaultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultInfo.Location = new System.Drawing.Point(0, 0);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(701, 558);
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
            this.xtraTabPage3.Controls.Add(this.HinhId);
            this.xtraTabPage3.Controls.Add(this.btnSaveHinh);
            this.xtraTabPage3.Controls.Add(this.GhiChuHinh);
            this.xtraTabPage3.Controls.Add(this.labelControl1);
            this.xtraTabPage3.Controls.Add(this.gridHinhAnh);
            this.xtraTabPage3.Controls.Add(this.HinhHinh);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(701, 558);
            this.xtraTabPage3.Text = "Hình";
            // 
            // HinhId
            // 
            this.HinhId.Enabled = false;
            this.HinhId.Location = new System.Drawing.Point(404, 483);
            this.HinhId.Name = "HinhId";
            this.HinhId.Size = new System.Drawing.Size(25, 21);
            this.HinhId.TabIndex = 63;
            this.HinhId.Text = "";
            this.HinhId.Visible = false;
            // 
            // btnSaveHinh
            // 
            this.btnSaveHinh.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSaveHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveHinh.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveHinh.Appearance.Options.UseBackColor = true;
            this.btnSaveHinh.Appearance.Options.UseFont = true;
            this.btnSaveHinh.Appearance.Options.UseForeColor = true;
            this.btnSaveHinh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnSaveHinh.Location = new System.Drawing.Point(587, 478);
            this.btnSaveHinh.Name = "btnSaveHinh";
            this.btnSaveHinh.Size = new System.Drawing.Size(99, 30);
            this.btnSaveHinh.TabIndex = 62;
            this.btnSaveHinh.Text = "Lưu Hình";
            this.btnSaveHinh.Click += new System.EventHandler(this.btnSaveHinh_Click);
            // 
            // GhiChuHinh
            // 
            this.GhiChuHinh.Location = new System.Drawing.Point(461, 28);
            this.GhiChuHinh.Name = "GhiChuHinh";
            this.GhiChuHinh.Size = new System.Drawing.Size(225, 142);
            this.GhiChuHinh.TabIndex = 60;
            this.GhiChuHinh.Text = "";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(380, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 61;
            this.labelControl1.Text = "Ghi Chú";
            // 
            // gridHinhAnh
            // 
            this.gridHinhAnh.Location = new System.Drawing.Point(22, 28);
            this.gridHinhAnh.MainView = this.gridView1;
            this.gridHinhAnh.Name = "gridHinhAnh";
            this.gridHinhAnh.Size = new System.Drawing.Size(343, 480);
            this.gridHinhAnh.TabIndex = 7;
            this.gridHinhAnh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridHinhAnh;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ghi Chú";
            this.gridColumn1.FieldName = "GhiChu";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Id";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "HinhAnh";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // HinhHinh
            // 
            this.HinhHinh.Location = new System.Drawing.Point(404, 194);
            this.HinhHinh.Name = "HinhHinh";
            this.HinhHinh.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.HinhHinh.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.HinhHinh.Size = new System.Drawing.Size(282, 255);
            this.HinhHinh.TabIndex = 6;
            this.HinhHinh.TabStop = true;
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
            this.btnCancel.Location = new System.Drawing.Point(2, 625);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
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
            this.btnSave.Location = new System.Drawing.Point(451, 625);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 3;
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
            this.btnSaveContinue.Location = new System.Drawing.Point(532, 625);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(179, 30);
            this.btnSaveContinue.TabIndex = 0;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            // 
            // ucMauDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ucMauDoi";
            this.Size = new System.Drawing.Size(716, 682);
            ((System.ComponentModel.ISupportInitialize)(this.MauDoi_HinhAnh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HinhHinh.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox MauDoi_DonHangId;
        private DevExpress.XtraEditors.LabelControl lblDonHangId;
        private System.Windows.Forms.DateTimePicker MauDoi_MauNgay;
        private System.Windows.Forms.DateTimePicker MauDoi_NgayNhan;
        private DevExpress.XtraEditors.LabelControl lblNgayNhan;
        private DevExpress.XtraEditors.LabelControl lblMauNgay;
        private System.Windows.Forms.RichTextBox MauDoi_GhiChu;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.LabelControl lblHinh;
        private DevExpress.XtraEditors.PictureEdit MauDoi_HinhAnh;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private Form.DefaultInfo defaultInfo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private System.Windows.Forms.RichTextBox GhiChuHinh;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridHinhAnh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PictureEdit HinhHinh;
        private DevExpress.XtraEditors.SimpleButton btnSaveHinh;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.RichTextBox HinhId;
    }
}
