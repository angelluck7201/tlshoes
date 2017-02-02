﻿using System;
using System.Drawing;
using System.Windows.Forms;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.ToTrinh
{
    public partial class ucToTrinhList : BaseForm
    {
        public ucToTrinhList()
        {
            InitializeComponent();
            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);
        }

        public override void ReloadData()
        {
          
                ThreadHelper.LoadForm(() =>
                {
                    BaseModel.DisposeDb();
                    SF.Get<ToTrinhViewModel>().GetDataSource(gridControl);
                });
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            var data = gridView.GetRow(gridView.FocusedRowHandle) as TLShoes.ToTrinh;
            if (data != null)
            {
                ThreadHelper.LoadForm(() =>
                {
                    var info = SF.Get<ToTrinhViewModel>().GetDetail(data.Id);
                    if (info != null)
                    {
                        FormFactory<Main>.Get().ShowPopupInfo(info.TongHopToTrinh);                        
                    }
                });
            }

        }
    }
}
