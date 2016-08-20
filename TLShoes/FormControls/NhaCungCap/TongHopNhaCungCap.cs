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

namespace TLShoes.FormControls.NhaCungCap
{
    public partial class ucTongHopNhaCungCap : UserControl
    {
        public ucTongHopNhaCungCap()
        {
            InitializeComponent();
            ReloadData();
        }

        public void ReloadData()
        {
            SF.Get<NhaCungCapViewModel>().GetSummary(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<NhaCungCapViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
