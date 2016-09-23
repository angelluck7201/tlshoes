using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Configuration;

namespace TLShoes.Common
{
    public class FileHelper
    {
        public static float LIMIT_SIZE = 800;
        public static string FLAG_ROTATE = "FLAG_ROTATE";

        private static string _directorPath = "";
        public static string DirectorPath
        {
            get
            {
                if (string.IsNullOrEmpty(_directorPath))
                {
                    _directorPath = @ConfigurationManager.AppSettings["FilePath"];
                }
                return _directorPath;
            }
        }

        public static string TemplatePath
        {
            get { return Path.Combine(ResourcePath, "ExportTemplate"); }
        }

        public static string ResourcePath
        {
            get { return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources"); }
        }

        public static string DefaultImagePath
        {
            get { return Path.Combine(ResourcePath, "default.png"); }
        }

        public static string ImagePath
        {
            get
            {
                return Path.Combine(DirectorPath, "image");
            }
        }

        public static void ShowImagePopup(object sender, EventArgs e)
        {
            var control = sender as Control;
            var senderType = control.GetType().Name;
            if (senderType == "PictureEdit")
            {
                ShowImagePopup((control as PictureEdit).Image);
            }
            else if (senderType == "ImageEdit")
            {
                ShowImagePopup((control as ImageEdit).Image);
            }
        }

        public static void ShowImagePopup(Image image)
        {
            if (image == null) return;
            var imageForm = new DefaultForm();
            var pictureEdit = new PictureEdit();

            var adjustImage = AdjustSize(image.Width, image.Height);
            pictureEdit.Image = image;
            pictureEdit.Properties.SizeMode = PictureSizeMode.Squeeze;
            pictureEdit.Dock = DockStyle.Fill;

            imageForm.Controls.Add(pictureEdit);
            imageForm.Width = adjustImage.Key;
            imageForm.Height = adjustImage.Value;

            imageForm.Show();
        }

        public static KeyValuePair<int, int> AdjustSize(int width, int height)
        {
            var maxInput = Math.Max(width, height);
            if (LIMIT_SIZE < maxInput)
            {
                var adjustFactor = LIMIT_SIZE / maxInput;
                return new KeyValuePair<int, int>((int)(width * adjustFactor), (int)(height * adjustFactor));
            }
            return new KeyValuePair<int, int>(width, height);
        }


        public static string ImageSave(Image image, object name = null)
        {
            if (image == null) return string.Empty;
            var id = name;
            if (id == null)
            {
                id = Guid.NewGuid().ToString();
            }

            if (!Directory.Exists(ImagePath))
            {
                Directory.CreateDirectory(ImagePath);
            }
            var path = Path.Combine(ImagePath, id.ToString());

            // Ignore save file if not update image
            //            if (IsFileInUse(path))
            //            {
            //                DeleteFile(path);
            var saveImage = new Bitmap(image);
            saveImage.Save(path);
            //            }
            return path;
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public static bool IsFileInUse(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("'path' cannot be null or empty.", "path");

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) { }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        public static void SetImage(PictureEdit imageContainer, string imagePath)
        {
            //using (new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            //{
            var image = ImageFromFile(imagePath);
            imageContainer.Image = image;
            imageContainer.Tag = imagePath.Split('\\').Last();
            imageContainer.ToolTipTitle = FLAG_ROTATE;
            //}
        }

        public static Image ImageFromFile(string filePath)
        {
            Image image = null;
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    image = Image.FromStream(stream);
                }
            }
            catch (Exception e)
            {
                using (var stream = new FileStream(DefaultImagePath, FileMode.Open, FileAccess.Read))
                {
                    image = Image.FromStream(stream);
                }
            }
            return image;

        }
    }
}
