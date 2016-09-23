using System;
using System.Windows.Forms;
using TLShoes.Common;
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
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<MauTestViewModel>().GetDataSource(gridControl);
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
                var info = SF.Get<MauTestViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);
            });
        }
    }
}
