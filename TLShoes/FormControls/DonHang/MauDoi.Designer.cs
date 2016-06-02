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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.MauDoi_HinhAnh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MauDoi_DonHangId
            // 
            this.MauDoi_DonHangId.FormattingEnabled = true;
            this.MauDoi_DonHangId.Location = new System.Drawing.Point(179, 34);
            this.MauDoi_DonHangId.Name = "MauDoi_DonHangId";
            this.MauDoi_DonHangId.Size = new System.Drawing.Size(486, 24);
            this.MauDoi_DonHangId.TabIndex = 40;
            // 
            // lblDonHangId
            // 
            this.lblDonHangId.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblDonHangId.Location = new System.Drawing.Point(39, 34);
            this.lblDonHangId.Name = "lblDonHangId";
            this.lblDonHangId.Size = new System.Drawing.Size(63, 16);
            this.lblDonHangId.TabIndex = 39;
            this.lblDonHangId.Text = "Đơn Hàng";
            // 
            // MauDoi_MauNgay
            // 
            this.MauDoi_MauNgay.Location = new System.Drawing.Point(179, 127);
            this.MauDoi_MauNgay.Name = "MauDoi_MauNgay";
            this.MauDoi_MauNgay.Size = new System.Drawing.Size(486, 23);
            this.MauDoi_MauNgay.TabIndex = 44;
            // 
            // MauDoi_NgayNhan
            // 
            this.MauDoi_NgayNhan.Location = new System.Drawing.Point(179, 77);
            this.MauDoi_NgayNhan.Name = "MauDoi_NgayNhan";
            this.MauDoi_NgayNhan.Size = new System.Drawing.Size(486, 23);
            this.MauDoi_NgayNhan.TabIndex = 43;
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
            this.MauDoi_GhiChu.TabIndex = 60;
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
            this.MauDoi_HinhAnh.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.MauDoi_HinhAnh.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.MauDoi_HinhAnh.Size = new System.Drawing.Size(214, 214);
            this.MauDoi_HinhAnh.TabIndex = 65;
            this.MauDoi_HinhAnh.TabStop = true;
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
            this.xtraTabControl1.Size = new System.Drawing.Size(708, 594);
            this.xtraTabControl1.TabIndex = 66;
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
            this.xtraTabPage1.Size = new System.Drawing.Size(701, 443);
            this.xtraTabPage1.Text = "Thông tin người dùng";
            // 
            // defaultInfo
            // 
            this.defaultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultInfo.Location = new System.Drawing.Point(0, 0);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(701, 443);
            this.defaultInfo.TabIndex = 11;
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
            this.btnCancel.TabIndex = 67;
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
            this.btnSave.TabIndex = 68;
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
            this.btnSaveContinue.TabIndex = 69;
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
    }
}
