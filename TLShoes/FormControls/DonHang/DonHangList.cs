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

namespace TLShoes.Form
{
    public partial class ucDonHangList : UserControl
    {
        public ucDonHangList()
        {
            InitializeComponent();

            SF.Get<DonHangViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucDonHang", "ucDonHangList", ReloadData);
            ObserverControl.Regist("Refresh", "ucDonHangList", ReloadData);
            ObserverControl.Regist("Close", "ucDonHangList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<DonHangViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<DonHangViewModel>().GetDetail(data.Id);
            Main.ShowPopupInfo(info);
        }
    }
}

