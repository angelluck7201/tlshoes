using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauTest
{
    public partial class ucMauTestList : UserControl
    {
        public ucMauTestList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucMauTest", "ucMauTestList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauTestList", ReloadData);
            ObserverControl.Regist("Close", "ucMauTestList", ReloadData);
            ObserverControl.Regist("Export", "ucMauTestList", Export);

        }

        public void ReloadData()
        {
            SF.Get<MauTestViewModel>().GetDataSource(gridControl); if (gridView.RowCount > 0)
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
            var info = SF.Get<MauTestViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
