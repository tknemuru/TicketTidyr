using System.Collections.Generic;
using System.Linq;
using System;
using TicketTidyr.Models;
using Newtonsoft.Json;
using TicketTidyr.Helpers;

namespace TicketTidyr.Tools.HolidayGenerator
{
    /// <summary>
    /// Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 出力パス
        /// </summary>
        private const string OutputPath = "../TicketTidyr/Resources/holidays.json";

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            var holidays = ApiManager.Get();
            Write(holidays);
        }

        /// <summary>
        /// 祝日リストをファイルに書き込みます。
        /// </summary>
        /// <param name="holidays">祝日リスト</param>
        private static void Write(IEnumerable<EventItem> holidays)
        {
            var json = JsonConvert.SerializeObject(holidays, Formatting.Indented);
            FileHelper.Write(json, OutputPath, false);
        }
    }
}
