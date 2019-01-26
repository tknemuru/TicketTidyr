// // using System.Collections.Generic;
// // using System.Linq;
using System;
namespace TicketTidyr.Models
{
    /// <summary>
    /// Event item.
    /// </summary>
    public class EventItem
    {
        /// <summary>
        /// イベント名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 日付
        /// </summary>
        public DateTime Date { get; set; }
    }
}
