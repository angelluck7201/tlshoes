using System;

namespace TLShoes.FormControls.BangThongSo
{
    partial class ucBangThongSo
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
            this.BangThongSo_DonHangId = new System.Windows.Forms.ComboBox();
            this.lblDonHang = new DevExpress.XtraEditors.LabelControl();
            this.BangThongSo_MaPhomId = new System.Windows.Forms.ComboBox();
            this.lblMaPhomId = new DevExpress.XtraEditors.LabelControl();
            this.BangThongSo_PhanXuongId = new System.Windows.Forms.ComboBox();
            this.lblPhanXuongId = new DevExpress.XtraEditors.LabelControl();
            this.BangThongSo_NgayXacNhan = new System.Windows.Forms.DateTimePicker();
            this.BangThongSo_NgayKy = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKy = new DevExpress.XtraEditors.LabelControl();
            this.lblNgayXacNhan = new DevExpress.XtraEditors.LabelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChiTietDonHang_Mau = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnSaveContinue = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietDonHang_Mau)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultInfo
            // 
            this.defaultInfo.Location = new System.Drawing.Point(3, 3);
            this.defaultInfo.Name = "defaultInfo";
            this.defaultInfo.Size = new System.Drawing.Size(425, 150);
            this.defaultInfo.TabIndex = 26;
            // 
            // BangThongSo_DonHangId
            // 
            this.BangThongSo_DonHangId.FormattingEnabled = true;
            this.BangThongSo_DonHangId.Location = new System.Drawing.Point(126, 181);
            this.BangThongSo_DonHangId.Name = "BangThongSo_DonHangId";
            this.BangThongSo_DonHangId.Size = new System.Drawing.Size(529, 24);
            this.BangThongSo_DonHangId.TabIndex = 81;
            // 
            // lblDonHang
            // 
            this.lblDonHang.Location = new System.Drawing.Point(12, 181);
            this.lblDonHang.Name = "lblDonHang";
            this.lblDonHang.Size = new System.Drawing.Size(56, 16);
            this.lblDonHang.TabIndex = 80;
            this.lblDonHang.Text = "Đơn Hàng";
            // 
            // BangThongSo_MaPhomId
            // 
            this.BangThongSo_MaPhomId.FormattingEnabled = true;
            this.BangThongSo_MaPhomId.Location = new System.Drawing.Point(126, 222);
            this.BangThongSo_MaPhomId.Name = "BangThongSo_MaPhomId";
            this.BangThongSo_MaPhomId.Size = new System.Drawing.Size(529, 24);
            this.BangThongSo_MaPhomId.TabIndex = 83;
            // 
            // lblMaPhomId
            // 
            this.lblMaPhomId.Location = new System.Drawing.Point(12, 222);
            this.lblMaPhomId.Name = "lblMaPhomId";
            this.lblMaPhomId.Size = new System.Drawing.Size(32, 16);
            this.lblMaPhomId.TabIndex = 82;
            this.lblMaPhomId.Text = "Phom";
            // 
            // BangThongSo_PhanXuongId
            // 
            this.BangThongSo_PhanXuongId.FormattingEnabled = true;
            this.BangThongSo_PhanXuongId.Location = new System.Drawing.Point(126, 264);
            this.BangThongSo_PhanXuongId.Name = "BangThongSo_PhanXuongId";
            this.BangThongSo_PhanXuongId.Size = new System.Drawing.Size(529, 24);
            this.BangThongSo_PhanXuongId.TabIndex = 85;
            // 
            // lblPhanXuongId
            // 
            this.lblPhanXuongId.Location = new System.Drawing.Point(12, 264);
            this.lblPhanXuongId.Name = "lblPhanXuongId";
            this.lblPhanXuongId.Size = new System.Drawing.Size(76, 17);
            this.lblPhanXuongId.TabIndex = 84;
            this.lblPhanXuongId.Text = "Phân Xưởng";
            // 
            // BangThongSo_NgayXacNhan
            // 
            this.BangThongSo_NgayXacNhan.Location = new System.Drawing.Point(126, 343);
            this.BangThongSo_NgayXacNhan.Name = "BangThongSo_NgayXacNhan";
            this.BangThongSo_NgayXacNhan.Size = new System.Drawing.Size(529, 22);
            this.BangThongSo_NgayXacNhan.TabIndex = 89;
            // 
            // BangThongSo_NgayKy
            // 
            this.BangThongSo_NgayKy.Location = new System.Drawing.Point(126, 302);
            this.BangThongSo_NgayKy.Name = "BangThongSo_NgayKy";
            this.BangThongSo_NgayKy.Size = new System.Drawing.Size(529, 22);
            this.BangThongSo_NgayKy.TabIndex = 88;
            // 
            // lblNgayKy
            // 
            this.lblNgayKy.Location = new System.Drawing.Point(15, 302);
            this.lblNgayKy.Name = "lblNgayKy";
            this.lblNgayKy.Size = new System.Drawing.Size(45, 16);
            this.lblNgayKy.TabIndex = 87;
            this.lblNgayKy.Text = "Ngày Ký";
            // 
            // lblNgayXacNhan
            // 
            this.lblNgayXacNhan.Location = new System.Drawing.Point(15, 343);
            this.lblNgayXacNhan.Name = "lblNgayXacNhan";
            this.lblNgayXacNhan.Size = new System.Drawing.Size(94, 17);
            this.lblNgayXacNhan.TabIndex = 86;
            this.lblNgayXacNhan.Text = "Ngày Xác Nhận";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(696, 13);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ChiTietDonHang_Mau,
            this.repositoryItemLookUpEdit1});
            this.gridControl.Size = new System.Drawing.Size(341, 352);
            this.gridControl.TabIndex = 90;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Size";
            this.gridColumn1.FieldName = "Size";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Chi Tiết";
            this.gridColumn2.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn2.FieldName = "ChiTietId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Thông Số";
            this.gridColumn3.FieldName = "ThongSo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // ChiTietDonHang_Mau
            // 
            this.ChiTietDonHang_Mau.AutoHeight = false;
            this.ChiTietDonHang_Mau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ChiTietDonHang_Mau.Name = "ChiTietDonHang_Mau";
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Location = new System.Drawing.Point(744, 382);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(131, 23);
            this.btnSaveContinue.TabIndex = 93;
            this.btnSaveContinue.Text = "Lưu Và Tiếp Tục";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(962, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Text = "Hủy";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(881, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 91;
            this.btnSave.Text = "Lưu";
            // 
            // ucBangThongSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.BangThongSo_NgayXacNhan);
            this.Controls.Add(this.BangThongSo_NgayKy);
            this.Controls.Add(this.lblNgayKy);
            this.Controls.Add(this.lblNgayXacNhan);
            this.Controls.Add(this.BangThongSo_PhanXuongId);
            this.Controls.Add(this.lblPhanXuongId);
            this.Controls.Add(this.BangThongSo_MaPhomId);
            this.Controls.Add(this.lblMaPhomId);
            this.Controls.Add(this.BangThongSo_DonHangId);
            this.Controls.Add(this.lblDonHang);
            this.Controls.Add(this.defaultInfo);
            this.Name = "ucBangThongSo";
            this.Size = new System.Drawing.Size(1059, 426);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietDonHang_Mau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Form.DefaultInfo defaultInfo;
        private System.Windows.Forms.ComboBox BangThongSo_DonHangId;
        private DevExpress.XtraEditors.LabelControl lblDonHang;
        private System.Windows.Forms.ComboBox BangThongSo_MaPhomId;
        private DevExpress.XtraEditors.LabelControl lblMaPhomId;
        private System.Windows.Forms.ComboBox BangThongSo_PhanXuongId;
        private DevExpress.XtraEditors.LabelControl lblPhanXuongId;
        private System.Windows.Forms.DateTimePicker BangThongSo_NgayXacNhan;
        private System.Windows.Forms.DateTimePicker BangThongSo_NgayKy;
        private DevExpress.XtraEditors.LabelControl lblNgayKy;
        private DevExpress.XtraEditors.LabelControl lblNgayXacNhan;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ChiTietDonHang_Mau;
        private DevExpress.XtraEditors.SimpleButton btnSaveContinue;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;

    }
}
