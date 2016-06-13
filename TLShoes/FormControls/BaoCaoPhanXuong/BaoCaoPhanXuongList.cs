using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.BaoCaoPhanXuong
{
    public partial class ucBaoCaoPhanXuongList : UserControl
    {
        public ucBaoCaoPhanXuongList()
        {
            InitializeComponent();

            SF.Get<BaoCaoPhanXuongViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucBaoCaoPhanXuong", "ucBaoCaoPhanXuongList", ReloadData);
            ObserverControl.Regist("Refresh", "ucBaoCaoPhanXuongList", ReloadData);
            ObserverControl.Regist("Close", "ucBaoCaoPhanXuongList", ReloadData);

        }

        public void ReloadData()
        {
            SF.Get<BaoCaoPhanXuongViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<BaoCaoPhanXuongViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }

    }
}
