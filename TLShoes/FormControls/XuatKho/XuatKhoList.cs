using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.XuatKho
{
    public partial class ucXuatKhoList : UserControl
    {
        public ucXuatKhoList()
        {
            InitializeComponent();
            ReloadData();

            ObserverControl.Regist("ucXuatKho", "ucXuatKhoList", ReloadData);
            ObserverControl.Regist("Refresh", "ucXuatKhoList", ReloadData);
            ObserverControl.Regist("Close", "ucXuatKhoList", ReloadData);
            ObserverControl.Regist("Export", "ucXuatKhoList", Export);
        }

        public void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                SF.Get<PhieuXuatKhoViewModel>().GetDataSource(gridControl);
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
                var info = SF.Get<PhieuXuatKhoViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);
            });
        }
    }
}
