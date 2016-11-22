using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using TLShoes;
using TLShoes.Common;

namespace TLShoes
{
    public class BaseForm : UserControl
    {

        public void Init()
        {
            AutoRefresh();
            ReloadData();
            ObserverControl.Regist("Refresh", this.Name, ReloadData);
            ObserverControl.Regist("Close", this.Name, ReloadData);
            ObserverControl.Regist("Export", this.Name, Export);
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

        public virtual void Export(object filePath) { }
        public virtual void ReloadData() { }
        public virtual void AutoRefresh()
        {
            var timer = TimerControl.Timer;
            timer.Tick += (a, b) =>
            {
                ReloadData();
            };
        }
    }
}
