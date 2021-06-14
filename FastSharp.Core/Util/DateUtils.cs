using System;
using System.Collections.Generic;
using System.Text;

namespace FastSharp.Core.Util
{
    /// <summary>
    /// 日期工具类
    /// </summary>
    public class DateUtils
    {
        public static readonly string DATE_FORMAT = "yyyy-MM-dd";

        public static readonly string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDate()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTime GetDate(DateTime date, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond);
        }

        /// <summary>
        /// 根据特定格式格式化日期
        /// </summary>
        /// <param name="date"> 被格式化的日期 </param>
        /// <param name="format"> 日期格式 </param>
        /// <returns></returns>
        public static string Format(DateTime date, String format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return date.ToString();
            }
            return date.ToString(format);
        }

        /// <summary>
        /// 获取日期格式化字符
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime date)
        {
            return Format(date, DATE_FORMAT);
        }

        /// <summary>
        /// 获取日期时间格式化字符
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDateTime(DateTime date)
        {
            return Format(date, DATE_FORMAT);
        }

        /// <summary>
        /// 将特定格式的日期转换为DateTime对象
        /// </summary>
        /// <param name="dateStr"> dateStr 特定格式的日期 </param>
        /// <param name="format"> 格式，例如yyyy-MM-dd </param>
        /// <returns></returns>
        public static DateTime Parse(string dateStr, string format)
        {
            return DateTime.ParseExact(dateStr, format, System.Globalization.CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 解析日期格式化字符
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static DateTime ParseDate(string dateStr)
        {
            return Parse(dateStr, DATE_FORMAT);
        }

        /// <summary>
        /// 解析日期时间格式化字符
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static DateTime ParseDateTime(string dateStr)
        {
            return Parse(dateStr, DATETIME_FORMAT);
        }

        /// <summary>
        /// 时间增加年份
        /// </summary>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static DateTime AddYears(DateTime date, int amount)
        {
            return date.AddYears(amount);
        }

        /// <summary>
        /// 时间增加月份
        /// </summary>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static DateTime AddMonths(DateTime date, int amount)
        {
            return date.AddMonths(amount);
        }

        /// <summary>
        /// 时间增加天数
        /// </summary>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static DateTime AddDays(DateTime date, int amount)
        {
            return date.AddDays(amount);
        }

        /// <summary>
        /// 时间增加小时
        /// </summary>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static DateTime AddHours(DateTime date, int amount)
        {
            return date.AddHours(amount);
        }

        /// <summary>
        /// 时间增加分钟
        /// </summary>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static DateTime AddMinutes(DateTime date, int amount)
        {
            return date.AddMinutes(amount);
        }

        /// <summary>
        /// 时间增加秒
        /// </summary>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static DateTime AddSeconds(DateTime date, int amount)
        {
            return date.AddSeconds(amount);
        }

        /// <summary>
        /// 时间增加毫秒
        /// </summary>
        /// <param name="date"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static DateTime AddMilliseconds(DateTime date, int amount)
        {
            return date.AddMilliseconds(amount);
        }

        /// <summary>
        /// 获取季度
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetQuarter(DateTime date)
        {
            return (date.Month - 1) / 3 + 1;
        }

        /// <summary>
        ///  获取日期时间开始
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeBegin(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        /// <summary>
        /// 获取日期时间结束
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeEnd(DateTime date)
        {
            return AddMilliseconds(AddDays(GetDateTimeBegin(date), 1), -1);
        }

        /// <summary>
        /// 获取日期月份开始
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDateMonthBegin(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// 获取日期月份结束
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDateMonthEnd(DateTime date)
        {
            return AddMilliseconds(AddMonths(GetDateMonthBegin(date), 1), -1);
        }

        /// <summary>
        /// 获取日期年份开始
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDateYearBegin(DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        /// <summary>
        /// 获取日期年份结束
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDateYearEnd(DateTime date)
        {
            return AddMilliseconds(AddYears(GetDateYearBegin(date), 1), -1);
        }

        /// <summary>
        /// 获取时间月份区间
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="roundUp"></param>
        /// <returns></returns>
        public static List<KeyValuePair<DateTime, DateTime>> GetDateMonthRange(DateTime beginDate, DateTime endDate, bool? roundUp)
        {
            DateTime startDate = beginDate;
            List<KeyValuePair<DateTime, DateTime>> array = new List<KeyValuePair<DateTime, DateTime>>();
            do
            {
                //计算本次结束时间
                DateTime date = AddSeconds(AddMonths(startDate, 1), -1);
                //判断结束时间是否在范围内
                if (date.Ticks <= endDate.Ticks)
                {
                    array.Add(new KeyValuePair<DateTime, DateTime>(startDate, date));
                }
                else
                {
                    //判断超出时间是否舍入
                    if (date.Ticks > endDate.Ticks && (roundUp == null || !roundUp.Value))
                    {
                        date = endDate;
                    }
                    array.Add(new KeyValuePair<DateTime, DateTime>(startDate, date));
                }
                //计算下次时间(将之前减去都1秒加回来)
                startDate = AddSeconds(date, 1);

            } while (startDate.Ticks < endDate.Ticks);

            return array;
        }
    }
}
