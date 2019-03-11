using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.utils
{
    class Times
    {

        // 【获取当前系统时间】
        public static string GetTime()
        {
            return DateTime.Now.ToString("yyyy_MM_dd HH:mm:ss:fff");
        }
        public static string TimeStamp2Time(int timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = ((long)timeStamp * 10000000);
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime targetDt = dtStart.Add(toNow);
            return targetDt.ToString("yyyy_MM_dd HH:mm:ss:fff");
        }
        // 【获取当前系统时间】
        public static string Get_this_time_without_ms()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        // 【获取当前年月日】
        public static string Get_this_day()
        {
            return DateTime.Now.ToString("yyyy_MM_dd");
        }

        public static string Get_next_day(int _day)
        {
            return DateTime.Now.AddDays(_day).ToString("yyyy_MM_dd");
        }

        // 获取当前时间戳 - 单位s
        public static string GetTimeStamp()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            DateTime nowTime = DateTime.Now;
            long unixTime = (long)Math.Round((nowTime - startTime).TotalSeconds, MidpointRounding.AwayFromZero);
            return unixTime.ToString();
        }

        // 获取当前时间戳 - ms
        public static string Get_unixtimestamp_ms()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            DateTime nowTime = DateTime.Now;
            long unixTime = (long)Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero);
            return unixTime.ToString();
        }

        public static string Get_step_time_ms_string(DateTime _start_time)
        {
            DateTime _end_time = DateTime.Now;
            long _step_time_ms = (long)Math.Round((_end_time - _start_time).TotalMilliseconds, MidpointRounding.AwayFromZero);
            return _step_time_ms.ToString();
        }

        public static long Get_step_time_ms_long(DateTime _start_time)
        {
            DateTime _end_time = DateTime.Now;
            long _step_time_ms = (long)Math.Round((_end_time - _start_time).TotalMilliseconds, MidpointRounding.AwayFromZero);
            return _step_time_ms;
        }
    }
}
