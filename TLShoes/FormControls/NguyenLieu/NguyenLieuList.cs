using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.NguyenLieu
{
    public partial class ucNguyenLieuList : UserControl
    {
        public ucNguyenLieuList()
        {
            InitializeComponent();

            SF.Get<NguyenLieuViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucNguyenLieu", "ucNguyenLieuList", ReloadData);
            ObserverControl.Regist("Refresh", "ucNguyenLieuList", ReloadData);
            ObserverControl.Regist("Close", "ucNguyenLieuList", ReloadData);

        }

        public void ReloadData()
        {
            SF.Get<NguyenLieuViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<NguyenLieuViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }

    }
}
