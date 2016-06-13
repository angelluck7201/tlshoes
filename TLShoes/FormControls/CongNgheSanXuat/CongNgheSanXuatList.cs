using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.CongNgheSanXuat
{
    public partial class ucCongNgheSanXuatList : UserControl
    {
        public ucCongNgheSanXuatList()
        {

            InitializeComponent();


            SF.Get<CongNgheSanXuatViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucCongNgheSanXuat", "ucCongNgheSanXuatList", ReloadData);
            ObserverControl.Regist("Refresh", "ucCongNgheSanXuatList", ReloadData);
            ObserverControl.Regist("Close", "ucCongNgheSanXuatList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<CongNgheSanXuatViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<CongNgheSanXuatViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
