using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.DonHang
{
    public partial class ucMauDoiList : UserControl
    {
        public ucMauDoiList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucMauDoi", "ucMauDoiList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauDoiList", ReloadData);
            ObserverControl.Regist("Close", "ucMauDoiList", ReloadData);
            ObserverControl.Regist("Export", "ucMauDoiList", Export);

        }

        public void ReloadData()
        {
            SF.Get<MauDoiViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<MauDoiViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }

        private void ucMauDoiList_Load(object sender, EventArgs e)
        {

        }

    }
}
