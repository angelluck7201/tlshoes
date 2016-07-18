using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.MauTest
{
    public partial class ucTongHopMauTest : UserControl
    {
        public ucTongHopMauTest(object data = null)
        {
            InitializeComponent();
            if (data != null)
            {
                SF.Get<MauTestViewModel>().GetDataSource(gridMauTest, (long)data);
                SF.Get<MauSanXuatViewModel>().GetDataSource(gridMauSanXuat, (long)data);
            }
        }
    }
}
