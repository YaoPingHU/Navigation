using System;

namespace Hubert.Utility.Lite.Extension
{
    public static class DateTimeExtensions
    {
        public static TimeSpan GetTimeSpan(this DateTime startTime, DateTime endTime)
        {
            return endTime - startTime;
        }

        public static string ToDateTime(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToDateTimeF(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }


        public static string ToPrettyDate(this DateTime date)
        {
            var timeSince = DateTime.Now.Subtract(date);

            if (timeSince.TotalMilliseconds < 1) return "还未到";

            if (timeSince.TotalMinutes < 1) return "刚刚";

            if (timeSince.TotalMinutes < 2) return "1 分钟前";

            if (timeSince.TotalMinutes < 60) return string.Format("{0} 分钟前", timeSince.Minutes);

            if (timeSince.TotalMinutes < 120) return "1 小时前";

            if (timeSince.TotalHours < 24) return string.Format("{0} 小时前", timeSince.Hours);

            if (timeSince.TotalDays == 1) return "昨天";

            if (timeSince.TotalDays < 7) return string.Format("{0} 天前", timeSince.Days);

            if (timeSince.TotalDays < 14) return "上周";

            return date.ToDateTime();

        }
    }
}
