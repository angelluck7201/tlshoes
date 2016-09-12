using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.HuongDanDongGoi
{
    public partial class ucHuongDanDongGoiList : UserControl
    {
        public ucHuongDanDongGoiList()
        {
            InitializeComponent();
            
            ReloadData();

            ObserverControl.Regist("ucHuongDanDongGoi", "ucHuongDanDongGoiList", ReloadData);
            ObserverControl.Regist("Refresh", "ucHuongDanDongGoiList", ReloadData);
            ObserverControl.Regist("Close", "ucHuongDanDongGoiList", ReloadData);
            ObserverControl.Regist("Export", "ucHuongDanDongGoiList", Export);

        }

        public void ReloadData()
        {
            SF.Get<HuongDanDongGoiViewModel>().GetDataSource(gridControl);
            if (gridView.RowCount > 0)
            {
                Main.FeaturesDict["btnExport"].Visible = true;
            }
            else
            {
                Main.FeaturesDict["btnExport"].Visible = false;
            }
        }

        public void Export(object filePath)
        {
            gridView.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<HuongDanDongGoiViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }

        private void gridView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column.FieldName == "KhachHang")
            {
                var view = sender as GridView;

                var rowData1 = view.GetRow(e.RowHandle1) as TLShoes.HuongDanDongGoi;
                var rowData2 = view.GetRow(e.RowHandle2) as TLShoes.HuongDanDongGoi;

                e.Merge = rowData1.DonHang.KhachHangId == rowData2.DonHang.KhachHangId;
                e.Handled = true;
            }
        }
    }
}
