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
