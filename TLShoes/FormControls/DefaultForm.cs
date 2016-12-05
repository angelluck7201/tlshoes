using System.Drawing;
using System.Windows.Forms;
using TLShoes.Common;

namespace TLShoes
{
    public partial class DefaultForm : System.Windows.Forms.Form
    {
        public DefaultForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
        }

        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormBehavior.Close(this);
            ObserverControl.PulishAction("Close");
        }
    }
}
