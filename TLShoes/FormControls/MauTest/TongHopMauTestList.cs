using System;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.TongHopMauTest
{
    public partial class ucTongHopMauTestList : BaseUserControl
    {
        public ucTongHopMauTestList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucMauTest", "ucTongHopMauTestList", ReloadData);
            ObserverControl.Regist("ucMauThuDao", "ucTongHopMauTestList", ReloadData);
            ObserverControl.Regist("ucMauSanXuat", "ucTongHopMauTestList", ReloadData);

            ObserverControl.Regist("Refresh", "ucTongHopMauTestList", ReloadData);
            ObserverControl.Regist("Close", "ucTongHopMauTestList", ReloadData);
            ObserverControl.Regist("Export", "ucTongHopMauTestList", Export);
        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<MauDoiViewModel>().GetDataSummarySource(gridControl);
                if (bandedGridView1.RowCount > 0)
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
            bandedGridView1.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle);
                FormFactory<Main>.Get().ShowPopupInfo(data.Id);
            });
        }
    }
}
