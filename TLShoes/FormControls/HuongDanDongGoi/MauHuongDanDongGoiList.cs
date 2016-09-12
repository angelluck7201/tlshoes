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

namespace TLShoes.FormControls.HuongDanDongGoi
{
    public partial class ucMauHuongDanDongGoiList : UserControl
    {
        public ucMauHuongDanDongGoiList()
        {
            InitializeComponent();

            ReloadData();

            ObserverControl.Regist("ucMauHuongDanDongGoi", "ucMauHuongDanDongGoiList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauHuongDanDongGoiList", ReloadData);
            ObserverControl.Regist("Close", "ucMauHuongDanDongGoiList", ReloadData);
            ObserverControl.Regist("Export", "ucMauHuongDanDongGoiList", Export);
        }

        public void ReloadData()
        {
            SF.Get<MauHuongDanDongGoiViewModel>().GetDataSource(gridControl);
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
            var info = SF.Get<MauHuongDanDongGoiViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
