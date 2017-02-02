using System;
using System.Drawing;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauThuDao
{
    public partial class ucMauThuDaoList : BaseForm
    {
        public ucMauThuDaoList()
        {
            InitializeComponent();
            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDKT.ToString(), Color.Wheat, Color.Red);
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<MauThuDaoViewModel>().GetDataSource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    var info = SF.Get<MauThuDaoViewModel>().GetDetail(data.Id);
                    if (info != null)
                    {
                        FormFactory<Main>.Get().ShowPopupInfo(info);   
                    }
                }
            });
        }
    }
}
