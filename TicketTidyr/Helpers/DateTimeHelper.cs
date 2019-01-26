using System.Collections.Generic;
using System.Linq;
using System;
using TicketTidyr.Helpers;
using TicketTidyr.Models;
using Newtonsoft.Json;

namespace TicketTidyr.Helpers
{
    /// <summary>
    /// 日付に関する補助機能を提供します。
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 祝日リストファイルパス
        /// </summary>
        private const string HolidaysFilePath = "./Resources/holidays.json";

        /// <summary>
        /// 祝日リスト
        /// </summary>
        /// <value>The holidays.</value>
        private static readonly IEnumerable<EventItem> Holidays = BuildHolidays();

        /// <summary>
        /// 日付の加算処理を行います。休日・祝日はスキップします。
        /// </summary>
        /// <returns>The days.</returns>
        /// <param name="date">加算対象の日付</param>
        /// <param name="value">加算値</param>
        public static DateTime AddWeekDays(this DateTime date, double value)
        {
            if (value < 0)
            {
                return date.SubWeekDays(value);
            }

            DateTime addedDate = date;
            while (value > 0)
            {
                var add = Math.Min(1.0d, value);
                addedDate = addedDate.AddDays(add);
                if (!IsHoliday(addedDate))
                {
                    value--;
                }
            }
            return addedDate;
        }

        /// <summary>
        /// 日付の減算処理を行います。休日・祝日はスキップします。
        /// </summary>
        /// <returns>The week days.</returns>
        /// <param name="date">減算対象の日付</param>
        /// <param name="value">減算値</param>
        private static DateTime SubWeekDays(this DateTime date, double value)
        {
            DateTime subedDate = date;
            while (value < 0)
            {
                var add = Math.Max(-1.0d, value);
                subedDate = subedDate.AddDays(add);
                if (!IsHoliday(subedDate))
                {
                    value++;
                }
            }
            return subedDate;
        }

        /// <summary>
        /// 祝日リストを組み立てます。
        /// </summary>
        /// <returns>The holidays.</returns>
        private static IEnumerable<EventItem> BuildHolidays()
        {
            var json = FileHelper.ReadAllTextLines(HolidaysFilePath);
            return JsonConvert.DeserializeObject<IEnumerable<EventItem>>(json);
        }

        /// <summary>
        /// 対象の日付が休日かどうかを判定します。
        /// </summary>
        /// <returns>休日かどうか</returns>
        /// <param name="date">日付</param>
        private static bool IsHoliday(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ||
                   Holidays.Any(h => h.Date.Date == date.Date));
        }
    }
}
