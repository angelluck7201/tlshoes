using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLShoes.Common
{
    public class PrimitiveConvert
    {
        public static long StringToInt(string item, long valueDefault = 0)
        {
            Int64.TryParse(item, out valueDefault);
            return valueDefault;
        }

        public static long? StringToInt(object item, long valueDefault = 0)
        {
            Int64.TryParse(item.ToString(), out valueDefault);
            return valueDefault;
        }

        public static float? StringToFloat(object item, float valueDefault = 0)
        {
            float.TryParse(item.ToString(), out valueDefault);
            return valueDefault;
        }
    }
}
