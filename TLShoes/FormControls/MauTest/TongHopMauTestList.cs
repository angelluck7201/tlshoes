using System;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.TongHopMauTest
{
    public partial class ucTongHopMauTestList : BaseUserControl
    {
        public ucTongHopMauTestList()
        {
            InitializeComponent();

            SF.Get<MauDoiViewModel>().GetDataSummarySource(gridControl);

            ObserverControl.Regist("ucMauTest", "ucTongHopMauTestList", ReloadData);
            ObserverControl.Regist("ucMauThuDao", "ucTongHopMauTestList", ReloadData);
            ObserverControl.Regist("ucMauSanXuat", "ucTongHopMauTestList", ReloadData);

            ObserverControl.Regist("Refresh", "ucTongHopMauTestList", ReloadData);
            ObserverControl.Regist("Close", "ucTongHopMauTestList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<MauDoiViewModel>().GetDataSummarySource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle);
            FormFactory<Main>.Get().ShowPopupInfo(data.Id);
        }
    }
}
