using System;
using System.Drawing;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.KeHoachSanXuat
{
    public partial class ucKeHoachSanXuatList : BaseForm
    {
        public ucKeHoachSanXuatList()
        {
            InitializeComponent();
            Init();

            GenerateFormatRuleByValue(bandedGridView1, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);
            GenerateFormatRuleByValue(bandedGridView1, colLoaiNguoiDung, Define.LoaiNguoiDung.CBDH.ToString(), Color.Honeydew, Color.Green);
            GenerateFormatRuleByValue(bandedGridView1, colLoaiNguoiDung, Define.LoaiNguoiDung.PVT.ToString(), Color.Honeydew, Color.Green);
            GenerateFormatRuleByValue(bandedGridView1, colLoaiNguoiDung, Define.LoaiNguoiDung.PKT.ToString(), Color.Honeydew, Color.Green);
            GenerateFormatRuleByValue(bandedGridView1, colLoaiNguoiDung, Define.LoaiNguoiDung.TRUONG_PKT.ToString(), Color.Honeydew, Color.Green);
            GenerateFormatRuleByValue(bandedGridView1, colLoaiNguoiDung, Define.LoaiNguoiDung.TRUONG_PVT.ToString(), Color.Honeydew, Color.Green);
            GenerateFormatRuleByValue(bandedGridView1, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Honeydew, Color.Green);
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();

                SF.Get<KeHoachSanXuatViewModel>().GetDataSource(gridControl);
                if (bandedGridView1.RowCount > 0)
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = true;
                }
                else
                {
                    FormFactory<Main>.Get().FeaturesDict["btnExport"].Visible = false;
                }
            });
        }

        public override void Export(object filePath)
        {
            bandedGridView1.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle);
                var info = SF.Get<KeHoachSanXuatViewModel>().GetDetail(data.Id);
                FormFactory<Main>.Get().ShowPopupInfo(info);
            });
        }
    }
}
