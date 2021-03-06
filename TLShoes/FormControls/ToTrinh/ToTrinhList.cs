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

            ObserverControl.Regist(Define.ActionType.SAVE, this.Name, ReloadData);
            ObserverControl.Regist(Define.ActionType.REFRESH, this.Name, ReloadData);

            GenerateFormatRuleByValue(gridView, colLoaiNguoiDung, Define.LoaiNguoiDung.GDSX.ToString(), Color.Wheat, Color.Red);

            // Prevent auto load data when open form
            gridControl.DataSource = null;

            // This line of code is generated by Data Source Configuration Wizard
            this.toTrinhInstantFeedbackSource.GetQueryable += entityInstantFeedbackSource1_GetQueryable;
            // This line of code is generated by Data Source Configuration Wizard
            this.toTrinhInstantFeedbackSource.DismissQueryable += entityInstantFeedbackSource1_DismissQueryable;

        }

        public override void ReloadData()
        {
            gridControl.DataSource = null;
            gridControl.DataSource = toTrinhInstantFeedbackSource;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            ThreadHelper.LoadForm(() =>
            {
                var id = GetFocusRowId(sender);
                if (id != 0)
                {
                    FormFactory<Main>.Get().ShowPopupInfo(id);
                }
            });
        }

        // This event is generated by Data Source Configuration Wizard
        void entityInstantFeedbackSource1_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {

            // Instantiate a new DataContext
            TLShoes.GiayTLEntities dataContext = new TLShoes.GiayTLEntities();
            // Assign a queryable source to the EntityInstantFeedbackSource
            e.QueryableSource = dataContext.TongHopToTrinhs;
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
