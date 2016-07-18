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
            SF.Get<PhieuNhapKhoViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucNhapKho", "ucNhapKhoList", ReloadData);
            ObserverControl.Regist("Refresh", "ucNhapKhoList", ReloadData);
            ObserverControl.Regist("Close", "ucNhapKhoList", ReloadData);

        }

        public void ReloadData()
        {
            SF.Get<PhieuNhapKhoViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<PhieuNhapKhoViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
