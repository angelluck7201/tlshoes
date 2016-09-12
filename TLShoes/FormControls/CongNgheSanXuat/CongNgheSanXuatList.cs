using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.CongNgheSanXuat
{
    public partial class ucCongNgheSanXuatList : UserControl
    {
        public ucCongNgheSanXuatList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucCongNgheSanXuat", "ucCongNgheSanXuatList", ReloadData);
            ObserverControl.Regist("Refresh", "ucCongNgheSanXuatList", ReloadData);
            ObserverControl.Regist("Close", "ucCongNgheSanXuatList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<CongNgheSanXuatViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<CongNgheSanXuatViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
