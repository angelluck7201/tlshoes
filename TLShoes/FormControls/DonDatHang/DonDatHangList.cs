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

namespace TLShoes.FormControls.DonDatHang
{
    public partial class ucDonDatHangList : UserControl
    {
        public ucDonDatHangList()
        {
            InitializeComponent(); ReloadData();

            ObserverControl.Regist("ucDonDatHang", "ucDonDatHangList", ReloadData);
            ObserverControl.Regist("Refresh", "ucDonDatHangList", ReloadData);
            ObserverControl.Regist("Close", "ucDonDatHangList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<DonDatHangViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<DonDatHangViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
