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


            SF.Get<MauTestViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucMauTest", "ucMauTestList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauTestList", ReloadData);
            ObserverControl.Regist("Close", "ucMauTestList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<MauTestViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<MauTestViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
