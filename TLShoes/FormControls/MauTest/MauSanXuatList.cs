using System;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauSanXuat
{
    public partial class ucMauSanXuatList : BaseUserControl
    {
        public ucMauSanXuatList()
        {
            InitializeComponent();

            SF.Get<MauSanXuatViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucMauSanXuat", "ucMauSanXuatList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauSanXuatList", ReloadData);
            ObserverControl.Regist("Close", "ucMauSanXuatList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<MauSanXuatViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<MauSanXuatViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
