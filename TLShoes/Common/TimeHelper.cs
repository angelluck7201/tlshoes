using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLShoes.Common
{
    public static class TimeHelper
    {
        public static long CurrentTimeStamp()
        {
            return DateTimeToTimeStamp(DateTime.UtcNow);
        }

        public static long DateTimeToTimeStamp(DateTime datetime)
        {
            DateTime baseDate = new DateTime(1970, 1, 1);
            TimeSpan diff = datetime - baseDate;
            return (long)diff.TotalMilliseconds;
        }

        public static string TimestampToString(long? time)
        {
            if (time > 0)
            {
                var date = new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToDouble(time)).AddHours(7);
                return date.ToString("G");
            }
            return string.Empty;
        }
    }
}
