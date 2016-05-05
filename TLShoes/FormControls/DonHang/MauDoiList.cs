﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.DonHang
{
    public partial class ucMauDoiList : UserControl
    {
        public ucMauDoiList()
        {
            InitializeComponent();

            SF.Get<MauDoiViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucMauDoi", "ucMauDoiList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauDoiList", ReloadData);
            ObserverControl.Regist("Close", "ucMauDoiList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<MauDoiViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<MauDoiViewModel>().GetDetail(data.Id);
            Main.ShowPopupInfo(info);
        }

        private void ucMauDoiList_Load(object sender, EventArgs e)
        {

        }

    }
}
