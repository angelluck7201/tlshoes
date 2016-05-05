namespace TLShoes.Form
{
    partial class DefaultInfo
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Id = new System.Windows.Forms.Label();
            this.CreatedDate = new System.Windows.Forms.Label();
            this.ModifiedDate = new System.Windows.Forms.Label();
            this.AuthorId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(11, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Id";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 17);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Ngày Tạo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 125);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 17);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tác Giả";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 87);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(99, 17);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Ngày Chỉnh Sửa";
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Location = new System.Drawing.Point(145, 7);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(0, 17);
            this.Id.TabIndex = 7;
            // 
            // CreatedDate
            // 
            this.CreatedDate.AutoSize = true;
            this.CreatedDate.Location = new System.Drawing.Point(145, 49);
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.Size = new System.Drawing.Size(0, 17);
            this.CreatedDate.TabIndex = 8;
            // 
            // ModifiedDate
            // 
            this.ModifiedDate.AutoSize = true;
            this.ModifiedDate.Location = new System.Drawing.Point(145, 87);
            this.ModifiedDate.Name = "ModifiedDate";
            this.ModifiedDate.Size = new System.Drawing.Size(0, 17);
            this.ModifiedDate.TabIndex = 9;
            // 
            // AuthorId
            // 
            this.AuthorId.AutoSize = true;
            this.AuthorId.Location = new System.Drawing.Point(145, 125);
            this.AuthorId.Name = "AuthorId";
            this.AuthorId.Size = new System.Drawing.Size(0, 17);
            this.AuthorId.TabIndex = 10;
            // 
            // DefaultInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AuthorId);
            this.Controls.Add(this.ModifiedDate);
            this.Controls.Add(this.CreatedDate);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "DefaultInfo";
            this.Size = new System.Drawing.Size(406, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.Label CreatedDate;
        private System.Windows.Forms.Label ModifiedDate;
        private System.Windows.Forms.Label AuthorId;
    }
}
