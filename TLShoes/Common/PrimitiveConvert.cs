using System;

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

        public static T StringToEnum<T>(string item) where T : struct, IConvertible
        {
            T result = default(T);
            Enum.TryParse<T>(item, out result);
            return result;
        }
    }
}
