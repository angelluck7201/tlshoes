using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.NhapKho
{
    public partial class ucNhapKhoList : UserControl
    {
        public ucNhapKhoList()
        {
            InitializeComponent();
            ReloadData();

            ObserverControl.Regist("ucNhapKho", "ucNhapKhoList", ReloadData);
            ObserverControl.Regist("Refresh", "ucNhapKhoList", ReloadData);
            ObserverControl.Regist("Close", "ucNhapKhoList", ReloadData);
            ObserverControl.Regist("Export", "ucNhapKhoList", Export);
        }

        public void ReloadData()
        {
            SF.Get<PhieuNhapKhoViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<PhieuNhapKhoViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
