using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.HuongDanDongGoi
{
    public partial class ucHuongDanDongGoiList : BaseForm
    {
        public ucHuongDanDongGoiList()
        {
            InitializeComponent();
            Init();
            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<HuongDanDongGoiViewModel>().GetDataSource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    var info = SF.Get<HuongDanDongGoiViewModel>().GetDetail(data.Id);
                    if (info != null)
                    {
                        FormFactory<Main>.Get().ShowPopupInfo(info);
                    }
                }
            });
        }

        private void gridView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column.FieldName == "KhachHang")
            {
                var view = sender as GridView;

                var rowData1 = view.GetRow(e.RowHandle1) as TLShoes.HuongDanDongGoi;
                var rowData2 = view.GetRow(e.RowHandle2) as TLShoes.HuongDanDongGoi;

                e.Merge = rowData1.DonHang.KhachHangId == rowData2.DonHang.KhachHangId;
                e.Handled = true;
            }
        }
    }
}
