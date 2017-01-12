using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.BaoCaoPhanXuong
{
    public partial class ucBaoCaoPhanXuongList : BaseForm
    {
        public ucBaoCaoPhanXuongList()
        {
            InitializeComponent();
            Init();
            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);
            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.PKH.ToString(), Color.Honeydew, Color.Green);
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<BaoCaoPhanXuongViewModel>().GetDataSource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    var info = SF.Get<BaoCaoPhanXuongViewModel>().GetDetail(data.Id);
                    if (info != null)
                    {
                        FormFactory<Main>.Get().ShowPopupInfo(info);
                    }
                }
            });
        }
    }
}
