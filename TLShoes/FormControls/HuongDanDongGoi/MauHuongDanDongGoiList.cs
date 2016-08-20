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

namespace TLShoes.FormControls.HuongDanDongGoi
{
    public partial class ucMauHuongDanDongGoiList : UserControl
    {
        public ucMauHuongDanDongGoiList()
        {
            InitializeComponent(); 
            
            SF.Get<MauHuongDanDongGoiViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucMauHuongDanDongGoi", "ucMauHuongDanDongGoiList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauHuongDanDongGoiList", ReloadData);
            ObserverControl.Regist("Close", "ucMauHuongDanDongGoiList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<MauHuongDanDongGoiViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<MauHuongDanDongGoiViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
