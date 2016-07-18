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

namespace TLShoes.FormControls.XuatKho
{
    public partial class ucXuatKhoList : UserControl
    {
        public ucXuatKhoList()
        {
            InitializeComponent();
            SF.Get<PhieuXuatKhoViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucXuatKho", "ucXuatKhoList", ReloadData);
            ObserverControl.Regist("Refresh", "ucXuatKhoList", ReloadData);
            ObserverControl.Regist("Close", "ucXuatKhoList", ReloadData);

        }

        public void ReloadData()
        {
            SF.Get<PhieuXuatKhoViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<PhieuXuatKhoViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
