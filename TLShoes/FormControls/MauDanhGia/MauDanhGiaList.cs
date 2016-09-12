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

namespace TLShoes.FormControls.MauDanhGia
{
    public partial class ucMauDanhGiaList : UserControl
    {
        public ucMauDanhGiaList()
        {
            InitializeComponent(); 
            ReloadData();

            ObserverControl.Regist("ucMauDanhGia", "ucMauDanhGiaList", ReloadData);
            ObserverControl.Regist("Refresh", "ucMauDanhGiaList", ReloadData);
            ObserverControl.Regist("Close", "ucMauDanhGiaList", ReloadData);
            ObserverControl.Regist("Export", "ucMauDanhGiaList", Export);

        }

        public void ReloadData()
        {
            SF.Get<MauDanhGiaViewModel>().GetDataSource(gridControl);
            if (gridView.RowCount > 0)
            {
                Main.FeaturesDict["btnExport"].Visible = true;
            }
            else
            {
                Main.FeaturesDict["btnExport"].Visible = false;
            }
        }

        public void Export(object filePath)
        {
            gridView.ExportToXls(filePath.ToString());
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
            var info = SF.Get<MauDanhGiaViewModel>().GetDetail(data.Id);
            FormFactory<Main>.Get().ShowPopupInfo(info);
        }
    }
}
