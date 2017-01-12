using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.KeHoachSanXuat
{
    public partial class ucBaoCaoTongHop : UserControl
    {
        public ucBaoCaoTongHop()
        {
            InitializeComponent();
            ReloadData();
            ObserverControl.Regist("Export", "ucBaoCaoTongHop", Export);

        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<BaoCaoPhanXuongViewModel>().GetDataSummarySource(gridControl);
            });
        }

        public void Export(object filePath)
        {
            bandedGridView1.ExportToXls(filePath.ToString());
        }

        private void bandedGridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column.FieldName == "MaHang" || e.Column.FieldName == "SoDH" || e.Column.FieldName == "SoLuong")
            {
                var view = sender as BandedGridView;

                var rowData1 = view.GetRow(e.RowHandle1) as BaoCaoPhanXuongViewModel.SummaryBaoCao;
                var rowData2 = view.GetRow(e.RowHandle2) as BaoCaoPhanXuongViewModel.SummaryBaoCao;

                e.Merge = rowData1.MaHang == rowData2.MaHang;
                e.Handled = true;
            }
        }


    }
}
