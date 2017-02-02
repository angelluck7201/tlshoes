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

namespace TLShoes.FormControls.QuanLyNguoiDung
{
    public partial class ucUserAccountList : BaseForm
    {
        public ucUserAccountList()
        {
            InitializeComponent();
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<UserAccountViewModel>().GetDataSource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    var info = SF.Get<UserAccountViewModel>().GetDetail(data.Id);
                    FormFactory<Main>.Get().ShowPopupInfo(info);
                }
            });
        }
    }
}
