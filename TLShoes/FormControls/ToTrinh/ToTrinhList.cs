using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinhList : UserControl
    {
        public ucToTrinhList()
        {
            InitializeComponent();
            ReloadData();
            ObserverControl.Regist("ucToTrinh", "ucToTrinhList", ReloadData);
            ObserverControl.Regist("Refresh", "ucToTrinhList", ReloadData);
            ObserverControl.Regist("Close", "ucToTrinhList", ReloadData);
        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
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
