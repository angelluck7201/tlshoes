using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.KeHoachSanXuat
{
    public partial class ucKeHoachSanXuatList : UserControl
    {
        public ucKeHoachSanXuatList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucKeHoachSanXuat", "ucKeHoachSanXuatList", ReloadData);
            ObserverControl.Regist("Refresh", "ucKeHoachSanXuatList", ReloadData);
            ObserverControl.Regist("Close", "ucKeHoachSanXuatList", ReloadData);
            ObserverControl.Regist("Export", "ucKeHoachSanXuatList", Export);

        }

        public void ReloadData()
        {
            SF.Get<KeHoachSanXuatViewModel>().GetDataSource(gridControl);
            if (bandedGridView1.RowCount > 0)
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
            bandedGridView1.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle);
            var info = SF.Get<KeHoachSanXuatViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
