using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.QuanLyNguoiDung
{
    public partial class ucPhanQuyenList : BaseForm
    {
        public ucPhanQuyenList()
        {
            InitializeComponent();
            Init();
        }

        public override void ReloadData()
        {
            ThreadHelper.LoadForm(() =>
            {
                BaseModel.DisposeDb();
                SF.Get<PhanQuyenNguoiDungViewModel>().GetDataSource(gridControl);
            });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    FormFactory<Main>.Get().ShowPopupInfo(PrimitiveConvert.StringToEnum<Define.LoaiNguoiDung>(data.LoaiNguoiDung));
                }
            });
        }
    }
}
