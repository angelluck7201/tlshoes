using TLShoes.Form;

namespace TLShoes
{
    partial class ucDanhMuc
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
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.DanhMuc_Ten = new DevExpress.XtraEditors.TextEdit();
            this.DanhMuc_GhiChu = new System.Windows.Forms.RichTextBox();
            this.lblLoaiDanhMuc = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.DanhMuc_Loai = new System.Windows.Forms.ComboBox();
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.DanhMuc_Ten.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(24, 308);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(89, 17);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên Danh Mục";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(24, 346);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(44, 16);
            this.lblGhiChu.TabIndex = 1;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // DanhMuc_Ten
            // 
            this.DanhMuc_Ten.Location = new System.Drawing.Point(135, 306);
            this.DanhMuc_Ten.Name = "DanhMuc_Ten";
            this.DanhMuc_Ten.Size = new System.Drawing.Size(529, 22);
            this.DanhMuc_Ten.TabIndex = 2;
            // 
            // DanhMuc_GhiChu
            // 
            this.DanhMuc_GhiChu.Location = new System.Drawing.Point(135, 346);
            this.DanhMuc_GhiChu.Name = "DanhMuc_GhiChu";
            this.DanhMuc_GhiChu.Size = new System.Drawing.Size(529, 148);
            this.DanhMuc_GhiChu.TabIndex = 3;
            this.DanhMuc_GhiChu.Text = "";
            // 
            // lblLoaiDanhMuc
            // 
            this.lblLoaiDanhMuc.Location = new System.Drawing.Point(24, 264);
            this.lblLoaiDanhMuc.Name = "lblLoaiDanhMuc";
            this.lblLoaiDanhMuc.Size = new System.Drawing.Size(90, 17);
            this.lblLoaiDanhMuc.TabIndex = 4;
            this.lblLoaiDanhMuc.Text = "Loại Danh Mục";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(452, 513);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DanhMuc_Loai
            // 
            this.DanhMuc_Loai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DanhMuc_Loai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DanhMuc_Loai.FormattingEnabled = true;
            this.DanhMuc_Loai.Location = new System.Drawing.Point(135, 259);
            this.DanhMuc_Loai.Name = "DanhMuc_Loai";
            this.DanhMuc_Loai.Size = new System.Drawing.Size(529, 24);
            this.DanhMuc_Loai.TabIndex = 10;
            // 
            // defaultInfo
            // 
            this.defaultInfo.Location = new System.Drawing.Point(24, 41);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(425, 150);
            this.defaultInfo.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(39, 513);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Location = new System.Drawing.Point(533, 513);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(131, 23);
            this.btnSaveContinue.TabIndex = 13;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // ucDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.defaultInfo);
            this.Controls.Add(this.DanhMuc_Loai);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLoaiDanhMuc);
            this.Controls.Add(this.DanhMuc_GhiChu);
            this.Controls.Add(this.DanhMuc_Ten);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblTen);
            this.Name = "ucDanhMuc";
            this.Size = new System.Drawing.Size(687, 565);
            ((System.ComponentModel.ISupportInitialize)(this.DanhMuc_Ten.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DevExpress.XtraEditors.LabelControl lblTen;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.TextEdit DanhMuc_Ten;
        private System.Windows.Forms.RichTextBox DanhMuc_GhiChu;
        private DevExpress.XtraEditors.LabelControl lblLoaiDanhMuc;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.ComboBox DanhMuc_Loai;
        private DefaultInfo defaultInfo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
    }
}
