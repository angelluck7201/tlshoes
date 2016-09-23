using System;
using System.Threading;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.Form
{
    public partial class ucDonHangList : UserControl
    {
        public ucDonHangList()
        {
            InitializeComponent();
            ReloadData();

            ObserverControl.Regist("ucDonHang", "ucDonHangList", ReloadData);
            ObserverControl.Regist("Refresh", "ucDonHangList", ReloadData);
            ObserverControl.Regist("Close", "ucDonHangList", ReloadData);
            ObserverControl.Regist("Export", "ucDonHangList", Export);
        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<DonHangViewModel>().GetDataSource(gridControl);
                if (gridView.RowCount > 0)
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = true;
                }
                else
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = false;
                }
            });
        }

        public void Export(object filePath)
        {
            gridView.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
              {
                  dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                  if (data != null && data.Id != null)
                  {
                      var info = SF.Get<DonHangViewModel>().GetDetail(data.Id);
                      FormFactory<Main>.Get().ShowPopupInfo(info);
                  }
              });
        }
    }
}

