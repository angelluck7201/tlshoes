using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ChiLenh
{
    public partial class ChiTietNguyenLieuForm : System.Windows.Forms.Form
    {
        private ucChiLenh chiLenh = null;
        BindingList<ChiTietNguyenLieu> NguyenLieuList = new BindingList<ChiTietNguyenLieu>();
        public ChiTietNguyenLieuForm(ucChiLenh chiLenh, NguyenLieuChiLenh data = null)
        {
            InitializeComponent();
            this.chiLenh = chiLenh;
            if (data != null)
            {
                NguyenLieuList = new BindingList<ChiTietNguyenLieu>(data.ChiTietNguyenLieux.ToList());
            }

            gridControl.DataSource = NguyenLieuList;

            NguyenLieuLookUp.NullText = "";
            NguyenLieuLookUp.Properties.DataSource = SF.Get<NguyenLieuViewModel>().GetList().Select(s => new { s.Ten, s.Id }).ToList();
            NguyenLieuLookUp.PopulateColumns();
            NguyenLieuLookUp.ShowHeader = false;
            NguyenLieuLookUp.Columns["Id"].Visible = false;
            NguyenLieuLookUp.Properties.DisplayMember = "Ten";
            NguyenLieuLookUp.Properties.ValueMember = "Id";
            NguyenLieuLookUp.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        private void ChiTietNguyenLieuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.chiLenh.OnClosePopup(NguyenLieuList.ToList());
        }
    }
}
