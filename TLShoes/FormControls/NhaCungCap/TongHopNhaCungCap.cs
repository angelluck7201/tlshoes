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

namespace TLShoes.FormControls.NhaCungCap
{
    public partial class ucTongHopNhaCungCap : BaseForm
    {
        public ucTongHopNhaCungCap()
        {
            InitializeComponent();
            Init();
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<NhaCungCapViewModel>().GetSummary(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    var info = SF.Get<NhaCungCapViewModel>().GetDetail(data.Id);
                    if (info != null)
                    {
                        FormFactory<Main>.Get().ShowPopupInfo(info);                        
                    }
                }
            });
        }
    }
}
