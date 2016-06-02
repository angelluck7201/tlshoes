using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLShoes.Common
{
    public class FileHelper
    {
        public static string DefaultImagePath
        {
            get { return Path.Combine(ImagePath, "default.png"); }
        }

        public static string ImagePath
        {
            get { return Path.Combine(Environment.CurrentDirectory, "image"); }
        }


        public static string ImageSave(Image image, string name = "")
        {
            if (image == null) return string.Empty;
            var id = name;
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
            }

            if (!Directory.Exists(ImagePath))
            {
                Directory.CreateDirectory(ImagePath);
            }
            var path = Path.Combine(ImagePath, id);
           // DeleteFile(path);
            image.Save(path);
            return path;
        }


        public static Image ImageFromFile(string filePath)
        {
            Image image = null;
            try
            {
                image = Image.FromFile(filePath);
                return image;
            }
            catch (Exception e)
            {
                return Image.FromFile(DefaultImagePath);
            }
        }
    }
}
