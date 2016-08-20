namespace TLShoes.Form
{
    partial class NhatKyThayDoi
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
            this.Id = new System.Windows.Forms.Label();
            this.GhiChu = new System.Windows.Forms.RichTextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(31, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(119, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ghi Chú Thay Đổi";
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Location = new System.Drawing.Point(171, 34);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(0, 17);
            this.Id.TabIndex = 7;
            // 
            // GhiChu
            // 
            this.GhiChu.Location = new System.Drawing.Point(161, 34);
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Size = new System.Drawing.Size(502, 133);
            this.GhiChu.TabIndex = 12;
            this.GhiChu.Text = "";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(31, 195);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(632, 268);
            this.gridControl1.TabIndex = 13;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ngày Thay Đổi";
            this.gridColumn1.FieldName = "ModifiedDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ghi Chú";
            this.gridColumn2.FieldName = "GhiChu";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // NhatKyThayDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.GhiChu);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.labelControl1);
            this.Name = "NhatKyThayDoi";
            this.Size = new System.Drawing.Size(697, 493);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.RichTextBox GhiChu;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
