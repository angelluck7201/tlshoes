﻿using System;

namespace TLShoes.Common
{
    public static class TimeHelper
    {
        public static DateTime Current()
        {
            return DateTime.Now;
        }
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

        public static DateTime TimeStampToDateTime(long? time, string format = "G")
        {
            DateTime baseDate = new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToDouble(time)).AddHours(7);
            return baseDate;
        }

        public static long StringToTimeStamp(string time)
        {
            DateTime baseDate = new DateTime(1970, 1, 1);
            DateTime datetime = Convert.ToDateTime(time);
            TimeSpan diff = datetime - baseDate;
            return (long)diff.TotalMilliseconds;
        }

       public static string TimestampToString(long? time, string format = "G")
        {
            if (time > 0)
            {
                var date = new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToDouble(time)).AddHours(7);
                return date.ToString(format);
            }
            return string.Empty;
        }
    }
}
