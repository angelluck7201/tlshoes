namespace TLShoes
{
    partial class ucKhachHangList
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.khachHangInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRatingControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.colLoaiNguoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDungYeuCauKyThuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDungThoiGian = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDungMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatTestLy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatTestHoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDichVuGiaoHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDichVuHauMai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhac = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.khachHangInstantFeedbackSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRatingControl1});
            this.gridControl.Size = new System.Drawing.Size(1136, 694);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // khachHangInstantFeedbackSource
            // 
            this.khachHangInstantFeedbackSource.DefaultSorting = "CreatedDate DESC";
            this.khachHangInstantFeedbackSource.DesignTimeElementType = typeof(TLShoes.KhachHang);
            this.khachHangInstantFeedbackSource.KeyExpression = "Id";
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.colLoaiNguoiDung,
            this.colDungYeuCauKyThuat,
            this.colDungThoiGian,
            this.colDungMau,
            this.colDatTestLy,
            this.colDatTestHoa,
            this.colGia,
            this.colDichVuGiaoHang,
            this.colDichVuHauMai,
            this.colKhac});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Id, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Công Ty";
            this.gridColumn1.FieldName = "TenCongTy";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Người Đại Diện";
            this.gridColumn7.FieldName = "TenNguoiDaiDien";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Điện Thoại";
            this.gridColumn2.FieldName = "Dienthoai";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "Mặt Hàng";
            this.gridColumn3.FieldName = "MatHang";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "Fax";
            this.gridColumn4.FieldName = "Fax";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Email";
            this.gridColumn5.FieldName = "Email";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Đánh giá";
            this.gridColumn6.ColumnEdit = this.repositoryItemRatingControl1;
            this.gridColumn6.FieldName = "DanhGia";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.UnboundExpression = "([DungYeuCauKyThuat] + [DungThoiGian] + [DungMau] + [DatTestLy] + [DatTestHoa] + " +
    "[Gia] + [DichVuGiaoHang] + [DichVuHauMai] + [Khac]) / 9.0f";
            this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // repositoryItemRatingControl1
            // 
            this.repositoryItemRatingControl1.AutoHeight = false;
            this.repositoryItemRatingControl1.FillPrecision = DevExpress.XtraEditors.RatingItemFillPrecision.Exact;
            this.repositoryItemRatingControl1.Name = "repositoryItemRatingControl1";
            this.repositoryItemRatingControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // colLoaiNguoiDung
            // 
            this.colLoaiNguoiDung.Caption = "gridColumn8";
            this.colLoaiNguoiDung.FieldName = "UserAccount.LoaiNguoiDung";
            this.colLoaiNguoiDung.Name = "colLoaiNguoiDung";
            // 
            // colDungYeuCauKyThuat
            // 
            this.colDungYeuCauKyThuat.FieldName = "DungYeuCauKyThuat";
            this.colDungYeuCauKyThuat.Name = "colDungYeuCauKyThuat";
            // 
            // colDungThoiGian
            // 
            this.colDungThoiGian.Caption = "gridColumn9";
            this.colDungThoiGian.FieldName = "DungThoiGian";
            this.colDungThoiGian.Name = "colDungThoiGian";
            // 
            // colDungMau
            // 
            this.colDungMau.Caption = "gridColumn10";
            this.colDungMau.FieldName = "DungMau";
            this.colDungMau.Name = "colDungMau";
            // 
            // colDatTestLy
            // 
            this.colDatTestLy.Caption = "gridColumn11";
            this.colDatTestLy.FieldName = "DatTestLy";
            this.colDatTestLy.Name = "colDatTestLy";
            // 
            // colDatTestHoa
            // 
            this.colDatTestHoa.Caption = "gridColumn12";
            this.colDatTestHoa.FieldName = "DatTestHoa";
            this.colDatTestHoa.Name = "colDatTestHoa";
            // 
            // colGia
            // 
            this.colGia.Caption = "gridColumn13";
            this.colGia.FieldName = "Gia";
            this.colGia.Name = "colGia";
            // 
            // colDichVuGiaoHang
            // 
            this.colDichVuGiaoHang.Caption = "gridColumn14";
            this.colDichVuGiaoHang.FieldName = "DichVuGiaoHang";
            this.colDichVuGiaoHang.Name = "colDichVuGiaoHang";
            // 
            // colDichVuHauMai
            // 
            this.colDichVuHauMai.Caption = "gridColumn15";
            this.colDichVuHauMai.FieldName = "DichVuHauMai";
            this.colDichVuHauMai.Name = "colDichVuHauMai";
            // 
            // colKhac
            // 
            this.colKhac.Caption = "gridColumn16";
            this.colKhac.FieldName = "Khac";
            this.colKhac.Name = "colKhac";
            // 
            // ucKhachHangList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "ucKhachHangList";
            this.Size = new System.Drawing.Size(1136, 694);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemRatingControl repositoryItemRatingControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiNguoiDung;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource khachHangInstantFeedbackSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDungYeuCauKyThuat;
        private DevExpress.XtraGrid.Columns.GridColumn colDungThoiGian;
        private DevExpress.XtraGrid.Columns.GridColumn colDungMau;
        private DevExpress.XtraGrid.Columns.GridColumn colDatTestLy;
        private DevExpress.XtraGrid.Columns.GridColumn colDatTestHoa;
        private DevExpress.XtraGrid.Columns.GridColumn colGia;
        private DevExpress.XtraGrid.Columns.GridColumn colDichVuGiaoHang;
        private DevExpress.XtraGrid.Columns.GridColumn colDichVuHauMai;
        private DevExpress.XtraGrid.Columns.GridColumn colKhac;
    }
}
