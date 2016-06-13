using System.Windows.Forms;

namespace TLShoes.FormControls.BangThongSo
{
    public partial class ucBangThongSoList : UserControl
    {
        //public ucBangThongSoList()
        //{
        //    InitializeComponent();
        //    SF.Get<BangThongSoViewModel>().GetDataSource(gridControl);

        //    ObserverControl.Regist("ucBangThongSo", "ucBangThongSoList", ReloadData);
        //    ObserverControl.Regist("Refresh", "ucBangThongSoList", ReloadData);
        //    ObserverControl.Regist("Close", "ucBangThongSoList", ReloadData);

        //}

        //public void ReloadData()
        //{
        //    SF.Get<BangThongSoViewModel>().GetDataSource(gridControl);
        //}

        //private void gridView_DoubleClick(object sender, EventArgs e)
        //{
        //    dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
        //    var info = SF.Get<BangThongSoViewModel>().GetDetail(data.Id);
        //    FormFactory<Main>.Get().ShowPopupInfo(info);
        //}
    }
}