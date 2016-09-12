using System;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauThuDao
{
    public partial class ucMauThuDaoList : BaseUserControl
    {
        public ucMauThuDaoList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucMauThuDao", "ucMauThuDaoList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauThuDaoList", ReloadData);
            ObserverControl.Regist("Close", "ucMauThuDaoList", ReloadData);
            ObserverControl.Regist("Export", "ucMauThuDaoList", Export);

        }

        public void ReloadData()
        {
            SF.Get<MauThuDaoViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<MauThuDaoViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
