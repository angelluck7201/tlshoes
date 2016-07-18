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

namespace TLShoes.FormControls.MauDanhGia
{
    public partial class ucMauDanhGiaList : UserControl
    {
        public ucMauDanhGiaList()
        {
            InitializeComponent(); 
            SF.Get<MauDanhGiaViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucMauDanhGia", "ucMauDanhGiaList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauDanhGiaList", ReloadData);
            ObserverControl.Regist("Close", "ucMauDanhGiaList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<MauDanhGiaViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<MauDanhGiaViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
