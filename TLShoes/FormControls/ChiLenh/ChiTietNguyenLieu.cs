﻿using System;
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
        BindingList<ChiTietNguyenLieu> NguyenLieuList = new BindingList<ChiTietNguyenLieu>();
        public ucChiTietNguyenLieu(NguyenLieuChiLenh data = null)
        {
            InitializeComponent();
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

        public void SetData(ucNguyenLieuChiLenh data)
        {
            //gridControl.DataSource = data.ChiTietNguyenLieux;
        }
    }
}
