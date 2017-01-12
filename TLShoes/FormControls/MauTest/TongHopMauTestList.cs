using System;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.TongHopMauTest
{
    public partial class ucTongHopMauTestList : BaseForm
    {
        public ucTongHopMauTestList()
        {
            InitializeComponent();

            Init();
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<MauDoiViewModel>().GetDataSummarySource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle);
                if (data != null)
                {
                    FormFactory<Main>.Get().ShowPopupInfo(data.Id);                    
                }
            });
        }
    }
}
