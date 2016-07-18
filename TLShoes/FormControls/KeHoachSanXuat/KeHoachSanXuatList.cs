using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.KeHoachSanXuat
{
    public partial class ucKeHoachSanXuatList : UserControl
    {
        public ucKeHoachSanXuatList()
        {
            InitializeComponent();

            SF.Get<KeHoachSanXuatViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucKeHoachSanXuat", "ucKeHoachSanXuatList", ReloadData);
            ObserverControl.Regist("Refresh", "ucKeHoachSanXuatList", ReloadData);
            ObserverControl.Regist("Close", "ucKeHoachSanXuatList", ReloadData);

        }

        public void ReloadData()
        {
            SF.Get<KeHoachSanXuatViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle);
            var info = SF.Get<KeHoachSanXuatViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
