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
            this.components = new System.ComponentModel.Container();
            this.lblTen = new DevExpress.XtraEditors.LabelControl();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.DanhMuc_Ten = new DevExpress.XtraEditors.TextEdit();
            this.DanhMuc_GhiChu = new System.Windows.Forms.RichTextBox();
            this.lblLoaiDanhMuc = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.DanhMuc_Loai = new System.Windows.Forms.ComboBox();
            this.defaultInfo = new TLShoes.Form.DefaultInfo();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DanhMuc_Ten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTen
            // 
            this.lblTen.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblTen.Location = new System.Drawing.Point(28, 79);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(98, 17);
            this.lblTen.TabIndex = 0;
            this.lblTen.Text = "Tên Danh Mục";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.Location = new System.Drawing.Point(28, 117);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 16);
            this.lblGhiChu.TabIndex = 1;
            this.lblGhiChu.Text = "Ghi Chú";
            // 
            // DanhMuc_Ten
            // 
            this.DanhMuc_Ten.Location = new System.Drawing.Point(157, 77);
            this.DanhMuc_Ten.Name = "DanhMuc_Ten";
            this.DanhMuc_Ten.Size = new System.Drawing.Size(529, 22);
            this.DanhMuc_Ten.TabIndex = 1;
            this.DanhMuc_Ten.ToolTip = "Tên danh mục";
            // 
            // DanhMuc_GhiChu
            // 
            this.DanhMuc_GhiChu.Location = new System.Drawing.Point(157, 117);
            this.DanhMuc_GhiChu.Name = "DanhMuc_GhiChu";
            this.DanhMuc_GhiChu.Size = new System.Drawing.Size(529, 148);
            this.DanhMuc_GhiChu.TabIndex = 2;
            this.DanhMuc_GhiChu.Text = "";
            // 
            // lblLoaiDanhMuc
            // 
            this.lblLoaiDanhMuc.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblLoaiDanhMuc.Location = new System.Drawing.Point(28, 35);
            this.lblLoaiDanhMuc.Name = "lblLoaiDanhMuc";
            this.lblLoaiDanhMuc.Size = new System.Drawing.Size(100, 17);
            this.lblLoaiDanhMuc.TabIndex = 4;
            this.lblLoaiDanhMuc.Text = "Loại Danh Mục";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnSave.Location = new System.Drawing.Point(615, 502);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            // 
            // DanhMuc_Loai
            // 
            this.DanhMuc_Loai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DanhMuc_Loai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DanhMuc_Loai.FormattingEnabled = true;
            this.DanhMuc_Loai.Location = new System.Drawing.Point(157, 30);
            this.DanhMuc_Loai.Name = "DanhMuc_Loai";
            this.DanhMuc_Loai.Size = new System.Drawing.Size(529, 24);
            this.DanhMuc_Loai.TabIndex = 0;
            // 
            // defaultInfo
            // 
            this.defaultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultInfo.Location = new System.Drawing.Point(0, 0);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(701, 443);
            this.defaultInfo.TabIndex = 11;
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
            this.xtraTabControl1.Size = new System.Drawing.Size(708, 479);
            this.xtraTabControl1.TabIndex = 0;
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
            this.xtraTabPage2.Controls.Add(this.DanhMuc_GhiChu);
            this.xtraTabPage2.Controls.Add(this.lblTen);
            this.xtraTabPage2.Controls.Add(this.lblGhiChu);
            this.xtraTabPage2.Controls.Add(this.DanhMuc_Loai);
            this.xtraTabPage2.Controls.Add(this.DanhMuc_Ten);
            this.xtraTabPage2.Controls.Add(this.lblLoaiDanhMuc);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(701, 443);
            this.xtraTabPage2.Text = "Thông tin danh mục";
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
            // ucDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnSave);
            this.Name = "ucDanhMuc";
            this.Size = new System.Drawing.Size(709, 547);
            ((System.ComponentModel.ISupportInitialize)(this.DanhMuc_Ten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.xtraTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
