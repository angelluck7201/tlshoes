using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes;
using TLShoes.Common;

namespace TLShoes
{
    public class BaseForm : UserControl
    {
        public BaseForm()
        {
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = typeof(System.Data.Entity.Core.Objects.EntityFunctions);
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = typeof(System.Data.Entity.SqlServer.SqlFunctions);
        }

        public void GenerateFormatRuleByValue(GridView gridView, GridColumn column, object value, Color backColor, Color fontColor)
        {
            GridFormatRule gridFormatRule = new GridFormatRule();
            gridFormatRule.Column = column;
            gridFormatRule.ApplyToRow = true;
            FormatConditionRuleValue formatConditionRuleValue = new FormatConditionRuleValue();
            formatConditionRuleValue.PredefinedName = value.ToString();
            formatConditionRuleValue.Condition = FormatCondition.Equal;
            formatConditionRuleValue.Value1 = value.ToString();
            formatConditionRuleValue.Appearance.BackColor = backColor;
            formatConditionRuleValue.Appearance.ForeColor = fontColor;
            formatConditionRuleValue.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue.Appearance.Options.UseForeColor = true;
            gridFormatRule.Rule = formatConditionRuleValue;
            gridView.FormatRules.Add(gridFormatRule);
        }

        protected void LoadImageAsyncGrid(object sender, CustomColumnDataEventArgs e, string displayField, string pathField)
        {
            var gridView = sender as GridView;

            var fieldName = e.Column.FieldName;

            if (fieldName == displayField && e.IsGetData)
            {
                var filePath = gridView.GetRowCellValue(e.ListSourceRowIndex, pathField);
                if (filePath != null)
                {
                    e.Value = FileHelper.ImageFromFile(filePath.ToString());
                }
            }
        }

        protected long GetFocusRowId(object objGridView)
        {
            var gridView = objGridView as GridView;
            if (gridView != null)
            {
                dynamic data = gridView.GetRow(gridView.FocusedRowHandle);
                if (data != null)
                {
                    if (data is DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)
                    {
                        return GetFocusRowAsyncGridViewId(data);
                    }
                    else
                    {
                        return GetFocusRowDefaultGridViewId(data);
                    }
                }
            }

            return 0;
        }

        private long GetFocusRowAsyncGridViewId(dynamic focusedObj)
        {
            var originalData = focusedObj.OriginalRow;
            if (originalData != null && originalData.Id != null)
            {
                return originalData.Id;
            }
            return 0;
        }

        private long GetFocusRowDefaultGridViewId(dynamic focusedObj)
        {
            var originalData = focusedObj;
            if (originalData != null && originalData.Id != null)
            {
                return originalData.Id;
            }
            return 0;
        }

        public virtual void ReloadData() { }
        public virtual void AutoRefresh()
        {
            var timer = TimerControl.Timer;
            timer.Tick += (a, b) =>
            {
                if (FormBehavior.IsMainFormEnable())
                {
                    ReloadData();
                }
            };
        }
    }
}
