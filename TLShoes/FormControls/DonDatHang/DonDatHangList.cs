using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TLShoes.FormControls.DonDatHang
{
    public partial class ucDonDatHangList : UserControl
    {
        public ucDonDatHangList()
        {
            InitializeComponent();
            ReloadData();

            ObserverControl.Regist("ucDonDatHang", "ucDonDatHangList", ReloadData);
            ObserverControl.Regist("Refresh", "ucDonDatHangList", ReloadData);
            ObserverControl.Regist("Close", "ucDonDatHangList", ReloadData);
            ObserverControl.Regist("Export", "ucDonDatHangList", Export);
        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<DonDatHangViewModel>().GetDataSource(gridControl);
                FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = false;
            });
        }

        public void Export(object filePath)
        {
            
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                var info = SF.Get<DonDatHangViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);
            });
        }
    }
}
