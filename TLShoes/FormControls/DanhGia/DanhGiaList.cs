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

namespace TLShoes.FormControls.DanhGia
{
    public partial class ucDanhGiaList : UserControl
    {
        public ucDanhGiaList()
        {
            InitializeComponent();
            ReloadData();
            ObserverControl.Regist("ucDanhGia", "ucDanhGiaList", ReloadData);
            ObserverControl.Regist("Refresh", "ucDanhGiaList", ReloadData);
            ObserverControl.Regist("Close", "ucDanhGiaList", ReloadData);
            ObserverControl.Regist("Export", "ucDanhGiaList", Export);
        }

        public void ReloadData()
        {
            SF.Get<DanhGiaViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<DanhGiaViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
