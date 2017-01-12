using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLShoes.Common
{
    public class ToolTipHelper
    {
        public static ToolTip GetToolTip()
        {
            var toolTip = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ToolTipIcon = ToolTipIcon.Info;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            return toolTip;
        }
    }
}
