using System;

namespace TLShoes.FormControls.ChiLenh
{
    partial class ucChiLenh
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
            this.ChiLenh_DonHangId = new System.Windows.Forms.ComboBox();
            this.lblDonHangId = new DevExpress.XtraEditors.LabelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PhanXuongLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNguyenLieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MauLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChiLenh_Mau = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.NguyenLieuContainer = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhanXuongLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MauLookUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChiLenh_Mau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultInfo
            // 
            this.defaultInfo.Location = new System.Drawing.Point(3, 3);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(425, 150);
            this.defaultInfo.TabIndex = 26;
            // 
            // ChiLenh_DonHangId
            // 
            this.ChiLenh_DonHangId.FormattingEnabled = true;
            this.ChiLenh_DonHangId.Location = new System.Drawing.Point(126, 177);
            this.ChiLenh_DonHangId.Name = "ChiLenh_DonHangId";
            this.ChiLenh_DonHangId.Size = new System.Drawing.Size(529, 24);
            this.ChiLenh_DonHangId.TabIndex = 40;
            // 
            // lblDonHangId
            // 
            this.lblDonHangId.Location = new System.Drawing.Point(15, 177);
            this.lblDonHangId.Name = "lblDonHangId";
            this.lblDonHangId.Size = new System.Drawing.Size(56, 16);
            this.lblDonHangId.TabIndex = 39;
            this.lblDonHangId.Text = "Đơn Hàng";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(15, 225);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ChiLenh_Mau,
            this.MauLookUp,
            this.PhanXuongLookUp,
            this.NguyenLieuContainer});
            this.gridControl.Size = new System.Drawing.Size(640, 472);
            this.gridControl.TabIndex = 41;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.gridColumn1,
            this.colNguyenLieu,
            this.gridColumn2,
            this.gridColumn4});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView.Click += new System.EventHandler(this.gridView_Click);
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Phân Xưởng";
            this.gridColumn1.ColumnEdit = this.PhanXuongLookUp;
            this.gridColumn1.FieldName = "PhanXuong";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 155;
            // 
            // PhanXuongLookUp
            // 
            this.PhanXuongLookUp.AutoHeight = false;
            this.PhanXuongLookUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PhanXuongLookUp.Name = "PhanXuongLookUp";
            // 
            // colNguyenLieu
            // 
            this.colNguyenLieu.Caption = "Nguyên Liệu";
            this.colNguyenLieu.FieldName = "NguyenLieu";
            this.colNguyenLieu.Name = "colNguyenLieu";
            this.colNguyenLieu.Visible = true;
            this.colNguyenLieu.VisibleIndex = 2;
            this.colNguyenLieu.Width = 276;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Màu";
            this.gridColumn2.ColumnEdit = this.MauLookUp;
            this.gridColumn2.FieldName = "Mau";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 112;
            // 
            // MauLookUp
            // 
            this.MauLookUp.AutoHeight = false;
            this.MauLookUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.MauLookUp.Name = "MauLookUp";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "QC";
            this.gridColumn4.FieldName = "QuyCach";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 77;
            // 
            // ChiLenh_Mau
            // 
            this.ChiLenh_Mau.AutoHeight = false;
            this.ChiLenh_Mau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ChiLenh_Mau.Name = "ChiLenh_Mau";
            // 
            // NguyenLieuContainer
            // 
            this.NguyenLieuContainer.AutoHeight = false;
            this.NguyenLieuContainer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NguyenLieuContainer.Name = "NguyenLieuContainer";
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Location = new System.Drawing.Point(362, 716);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(131, 23);
            this.btnSaveContinue.TabIndex = 44;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            this.btnSaveContinue.Click+= new EventHandler(this.btnSaveContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(580, 716);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click+= new EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(499, 716);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click+= new EventHandler(this.btnSave_Click);
            // 
            // ucChiLenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ChiLenh_DonHangId);
            this.Controls.Add(this.lblDonHangId);
            this.Controls.Add(this.defaultInfo);
            this.Name = "ucChiLenh";
            this.Size = new System.Drawing.Size(671, 595);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhanXuongLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MauLookUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChiLenh_Mau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NguyenLieuContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Form.DefaultInfo defaultInfo;
        private System.Windows.Forms.ComboBox ChiLenh_DonHangId;
        private DevExpress.XtraEditors.LabelControl lblDonHangId;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MauLookUp;
        private DevExpress.XtraGrid.Columns.GridColumn colNguyenLieu;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ChiLenh_Mau;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit PhanXuongLookUp;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit NguyenLieuContainer;
    }
}
