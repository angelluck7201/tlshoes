using System;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinhList : UserControl
    {
        public ucToTrinhList()
        {
            InitializeComponent();
            ReloadData();
            AutoRefresh();
            ObserverControl.Regist("Refresh", this.Name, ReloadData);
            ObserverControl.Regist("Close", this.Name, ReloadData);
        }

        private void AutoRefresh()
        {
            ThreadHelper.RunBackground(() =>
            {
                var timer = new Timer();
                timer.Interval = 10 * 1000;
                timer.Tick += new EventHandler((a, b) => { ReloadData(); });
            });
        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<ToTrinhViewModel>().GetDataSource(gridControl);
                FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = false;
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            var data = gridView.GetRow(gridView.FocusedRowHandle) as TLShoes.ToTrinh;
            if (data != null)
            {
                ThreadHelper.LoadForm(() =>
                {
                    var info = SF.Get<ToTrinhViewModel>().GetDetail(data.Id);
                    FormFactory<Main>.Get().ShowPopupInfo(info.TongHopToTrinh);
                });
            }

        }
    }
}
