﻿using System;
using System.Drawing;
using TLShoes.Common;
using TLShoes.ViewModels;

namespace TLShoes.FormControls.DonDatHang
{
    public partial class ucDonDatHangList : BaseForm
    {
        public ucDonDatHangList()
        {
            InitializeComponent();
            ObserverControl.Regist(Define.ActionType.SAVE, this.Name, ReloadData);
            ObserverControl.Regist(Define.ActionType.REFRESH, this.Name, ReloadData);

            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);
            // This line of code is generated by Data Source Configuration Wizard
            this.donDatHangInstantFeedbackSource.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            // This line of code is generated by Data Source Configuration Wizard
            this.donDatHangInstantFeedbackSource.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;
        }

        public override void ReloadData()
        {
            gridControl.DataSource = null;
            gridControl.DataSource = donDatHangInstantFeedbackSource;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                var info = SF.Get<DonDatHangViewModel>().GetDetail(GetFocusRowId(sender));
                if (info != null)
                {
                    FormFactory<Main>.Get().ShowPopupInfo(info);
                }
            });
        }

        // This event is generated by Data Source Configuration Wizard
        void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {

            // Instantiate a new DataContext
            TLShoes.GiayTLEntities dataContext = new TLShoes.GiayTLEntities();
            // Assign a queryable source to the EntityInstantFeedbackSource
            e.QueryableSource = dataContext.DonDatHangs;
            // Assign the DataContext to the Tag property,
            // to dispose of it in the DismissQueryable event handler
            e.Tag = dataContext;
        }

        // This event is generated by Data Source Configuration Wizard
        void entityInstantFeedbackSource1_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {

            // Dispose of the DataContext
            ((TLShoes.GiayTLEntities)e.Tag).Dispose();
        }
    }
}
