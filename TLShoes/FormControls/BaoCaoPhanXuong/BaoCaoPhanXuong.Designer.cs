using System;

namespace TLShoes.FormControls.BaoCaoPhanXuong
{
    partial class ucBaoCaoPhanXuong
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
            this.BaoCaoPhanXuong_GhiChu = new System.Windows.Forms.RichTextBox();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.BaoCaoPhanXuong_BaoCaoNgay = new System.Windows.Forms.DateTimePicker();
            this.lblBaoCaoNgay = new DevExpress.XtraEditors.LabelControl();
            this.BaoCaoPhanXuong_SanLuongThucHien = new System.Windows.Forms.TextBox();
            this.BaoCaoPhanXuong_SanLuongKhoan = new System.Windows.Forms.TextBox();
            this.lblSanLuongThucHien = new DevExpress.XtraEditors.LabelControl();
            this.lblSanLuongKhoan = new DevExpress.XtraEditors.LabelControl();
            this.BaoCaoPhanXuong_PhanXuongId = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BaoCaoPhanXuong_DonHangId = new System.Windows.Forms.ComboBox();
            this.lblDonHangId = new DevExpress.XtraEditors.LabelControl();
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // BaoCaoPhanXuong_GhiChu
            // 
            this.BaoCaoPhanXuong_GhiChu.Location = new System.Drawing.Point(159, 379);
            this.BaoCaoPhanXuong_GhiChu.Name = "BaoCaoPhanXuong_GhiChu";
            this.BaoCaoPhanXuong_GhiChu.Size = new System.Drawing.Size(529, 96);
            this.BaoCaoPhanXuong_GhiChu.TabIndex = 89;
            this.BaoCaoPhanXuong_GhiChu.Text = "";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(10, 379);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(44, 16);
            this.lblGhiChu.TabIndex = 88;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // BaoCaoPhanXuong_BaoCaoNgay
            // 
            this.BaoCaoPhanXuong_BaoCaoNgay.Location = new System.Drawing.Point(159, 339);
            this.BaoCaoPhanXuong_BaoCaoNgay.Name = "BaoCaoPhanXuong_BaoCaoNgay";
            this.BaoCaoPhanXuong_BaoCaoNgay.Size = new System.Drawing.Size(529, 22);
            this.BaoCaoPhanXuong_BaoCaoNgay.TabIndex = 87;
            // 
            // lblBaoCaoNgay
            // 
            this.lblBaoCaoNgay.Location = new System.Drawing.Point(10, 339);
            this.lblBaoCaoNgay.Name = "lblBaoCaoNgay";
            this.lblBaoCaoNgay.Size = new System.Drawing.Size(79, 16);
            this.lblBaoCaoNgay.TabIndex = 86;
            this.lblBaoCaoNgay.Text = "Báo Cáo Ngày";
            // 
            // BaoCaoPhanXuong_SanLuongThucHien
            // 
            this.BaoCaoPhanXuong_SanLuongThucHien.Location = new System.Drawing.Point(159, 300);
            this.BaoCaoPhanXuong_SanLuongThucHien.Name = "BaoCaoPhanXuong_SanLuongThucHien";
            this.BaoCaoPhanXuong_SanLuongThucHien.Size = new System.Drawing.Size(529, 22);
            this.BaoCaoPhanXuong_SanLuongThucHien.TabIndex = 85;
            this.BaoCaoPhanXuong_SanLuongThucHien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaoCaoPhanXuong_SanLuongThucHien_KeyPress);
            // 
            // BaoCaoPhanXuong_SanLuongKhoan
            // 
            this.BaoCaoPhanXuong_SanLuongKhoan.Location = new System.Drawing.Point(159, 262);
            this.BaoCaoPhanXuong_SanLuongKhoan.Name = "BaoCaoPhanXuong_SanLuongKhoan";
            this.BaoCaoPhanXuong_SanLuongKhoan.Size = new System.Drawing.Size(529, 22);
            this.BaoCaoPhanXuong_SanLuongKhoan.TabIndex = 84;
            this.BaoCaoPhanXuong_SanLuongKhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaoCaoPhanXuong_SanLuongKhoan_KeyPress);
            // 
            // lblSanLuongThucHien
            // 
            this.lblSanLuongThucHien.Location = new System.Drawing.Point(8, 300);
            this.lblSanLuongThucHien.Name = "lblSanLuongThucHien";
            this.lblSanLuongThucHien.Size = new System.Drawing.Size(128, 17);
            this.lblSanLuongThucHien.TabIndex = 83;
            this.lblSanLuongThucHien.Text = "Sản lượng Thực Hiện";
            // 
            // lblSanLuongKhoan
            // 
            this.lblSanLuongKhoan.Location = new System.Drawing.Point(8, 262);
            this.lblSanLuongKhoan.Name = "lblSanLuongKhoan";
            this.lblSanLuongKhoan.Size = new System.Drawing.Size(105, 17);
            this.lblSanLuongKhoan.TabIndex = 82;
            this.lblSanLuongKhoan.Text = "Sản lượng Khoán";
            // 
            // BaoCaoPhanXuong_PhanXuongId
            // 
            this.BaoCaoPhanXuong_PhanXuongId.FormattingEnabled = true;
            this.BaoCaoPhanXuong_PhanXuongId.Location = new System.Drawing.Point(159, 219);
            this.BaoCaoPhanXuong_PhanXuongId.Name = "BaoCaoPhanXuong_PhanXuongId";
            this.BaoCaoPhanXuong_PhanXuongId.Size = new System.Drawing.Size(529, 24);
            this.BaoCaoPhanXuong_PhanXuongId.TabIndex = 81;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 219);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 17);
            this.labelControl1.TabIndex = 80;
            this.labelControl1.Text = "Phân Xưởng";
            // 
            // BaoCaoPhanXuong_DonHangId
            // 
            this.BaoCaoPhanXuong_DonHangId.FormattingEnabled = true;
            this.BaoCaoPhanXuong_DonHangId.Location = new System.Drawing.Point(159, 179);
            this.BaoCaoPhanXuong_DonHangId.Name = "BaoCaoPhanXuong_DonHangId";
            this.BaoCaoPhanXuong_DonHangId.Size = new System.Drawing.Size(529, 24);
            this.BaoCaoPhanXuong_DonHangId.TabIndex = 79;
            // 
            // lblDonHangId
            // 
            this.lblDonHangId.Location = new System.Drawing.Point(8, 179);
            this.lblDonHangId.Name = "lblDonHangId";
            this.lblDonHangId.Size = new System.Drawing.Size(56, 16);
            this.lblDonHangId.TabIndex = 78;
            this.lblDonHangId.Text = "Đơn Hàng";
            // 
            // defaultInfo
            // 
            this.defaultInfo.Location = new System.Drawing.Point(0, 3);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(425, 150);
            this.defaultInfo.TabIndex = 77;
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Location = new System.Drawing.Point(395, 498);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(131, 23);
            this.btnSaveContinue.TabIndex = 92;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            this.btnSaveContinue.Click+= new EventHandler(this.btnSaveContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(613, 498);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 91;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click+= new EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(532, 498);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 90;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click+= new EventHandler(this.btnSave_Click);
            // 
            // ucBaoCaoPhanXuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.BaoCaoPhanXuong_GhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.BaoCaoPhanXuong_BaoCaoNgay);
            this.Controls.Add(this.lblBaoCaoNgay);
            this.Controls.Add(this.BaoCaoPhanXuong_SanLuongThucHien);
            this.Controls.Add(this.BaoCaoPhanXuong_SanLuongKhoan);
            this.Controls.Add(this.lblSanLuongThucHien);
            this.Controls.Add(this.lblSanLuongKhoan);
            this.Controls.Add(this.BaoCaoPhanXuong_PhanXuongId);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.BaoCaoPhanXuong_DonHangId);
            this.Controls.Add(this.lblDonHangId);
            this.Controls.Add(this.defaultInfo);
            this.Name = "ucBaoCaoPhanXuong";
            this.Size = new System.Drawing.Size(722, 543);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox BaoCaoPhanXuong_GhiChu;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private System.Windows.Forms.DateTimePicker BaoCaoPhanXuong_BaoCaoNgay;
        private DevExpress.XtraEditors.LabelControl lblBaoCaoNgay;
        private System.Windows.Forms.TextBox BaoCaoPhanXuong_SanLuongThucHien;
        private System.Windows.Forms.TextBox BaoCaoPhanXuong_SanLuongKhoan;
        private DevExpress.XtraEditors.LabelControl lblSanLuongThucHien;
        private DevExpress.XtraEditors.LabelControl lblSanLuongKhoan;
        private System.Windows.Forms.ComboBox BaoCaoPhanXuong_PhanXuongId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox BaoCaoPhanXuong_DonHangId;
        private DevExpress.XtraEditors.LabelControl lblDonHangId;
        private Form.DefaultInfo defaultInfo;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
