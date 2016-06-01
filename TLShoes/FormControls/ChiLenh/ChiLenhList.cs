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

namespace TLShoes.FormControls.ChiLenh
{
    public partial class ucChiLenhList : UserControl
    {
        public ucChiLenhList()
        {
            InitializeComponent();

            SF.Get<ChiLenhViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucChiLenh", "ucChiLenhList", ReloadData);
            ObserverControl.Regist("Refresh", "ucChiLenhList", ReloadData);
            ObserverControl.Regist("Close", "ucChiLenhList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<ChiLenhViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<ChiLenhViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
