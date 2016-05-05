using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLShoes
{
    public partial class DefaultForm : System.Windows.Forms.Form
    {
        public DefaultForm()
        {
            InitializeComponent();
        }

        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ObserverControl.PulishAction("Close");
        }
    }
}
