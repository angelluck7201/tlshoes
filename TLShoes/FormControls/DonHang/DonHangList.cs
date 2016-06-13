using System;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.Form
{
    public partial class ucDonHangList : UserControl
    {
        public ucDonHangList()
        {
            InitializeComponent();
            ReloadData();

            ObserverControl.Regist("ucDonHang", "ucDonHangList", ReloadData);
            ObserverControl.Regist("Refresh", "ucDonHangList", ReloadData);
            ObserverControl.Regist("Close", "ucDonHangList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<DonHangViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<DonHangViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //    if (e.Column.FieldName == "Hinh" && e.IsGetData)
            //    {

            //        GridView view = sender as GridView;

            //        string colorName = (string)view.GetRowCellValue(e, "Color");

            //        string fileName = GetFileName(colorName).ToLower();

            //        if (!Images.ContainsKey(fileName))
            //        {

            //            Image img = null;

            //            try
            //            {

            //                string filePath = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, ImageDir + fileName, false);

            //                img = Image.FromFile(filePath);

            //            }

            //            catch
            //            {

            //            }

            //            Images.Add(fileName, img);

            //        }

            //        e.Value = Images[fileName];

            //    }
        }
    }
}

