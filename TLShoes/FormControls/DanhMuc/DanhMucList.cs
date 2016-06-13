using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class ucDanhMucList : UserControl
    {
        public ucDanhMucList()
        {
            InitializeComponent();
            SF.Get<DanhMucViewModel>().GetDataSource(gridControl);
            ObserverControl.Clear();
            ObserverControl.Regist("ucDanhMuc", "ucDanhMucList", ReloadData);
            ObserverControl.Regist("Refresh", "ucDanhMucList", ReloadData);
            ObserverControl.Regist("Close", "ucDanhMucList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<DanhMucViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<DanhMucViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
