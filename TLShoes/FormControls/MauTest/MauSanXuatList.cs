using System;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauSanXuat
{
    public partial class ucMauSanXuatList : BaseUserControl
    {
        public ucMauSanXuatList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucMauSanXuat", "ucMauSanXuatList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauSanXuatList", ReloadData);
            ObserverControl.Regist("Close", "ucMauSanXuatList", ReloadData);
            ObserverControl.Regist("Export", "ucMauSanXuatList", Export);

        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<MauSanXuatViewModel>().GetDataSource(gridControl);
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
                var info = SF.Get<MauSanXuatViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);
            });
        }
    }
}
