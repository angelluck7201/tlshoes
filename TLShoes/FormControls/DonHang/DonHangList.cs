using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.Form
{
    public partial class ucDonHangList : BaseForm
    {
        public ucDonHangList()
        {
            InitializeComponent();
            Init();
            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<DonHangViewModel>().GetDataSource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
              {
                  dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                  if (data != null && data.Id != null)
                  {
                      var info = SF.Get<DonHangViewModel>().GetDetail(data.Id);
                      FormFactory<Main>.Get().ShowPopupInfo(info);
                  }
              });
        }
    }
}

