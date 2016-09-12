using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class ucKhachHangList : UserControl
    {
        public ucKhachHangList()
        {
            InitializeComponent();
            ReloadData();
            ObserverControl.Regist("ucKhachHang", "ucKhachHangList", ReloadData);
            ObserverControl.Regist("Refresh", "ucKhachHangList", ReloadData);
            ObserverControl.Regist("Close", "ucKhachHangList", ReloadData);
            ObserverControl.Regist("Export", "ucKhachHangList", Export);

        }

        public void ReloadData()
        {
            SF.Get<KhachHangViewModel>().GetDataSource(gridControl);
            if (gridView.RowCount > 0)
            {
                Main.FeaturesDict["btnExport"].Visible = true;
            }
            else
            {
                Main.FeaturesDict["btnExport"].Visible = false;
            }
        }

        public void Export(object filePath)
        {
            gridView.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<KhachHangViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
