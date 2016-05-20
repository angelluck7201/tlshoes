namespace TLShoes.FormControls.ChiLenh
{
    partial class ucNguyenLieuChiLenh
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
            this.gridNguyenLieu = new DevExpress.XtraGrid.GridControl();
            this.gridViewNguyenLieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NguyenLieuLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NguyenLieuChiLenh_PhanXuongId = new System.Windows.Forms.ComboBox();
            this.lblPhanXuongId = new DevExpress.XtraEditors.LabelControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.NguyenLieuChiLenh_ChiTietId = new DevExpress.XtraEditors.LabelControl();
            this.lblQuyCach = new DevExpress.XtraEditors.LabelControl();
            this.NguyenLieuChiLenh_MauId = new System.Windows.Forms.ComboBox();
            this.lblMauId = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.NguyenLieuChiLenh_DinhMucThuc = new DevExpress.XtraEditors.TextEdit();
            this.lblDinhMucThuc = new DevExpress.XtraEditors.LabelControl();
            this.lblDinhMucChuan = new DevExpress.XtraEditors.LabelControl();
            this.NguyenLieuChiLenh_QuyCach = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridNguyenLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNguyenLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuChiLenh_DinhMucThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuChiLenh_QuyCach.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridNguyenLieu
            // 
            this.gridNguyenLieu.Location = new System.Drawing.Point(492, 20);
            this.gridNguyenLieu.MainView = this.gridViewNguyenLieu;
            this.gridNguyenLieu.Name = "gridNguyenLieu";
            this.gridNguyenLieu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.NguyenLieuLookUp});
            this.gridNguyenLieu.Size = new System.Drawing.Size(408, 295);
            this.gridNguyenLieu.TabIndex = 9;
            this.gridNguyenLieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNguyenLieu});
            // 
            // gridViewNguyenLieu
            // 
            this.gridViewNguyenLieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn8});
            this.gridViewNguyenLieu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridViewNguyenLieu.GridControl = this.gridNguyenLieu;
            this.gridViewNguyenLieu.Name = "gridViewNguyenLieu";
            this.gridViewNguyenLieu.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridViewNguyenLieu.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridViewNguyenLieu.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewNguyenLieu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Id";
            this.gridColumn4.FieldName = "Id";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Nguyên Liệu";
            this.gridColumn6.ColumnEdit = this.NguyenLieuLookUp;
            this.gridColumn6.FieldName = "ChiTietNguyenLieuId";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 226;
            // 
            // NguyenLieuLookUp
            // 
            this.NguyenLieuLookUp.AutoHeight = false;
            this.NguyenLieuLookUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NguyenLieuLookUp.Name = "NguyenLieuLookUp";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ghi Chú";
            this.gridColumn8.FieldName = "GhiChu";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 334;
            // 
            // NguyenLieuChiLenh_PhanXuongId
            // 
            this.NguyenLieuChiLenh_PhanXuongId.FormattingEnabled = true;
            this.NguyenLieuChiLenh_PhanXuongId.Location = new System.Drawing.Point(147, 20);
            this.NguyenLieuChiLenh_PhanXuongId.Name = "NguyenLieuChiLenh_PhanXuongId";
            this.NguyenLieuChiLenh_PhanXuongId.Size = new System.Drawing.Size(307, 24);
            this.NguyenLieuChiLenh_PhanXuongId.TabIndex = 42;
            // 
            // lblPhanXuongId
            // 
            this.lblPhanXuongId.Location = new System.Drawing.Point(36, 20);
            this.lblPhanXuongId.Name = "lblPhanXuongId";
            this.lblPhanXuongId.Size = new System.Drawing.Size(76, 17);
            this.lblPhanXuongId.TabIndex = 41;
            this.lblPhanXuongId.Text = "Phân Xưởng";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(147, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(307, 24);
            this.comboBox1.TabIndex = 44;
            // 
            // NguyenLieuChiLenh_ChiTietId
            // 
            this.NguyenLieuChiLenh_ChiTietId.Location = new System.Drawing.Point(36, 70);
            this.NguyenLieuChiLenh_ChiTietId.Name = "NguyenLieuChiLenh_ChiTietId";
            this.NguyenLieuChiLenh_ChiTietId.Size = new System.Drawing.Size(72, 17);
            this.NguyenLieuChiLenh_ChiTietId.TabIndex = 43;
            this.NguyenLieuChiLenh_ChiTietId.Text = "Tên Chi Tiết";
            // 
            // lblQuyCach
            // 
            this.lblQuyCach.Location = new System.Drawing.Point(36, 115);
            this.lblQuyCach.Name = "lblQuyCach";
            this.lblQuyCach.Size = new System.Drawing.Size(54, 16);
            this.lblQuyCach.TabIndex = 45;
            this.lblQuyCach.Text = "Quy Cách";
            // 
            // NguyenLieuChiLenh_MauId
            // 
            this.NguyenLieuChiLenh_MauId.FormattingEnabled = true;
            this.NguyenLieuChiLenh_MauId.Location = new System.Drawing.Point(147, 154);
            this.NguyenLieuChiLenh_MauId.Name = "NguyenLieuChiLenh_MauId";
            this.NguyenLieuChiLenh_MauId.Size = new System.Drawing.Size(307, 24);
            this.NguyenLieuChiLenh_MauId.TabIndex = 48;
            // 
            // lblMauId
            // 
            this.lblMauId.Location = new System.Drawing.Point(36, 157);
            this.lblMauId.Name = "lblMauId";
            this.lblMauId.Size = new System.Drawing.Size(24, 16);
            this.lblMauId.TabIndex = 47;
            this.lblMauId.Text = "Màu";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(147, 193);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(307, 22);
            this.textEdit1.TabIndex = 51;
            // 
            // NguyenLieuChiLenh_DinhMucThuc
            // 
            this.NguyenLieuChiLenh_DinhMucThuc.Location = new System.Drawing.Point(147, 239);
            this.NguyenLieuChiLenh_DinhMucThuc.Name = "NguyenLieuChiLenh_DinhMucThuc";
            this.NguyenLieuChiLenh_DinhMucThuc.Size = new System.Drawing.Size(307, 22);
            this.NguyenLieuChiLenh_DinhMucThuc.TabIndex = 52;
            // 
            // lblDinhMucThuc
            // 
            this.lblDinhMucThuc.Location = new System.Drawing.Point(36, 244);
            this.lblDinhMucThuc.Name = "lblDinhMucThuc";
            this.lblDinhMucThuc.Size = new System.Drawing.Size(58, 17);
            this.lblDinhMucThuc.TabIndex = 53;
            this.lblDinhMucThuc.Text = "Định Mức";
            // 
            // lblDinhMucChuan
            // 
            this.lblDinhMucChuan.Location = new System.Drawing.Point(34, 198);
            this.lblDinhMucChuan.Name = "lblDinhMucChuan";
            this.lblDinhMucChuan.Size = new System.Drawing.Size(94, 17);
            this.lblDinhMucChuan.TabIndex = 54;
            this.lblDinhMucChuan.Text = "Định Mức 1000";
            // 
            // NguyenLieuChiLenh_QuyCach
            // 
            this.NguyenLieuChiLenh_QuyCach.Location = new System.Drawing.Point(147, 112);
            this.NguyenLieuChiLenh_QuyCach.Name = "NguyenLieuChiLenh_QuyCach";
            this.NguyenLieuChiLenh_QuyCach.Size = new System.Drawing.Size(307, 22);
            this.NguyenLieuChiLenh_QuyCach.TabIndex = 55;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(324, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 23);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Lưu Nguyên Liệu";
            // 
            // ucNguyenLieuChiLenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.NguyenLieuChiLenh_QuyCach);
            this.Controls.Add(this.lblDinhMucChuan);
            this.Controls.Add(this.lblDinhMucThuc);
            this.Controls.Add(this.NguyenLieuChiLenh_DinhMucThuc);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.NguyenLieuChiLenh_MauId);
            this.Controls.Add(this.lblMauId);
            this.Controls.Add(this.lblQuyCach);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.NguyenLieuChiLenh_ChiTietId);
            this.Controls.Add(this.NguyenLieuChiLenh_PhanXuongId);
            this.Controls.Add(this.lblPhanXuongId);
            this.Controls.Add(this.gridNguyenLieu);
            this.Name = "ucNguyenLieuChiLenh";
            this.Size = new System.Drawing.Size(916, 332);
            ((System.ComponentModel.ISupportInitialize)(this.gridNguyenLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNguyenLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuChiLenh_DinhMucThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuChiLenh_QuyCach.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridNguyenLieu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNguyenLieu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit NguyenLieuLookUp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.ComboBox NguyenLieuChiLenh_PhanXuongId;
        private DevExpress.XtraEditors.LabelControl lblPhanXuongId;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraEditors.LabelControl NguyenLieuChiLenh_ChiTietId;
        private DevExpress.XtraEditors.LabelControl lblQuyCach;
        private System.Windows.Forms.ComboBox NguyenLieuChiLenh_MauId;
        private DevExpress.XtraEditors.LabelControl lblMauId;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit NguyenLieuChiLenh_DinhMucThuc;
        private DevExpress.XtraEditors.LabelControl lblDinhMucThuc;
        private DevExpress.XtraEditors.LabelControl lblDinhMucChuan;
        private DevExpress.XtraEditors.TextEdit NguyenLieuChiLenh_QuyCach;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
