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

namespace TLShoes.FormControls.MauThuDao
{
    public partial class ucMauThuDaoList : BaseUserControl
    {
        public ucMauThuDaoList()
        {
            InitializeComponent();

            SF.Get<MauThuDaoViewModel>().GetDataSource(gridControl);

            ObserverControl.Regist("ucMauThuDao", "ucMauThuDaoList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauThuDaoList", ReloadData);
            ObserverControl.Regist("Close", "ucMauThuDaoList", ReloadData);
        }

        public void ReloadData()
        {
            SF.Get<MauThuDaoViewModel>().GetDataSource(gridControl);
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<MauThuDaoViewModel>().GetDetail(data.Id);
            Main.ShowPopupInfo(info);
        }
    }
}