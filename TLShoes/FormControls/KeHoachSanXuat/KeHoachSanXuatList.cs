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

namespace TLShoes.FormControls.KeHoachSanXuat
{
    public partial class ucKeHoachSanXuatList : UserControl
    {
        public ucKeHoachSanXuatList()
        {
            InitializeComponent();

            SF.Get<KeHoachSanXuatViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucKeHoachSanXuat", "ucKeHoachSanXuatList", ReloadData);
            ObserverControl.Regist("Refresh", "ucKeHoachSanXuatList", ReloadData);
            ObserverControl.Regist("Close", "ucKeHoachSanXuatList", ReloadData);

        }

        public void ReloadData()
        {
            SF.Get<KeHoachSanXuatViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<KeHoachSanXuatViewModel>().GetDetail(data.Id);
            Main.ShowPopupInfo(info);
        }
    }
}
