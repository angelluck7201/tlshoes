namespace TLShoes.FormControls.NguyenLieu
{
    partial class ucNguyenLieu
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
            this.NguyenLieu_LoaiNguyenLieuId = new System.Windows.Forms.ComboBox();
            this.lblLoaiNguyenLieuId = new DevExpress.XtraEditors.LabelControl();
            this.NguyenLieu_Ten = new System.Windows.Forms.TextBox();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.NguyenLieu_MaNguyenLieu = new System.Windows.Forms.TextBox();
            this.lblMaNguyenLieu = new DevExpress.XtraEditors.LabelControl();
            this.NguyenLieu_DonViTinh = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.NguyenLieu_SoLuong = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.NguyenLieu_GhiChu = new System.Windows.Forms.RichTextBox();
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
            this.defaultInfo.TabIndex = 78;
            // 
            // NguyenLieu_LoaiNguyenLieuId
            // 
            this.NguyenLieu_LoaiNguyenLieuId.FormattingEnabled = true;
            this.NguyenLieu_LoaiNguyenLieuId.Location = new System.Drawing.Point(165, 192);
            this.NguyenLieu_LoaiNguyenLieuId.Name = "NguyenLieu_LoaiNguyenLieuId";
            this.NguyenLieu_LoaiNguyenLieuId.Size = new System.Drawing.Size(529, 24);
            this.NguyenLieu_LoaiNguyenLieuId.TabIndex = 81;
            // 
            // lblLoaiNguyenLieuId
            // 
            this.lblLoaiNguyenLieuId.Location = new System.Drawing.Point(14, 192);
            this.lblLoaiNguyenLieuId.Name = "lblLoaiNguyenLieuId";
            this.lblLoaiNguyenLieuId.Size = new System.Drawing.Size(104, 17);
            this.lblLoaiNguyenLieuId.TabIndex = 80;
            this.lblLoaiNguyenLieuId.Text = "Loại Nguyên Liệu";
            // 
            // NguyenLieu_Ten
            // 
            this.NguyenLieu_Ten.Location = new System.Drawing.Point(165, 238);
            this.NguyenLieu_Ten.Name = "NguyenLieu_Ten";
            this.NguyenLieu_Ten.Size = new System.Drawing.Size(529, 22);
            this.NguyenLieu_Ten.TabIndex = 86;
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(14, 238);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(103, 17);
            this.lblTen.TabIndex = 85;
            this.lblTen.Text = "Tên Nguyên Liệu";
            // 
            // NguyenLieu_MaNguyenLieu
            // 
            this.NguyenLieu_MaNguyenLieu.Location = new System.Drawing.Point(165, 276);
            this.NguyenLieu_MaNguyenLieu.Name = "NguyenLieu_MaNguyenLieu";
            this.NguyenLieu_MaNguyenLieu.Size = new System.Drawing.Size(529, 22);
            this.NguyenLieu_MaNguyenLieu.TabIndex = 88;
            // 
            // lblMaNguyenLieu
            // 
            this.lblMaNguyenLieu.Location = new System.Drawing.Point(14, 276);
            this.lblMaNguyenLieu.Name = "lblMaNguyenLieu";
            this.lblMaNguyenLieu.Size = new System.Drawing.Size(97, 17);
            this.lblMaNguyenLieu.TabIndex = 87;
            this.lblMaNguyenLieu.Text = "Mã Nguyên Liệu";
            // 
            // NguyenLieu_DonViTinh
            // 
            this.NguyenLieu_DonViTinh.FormattingEnabled = true;
            this.NguyenLieu_DonViTinh.Location = new System.Drawing.Point(165, 315);
            this.NguyenLieu_DonViTinh.Name = "NguyenLieu_DonViTinh";
            this.NguyenLieu_DonViTinh.Size = new System.Drawing.Size(529, 24);
            this.NguyenLieu_DonViTinh.TabIndex = 90;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 315);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 17);
            this.labelControl1.TabIndex = 89;
            this.labelControl1.Text = "Đơn Vị Tính";
            // 
            // NguyenLieu_SoLuong
            // 
            this.NguyenLieu_SoLuong.Location = new System.Drawing.Point(165, 362);
            this.NguyenLieu_SoLuong.Name = "NguyenLieu_SoLuong";
            this.NguyenLieu_SoLuong.Size = new System.Drawing.Size(529, 22);
            this.NguyenLieu_SoLuong.TabIndex = 92;
            this.NguyenLieu_SoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NguyenLieu_SoLuong_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 362);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 17);
            this.labelControl2.TabIndex = 91;
            this.labelControl2.Text = "Số Lượng";
            // 
            // NguyenLieu_GhiChu
            // 
            this.NguyenLieu_GhiChu.Location = new System.Drawing.Point(165, 412);
            this.NguyenLieu_GhiChu.Name = "NguyenLieu_GhiChu";
            this.NguyenLieu_GhiChu.Size = new System.Drawing.Size(529, 96);
            this.NguyenLieu_GhiChu.TabIndex = 94;
            this.NguyenLieu_GhiChu.Text = "";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(16, 412);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(44, 16);
            this.lblGhiChu.TabIndex = 93;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Location = new System.Drawing.Point(401, 526);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(131, 23);
            this.btnSaveContinue.TabIndex = 97;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(619, 526);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 96;
            this.btnCancel.Text = "Hủy";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(538, 526);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 95;
            this.btnSave.Text = "Lưu";
            // 
            // ucNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.NguyenLieu_GhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.NguyenLieu_SoLuong);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.NguyenLieu_DonViTinh);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.NguyenLieu_MaNguyenLieu);
            this.Controls.Add(this.lblMaNguyenLieu);
            this.Controls.Add(this.NguyenLieu_Ten);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.NguyenLieu_LoaiNguyenLieuId);
            this.Controls.Add(this.lblLoaiNguyenLieuId);
            this.Controls.Add(this.defaultInfo);
            this.Name = "ucNguyenLieu";
            this.Size = new System.Drawing.Size(717, 569);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Form.DefaultInfo defaultInfo;
        private System.Windows.Forms.ComboBox NguyenLieu_LoaiNguyenLieuId;
        private DevExpress.XtraEditors.LabelControl lblLoaiNguyenLieuId;
        private System.Windows.Forms.TextBox NguyenLieu_Ten;
        private DevExpress.XtraEditors.LabelControl lblTen;
        private System.Windows.Forms.TextBox NguyenLieu_MaNguyenLieu;
        private DevExpress.XtraEditors.LabelControl lblMaNguyenLieu;
        private System.Windows.Forms.ComboBox NguyenLieu_DonViTinh;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox NguyenLieu_SoLuong;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RichTextBox NguyenLieu_GhiChu;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
