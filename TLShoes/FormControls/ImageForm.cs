using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TLShoes.Common;

namespace TLShoes.FormControls
{
    public partial class ImageForm : System.Windows.Forms.Form
    {
        public ImageForm(Image image)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(6f, 13f);

            pictureEdit1.Image = image;
        }

        private void btlRight_Click(object sender, EventArgs e)
        {
            var image = pictureEdit1.Image;
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureEdit1.Image = image;
            AdjustSize(image);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            var image = pictureEdit1.Image;
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureEdit1.Image = image;
            AdjustSize(image);
        }

        private void AdjustSize(Image image)
        {
            var adjustFactor = FileHelper.AdjustSize(image.Width, image.Height);
            this.Size = new Size(adjustFactor.Key, adjustFactor.Value);
        }
    }
}
