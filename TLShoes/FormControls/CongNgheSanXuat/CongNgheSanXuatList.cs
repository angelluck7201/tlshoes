using System;
using System.Windows.Forms;
using TLShoes.Common;
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
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<CongNgheSanXuatViewModel>().GetDataSource(gridControl);
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
                var info = SF.Get<CongNgheSanXuatViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);
            });
        }
    }
}
