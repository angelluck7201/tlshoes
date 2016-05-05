﻿using System;

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
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.MauDoi_DonHangId = new System.Windows.Forms.ComboBox();
            this.lblDonHangId = new DevExpress.XtraEditors.LabelControl();
            this.MauDoi_MauNgay = new System.Windows.Forms.DateTimePicker();
            this.MauDoi_NgayNhan = new System.Windows.Forms.DateTimePicker();
            this.lblNgayNhan = new DevExpress.XtraEditors.LabelControl();
            this.lblMauNgay = new DevExpress.XtraEditors.LabelControl();
            this.MauDoi_GhiChu = new System.Windows.Forms.RichTextBox();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // defaultInfo
            // 
            this.defaultInfo.Location = new System.Drawing.Point(3, 3);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(425, 150);
            this.defaultInfo.TabIndex = 26;
            // 
            // MauDoi_DonHangId
            // 
            this.MauDoi_DonHangId.FormattingEnabled = true;
            this.MauDoi_DonHangId.Location = new System.Drawing.Point(118, 197);
            this.MauDoi_DonHangId.Name = "MauDoi_DonHangId";
            this.MauDoi_DonHangId.Size = new System.Drawing.Size(421, 24);
            this.MauDoi_DonHangId.TabIndex = 40;
            // 
            // lblDonHangId
            // 
            this.lblDonHangId.Location = new System.Drawing.Point(7, 197);
            this.lblDonHangId.Name = "lblDonHangId";
            this.lblDonHangId.Size = new System.Drawing.Size(56, 16);
            this.lblDonHangId.TabIndex = 39;
            this.lblDonHangId.Text = "Đơn Hàng";
            // 
            // MauDoi_MauNgay
            // 
            this.MauDoi_MauNgay.Location = new System.Drawing.Point(118, 281);
            this.MauDoi_MauNgay.Name = "MauDoi_MauNgay";
            this.MauDoi_MauNgay.Size = new System.Drawing.Size(421, 22);
            this.MauDoi_MauNgay.TabIndex = 44;
            // 
            // MauDoi_NgayNhan
            // 
            this.MauDoi_NgayNhan.Location = new System.Drawing.Point(118, 240);
            this.MauDoi_NgayNhan.Name = "MauDoi_NgayNhan";
            this.MauDoi_NgayNhan.Size = new System.Drawing.Size(421, 22);
            this.MauDoi_NgayNhan.TabIndex = 43;
            // 
            // lblNgayNhan
            // 
            this.lblNgayNhan.Location = new System.Drawing.Point(7, 240);
            this.lblNgayNhan.Name = "lblNgayNhan";
            this.lblNgayNhan.Size = new System.Drawing.Size(94, 17);
            this.lblNgayNhan.TabIndex = 42;
            this.lblNgayNhan.Text = "Ngày Xác Nhận";
            // 
            // lblMauNgay
            // 
            this.lblMauNgay.Location = new System.Drawing.Point(7, 281);
            this.lblMauNgay.Name = "lblMauNgay";
            this.lblMauNgay.Size = new System.Drawing.Size(61, 17);
            this.lblMauNgay.TabIndex = 41;
            this.lblMauNgay.Text = "Mẫu Ngày";
            // 
            // MauDoi_GhiChu
            // 
            this.MauDoi_GhiChu.Location = new System.Drawing.Point(118, 331);
            this.MauDoi_GhiChu.Name = "MauDoi_GhiChu";
            this.MauDoi_GhiChu.Size = new System.Drawing.Size(421, 96);
            this.MauDoi_GhiChu.TabIndex = 60;
            this.MauDoi_GhiChu.Text = "";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(11, 331);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(44, 16);
            this.lblGhiChu.TabIndex = 59;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Location = new System.Drawing.Point(246, 468);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(131, 23);
            this.btnSaveContinue.TabIndex = 63;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            this.btnSaveContinue.Click += new EventHandler(this.btnSaveContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(464, 468);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 62;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // ucMauDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.MauDoi_GhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.MauDoi_MauNgay);
            this.Controls.Add(this.MauDoi_NgayNhan);
            this.Controls.Add(this.lblNgayNhan);
            this.Controls.Add(this.lblMauNgay);
            this.Controls.Add(this.MauDoi_DonHangId);
            this.Controls.Add(this.lblDonHangId);
            this.Controls.Add(this.defaultInfo);
            this.Name = "ucMauDoi";
            this.Size = new System.Drawing.Size(555, 509);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Form.DefaultInfo defaultInfo;
        private System.Windows.Forms.ComboBox MauDoi_DonHangId;
        private DevExpress.XtraEditors.LabelControl lblDonHangId;
        private System.Windows.Forms.DateTimePicker MauDoi_MauNgay;
        private System.Windows.Forms.DateTimePicker MauDoi_NgayNhan;
        private DevExpress.XtraEditors.LabelControl lblNgayNhan;
        private DevExpress.XtraEditors.LabelControl lblMauNgay;
        private System.Windows.Forms.RichTextBox MauDoi_GhiChu;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
