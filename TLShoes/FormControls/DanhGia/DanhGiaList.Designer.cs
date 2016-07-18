﻿namespace TLShoes.FormControls.DanhGia
{
    partial class ucDanhGiaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDanhGiaList));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TieuChiLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnDeleteTieuChi = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TieuChiLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTieuChi)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TieuChiLookUp,
            this.btnDeleteTieuChi});
            this.gridControl.Size = new System.Drawing.Size(1047, 632);
            this.gridControl.TabIndex = 60;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tỉ Lệ Kiểm(%)";
            this.gridColumn7.FieldName = "TiLeKiem";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Số Đơn Đặt Hàng";
            this.gridColumn4.FieldName = "SoDH";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Số Lượng Kiểm";
            this.gridColumn2.FieldName = "SoLuongKiem";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Id";
            this.gridColumn3.FieldName = "Id";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số Lượng Kém";
            this.gridColumn1.FieldName = "SoLuongKem";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuongKem", "{0:0.##}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ngày Kiểm";
            this.gridColumn5.FieldName = "NgayKiem";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số Lượng Đặt";
            this.gridColumn6.FieldName = "SoLuongDat";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // TieuChiLookUp
            // 
            this.TieuChiLookUp.AutoHeight = false;
            this.TieuChiLookUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TieuChiLookUp.Name = "TieuChiLookUp";
            // 
            // btnDeleteTieuChi
            // 
            this.btnDeleteTieuChi.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTieuChi.Appearance.Image")));
            this.btnDeleteTieuChi.Appearance.Options.UseImage = true;
            this.btnDeleteTieuChi.AutoHeight = false;
            serializableAppearanceObject4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            serializableAppearanceObject4.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            serializableAppearanceObject4.Image = ((System.Drawing.Image)(resources.GetObject("serializableAppearanceObject4.Image")));
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject4.Options.UseBorderColor = true;
            serializableAppearanceObject4.Options.UseImage = true;
            this.btnDeleteTieuChi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.Default, ((System.Drawing.Image)(resources.GetObject("btnDeleteTieuChi.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Nhấp đúp để xóa", null, null, true)});
            this.btnDeleteTieuChi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.btnDeleteTieuChi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeleteTieuChi.Name = "btnDeleteTieuChi";
            this.btnDeleteTieuChi.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Mẫu Đánh Giá";
            this.gridColumn8.FieldName = "TenMau";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // ucDanhGiaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "ucDanhGiaList";
            this.Size = new System.Drawing.Size(1047, 632);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TieuChiLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTieuChi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit TieuChiLookUp;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDeleteTieuChi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}