using System.Windows.Forms;
using TLShoes;
using TLShoes.Common;

namespace TLShoes
{
    public abstract class BaseForm : UserControl
    {

        public void Init()
        {
            AutoRefresh();
            ReloadData();
            ObserverControl.Regist("Refresh", this.Name, ReloadData);
            ObserverControl.Regist("Close", this.Name, ReloadData);
            ObserverControl.Regist("Export", this.Name, Export);
        }

        protected abstract void Export(object filePath);
        protected abstract void ReloadData();
        protected virtual void AutoRefresh()
        {
            var timer = TimerControl.Timer;
            timer.Tick += (a, b) =>
            {
                ReloadData();
            };
        }
    }
}
