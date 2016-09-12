using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ChiLenh
{
    public partial class ucChiLenhList : UserControl
    {
        public ucChiLenhList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucChiLenh", "ucChiLenhList", ReloadData);
            ObserverControl.Regist("Refresh", "ucChiLenhList", ReloadData);
            ObserverControl.Regist("Close", "ucChiLenhList", ReloadData);
            ObserverControl.Regist("Export", "ucChiLenhList", Export);

        }

        public void ReloadData()
        {
            SF.Get<ChiLenhViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<ChiLenhViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
