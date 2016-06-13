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
    }
}
