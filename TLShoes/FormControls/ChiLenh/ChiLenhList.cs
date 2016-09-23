using System;
using System.Windows.Forms;
using TLShoes.Common;
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
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<ChiLenhViewModel>().GetDataSource(gridControl);
                if (gridView.RowCount > 0)
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = true;
                }
                else
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = false;
                }
            });
        }

        public void Export(object filePath)
        {
            gridView.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                var info = SF.Get<ChiLenhViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);
            });
        }
    }
}
