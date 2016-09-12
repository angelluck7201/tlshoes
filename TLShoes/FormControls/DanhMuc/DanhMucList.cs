using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class ucDanhMucList : UserControl
    {
        public ucDanhMucList()
        {
            InitializeComponent();
            ReloadData();
            ObserverControl.Clear();
            ObserverControl.Regist("ucDanhMuc", "ucDanhMucList", ReloadData);
            ObserverControl.Regist("Refresh", "ucDanhMucList", ReloadData);
            ObserverControl.Regist("Close", "ucDanhMucList", ReloadData);
            ObserverControl.Regist("Export", "ucDanhMucList", Export);
        }

        public void ReloadData()
        {
            SF.Get<DanhMucViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<DanhMucViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
