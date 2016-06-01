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

namespace TLShoes
{
    public partial class ucKhachHangList : UserControl
    {
        public ucKhachHangList()
        {
            InitializeComponent();

            SF.Get<KhachHangViewModel>().GetDataSource(gridControl);
            ObserverControl.Regist("ucKhachHang", "ucKhachHangList", ReloadData);
            ObserverControl.Regist("Refresh", "ucKhachHangList", ReloadData);
            ObserverControl.Regist("Close", "ucKhachHangList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<KhachHangViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<KhachHangViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
