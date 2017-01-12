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

        private static string _sourcePath = "";
        public static string SourcePath
        {
            get
            {
                if (String.IsNullOrEmpty(_sourcePath))
                {
                    _sourcePath = Directory.GetCurrentDirectory();
                }
                return _sourcePath;
            }
        }

        public static string TemplatePath
        {
            get { return Path.Combine(ResourcePath, "ExportTemplate"); }
        }

        public static string ResourcePath
        {
            get { return Path.Combine(Directory.GetParent(SourcePath).Parent.FullName, "Resources"); }
        }

        public static string DefaultImagePath
        {
            get { return Path.Combine(ImagePath, "default.png"); }
        }

        public static string ImagePath
        {
            get
            {
                return ConfigHelper.FileConfigPath;
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
            if (image == null) return String.Empty;
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
            return id.ToString();
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
            if (String.IsNullOrEmpty(path))
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

        public static void SetImage(PictureEdit imageContainer, string imageName)
        {
            //using (new FileStream(imageName, FileMode.Open, FileAccess.Read))
            //{
            var filePath = Path.Combine(ImagePath, imageName);
            var image = ImageFromFile(filePath);
            imageContainer.Image = image;
            imageContainer.Tag = imageName.Split('\\').Last();
            imageContainer.ToolTipTitle = FLAG_ROTATE;
            //}
        }

        public static Image ImageFromFile(string fileName)
        {
            Image image = null;
            try
            {
                var filePath = Path.Combine(ImagePath, fileName);
                if (File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        image = Image.FromStream(stream);
                    }
                }
                else
                {
                    image = GetDefaultImage();
                }
            }
            catch (Exception e)
            {
                image = GetDefaultImage();
            }
            return image;
        }

        public static Image GetDefaultImage()
        {
            using (var stream = new FileStream(DefaultImagePath, FileMode.Open, FileAccess.Read))
            {
                var image = Image.FromStream(stream);
                return image;
            }
        }

        public static void CopyFolder(string sourcePath, string desPath)
        {
            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!Directory.Exists(desPath))
            {
                Directory.CreateDirectory(desPath);
            }

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    var fileName = Path.GetFileName(s);
                    var destFile = Path.Combine(desPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
        }

        public static void UpdateAppConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;
            if (app.Settings[key] != null)
            {
                app.Settings[key].Value = value;
            }
            else
            {
                app.Settings.Add(key, value);
            }
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
