using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ChiLenh
{
    public partial class ucChiTietNguyenLieu : UserControl
    {
        public ucChiTietNguyenLieu(List<ChiTietNguyenLieu> data = null )
        {
            InitializeComponent();

          
        }

        public void SetData(NguyenLieuChiLenh data)
        {
            //gridControl.DataSource = data.ChiTietNguyenLieux;
        }
    }
}
