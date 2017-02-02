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
    public partial class ucXuatKhoList : BaseForm
    {
        public ucXuatKhoList()
        {
            InitializeComponent();
            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<PhieuXuatKhoViewModel>().GetDataSource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    var info = SF.Get<PhieuXuatKhoViewModel>().GetDetail(data.Id);
                    if (info != null)
                    {
                        FormFactory<Main>.Get().ShowPopupInfo(info);
                    }
                }
            });
        }
    }
}
