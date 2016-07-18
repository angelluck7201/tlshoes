using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinhList : UserControl
    {
        public ucToTrinhList()
        {
            InitializeComponent(); SF.Get<ToTrinhViewModel>().GetDataSource(gridControl);
            ObserverControl.Regist("ucToTrinh", "ucToTrinhList", ReloadData);
            ObserverControl.Regist("Refresh", "ucToTrinhList", ReloadData);
            ObserverControl.Regist("Close", "ucToTrinhList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<ToTrinhViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<ToTrinhViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
