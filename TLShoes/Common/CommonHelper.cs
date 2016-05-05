using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLShoes.Common
{
    public class CommonHelper
    {
        public static long StringToInt(string item, long valueDefault = 0)
        {
            Int64.TryParse(item, out valueDefault);
            return valueDefault;
        }

        public static string ImageSave(Image image, string name = "")
        {
            var id = name;
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
            }

            var imagePath = Path.Combine(Environment.CurrentDirectory, "image");
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            var path = Path.Combine(imagePath, id);
            image.Save(path);
            return path;
        }
    }
}
