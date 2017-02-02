using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using TLShoes.Common;
using TLShoes.ViewModels;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TLShoes.FormControls.DonDatHang
{
    public partial class ucDonDatHangList : BaseForm
    {
        public ucDonDatHangList()
        {
            InitializeComponent();
            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<DonDatHangViewModel>().GetDataSource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    var info = SF.Get<DonDatHangViewModel>().GetDetail(data.Id);
                    if (info != null)
                    {
                        FormFactory<Main>.Get().ShowPopupInfo(info);                       
                    }
                }
            });
        }
    }
}
