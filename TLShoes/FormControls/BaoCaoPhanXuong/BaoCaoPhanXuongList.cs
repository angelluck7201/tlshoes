using System;
using System.Windows.Forms;
using DevExpress.Data;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.BaoCaoPhanXuong
{
    public partial class ucBaoCaoPhanXuongList : UserControl
    {
        public ucBaoCaoPhanXuongList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucBaoCaoPhanXuong", "ucBaoCaoPhanXuongList", ReloadData);
            ObserverControl.Regist("Refresh", "ucBaoCaoPhanXuongList", ReloadData);
            ObserverControl.Regist("Close", "ucBaoCaoPhanXuongList", ReloadData);
            ObserverControl.Regist("Export", "ucBaoCaoPhanXuongList", Export);
        }

        public void ReloadData()
        {
            SF.Get<BaoCaoPhanXuongViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<BaoCaoPhanXuongViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }

        private void gridView_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "BaoCaoNgayFormat")
                {
                    object val1 = gridView.GetListSourceRowCellValue(e.ListSourceRowIndex1, "IsEmptyRow");
                    object val2 = gridView.GetListSourceRowCellValue(e.ListSourceRowIndex2, "IsEmptyRow");
                    e.Handled = true;
                    e.Result = System.Collections.Comparer.Default.Compare(TimeHelper.StringToTimeStamp(val1.ToString()), TimeHelper.StringToTimeStamp(val2.ToString()));
                }
            }
            catch (Exception ee)
            {
                //...
            }
        }

    }
}
