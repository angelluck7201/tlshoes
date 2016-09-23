using System;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.NguyenLieu
{
    public partial class ucNguyenLieuList : UserControl
    {
        public ucNguyenLieuList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucNguyenLieu", "ucNguyenLieuList", ReloadData);
            ObserverControl.Regist("Refresh", "ucNguyenLieuList", ReloadData);
            ObserverControl.Regist("Close", "ucNguyenLieuList", ReloadData);
            ObserverControl.Regist("Export", "ucNguyenLieuList", Export);
        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<NguyenLieuViewModel>().GetDataSource(gridControl);
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
                var info = SF.Get<NguyenLieuViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);

            });
        }

    }
}
