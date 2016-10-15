using System;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes
{
    public partial class ucDanhMucList : BaseForm
    {
        public ucDanhMucList()
        {
            InitializeComponent();
            Init();
        }


        protected override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<DanhMucViewModel>().GetDataSource(gridControl);
                if (gridView.RowCount > 0)
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = true;
                }
                else
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = false;
                }
            });
        }

        protected override void Export(object filePath)
        {
            gridView.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    var info = SF.Get<DanhMucViewModel>().GetDetail(data.Id);
                    FormFactory<Main>.Get().ShowPopupInfo(info);
                }
            });
        }
    }
}
