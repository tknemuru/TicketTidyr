using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketTidyr.Helpers;

namespace TicketTidyr.Tests
{
    /// <summary>
    /// DateTimeHelperに関するテスト機能を提供します。
    /// </summary>
    [TestClass]
    public class DateTimeHelperTest
    {
        /// <summary>
        /// 001:AddDaysで平日のみのときに正しく加算される。
        /// </summary>
        [TestMethod]
        public void AddDaysで平日のみのときに正しく加算される()
        {
            // 001:平平平 +2
            var expected = DateTime.Parse("2019-01-09");
            var actual = DateTime.Parse("2019-01-07").AddWeekDays(2);
            Assert.AreEqual(expected, actual);

            // 002:平平平 +1.5
            expected = DateTime.Parse("2019-01-08 12:00:00");
            actual = DateTime.Parse("2019-01-07").AddWeekDays(1.5);
            Assert.AreEqual(expected, actual);

            // 003:平平平 +0.5
            expected = DateTime.Parse("2019-01-07 12:00:00");
            actual = DateTime.Parse("2019-01-07").AddWeekDays(0.5);
            Assert.AreEqual(expected, actual);

            // 004:平平平 +0.0
            expected = DateTime.Parse("2019-01-07");
            actual = DateTime.Parse("2019-01-07").AddWeekDays(0);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 002:AddDaysで休日が存在するときに正しく加算される。
        /// </summary>
        [TestMethod]
        public void AddDaysで休日が存在するときに正しく加算される()
        {
            // 001:平休休平平 +2
            var expected = DateTime.Parse("2019-01-22");
            var actual = DateTime.Parse("2019-01-18").AddWeekDays(2);
            Assert.AreEqual(expected, actual);

            // 002:平休休平平 +1.5
            expected = DateTime.Parse("2019-01-21 12:00:00");
            actual = DateTime.Parse("2019-01-18").AddWeekDays(1.5);
            Assert.AreEqual(expected, actual);

            // 003:休休平平平 +2
            expected = DateTime.Parse("2019-01-22");
            actual = DateTime.Parse("2019-01-19").AddWeekDays(2);
            Assert.AreEqual(expected, actual);

            // 003:平平休休平 +2
            expected = DateTime.Parse("2019-01-21");
            actual = DateTime.Parse("2019-01-17").AddWeekDays(2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 003:AddDaysで祝日が存在するときに正しく加算される。
        /// </summary>
        [TestMethod]
        public void AddDaysで祝日が存在するときに正しく加算される()
        {
            // 001:平休休祝平平 +2
            var expected = DateTime.Parse("2019-01-16");
            var actual = DateTime.Parse("2019-01-11").AddWeekDays(2);
            Assert.AreEqual(expected, actual);

            // 002:平平祝平休休平平 +4
            expected = DateTime.Parse("2019-03-26");
            actual = DateTime.Parse("2019-03-19").AddWeekDays(4);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 004:AddDaysで正しく減算される。
        /// </summary>
        [TestMethod]
        public void AddDaysで正しく減算される()
        {
            // 001:平休休祝平平 -2
            var expected = DateTime.Parse("2019-01-11");
            var actual = DateTime.Parse("2019-01-16").AddWeekDays(-2);
            Assert.AreEqual(expected, actual);

            // 002:平平祝平休休平平 -4
            expected = DateTime.Parse("2019-03-19");
            actual = DateTime.Parse("2019-03-26").AddWeekDays(-4);
            Assert.AreEqual(expected, actual);
        }
    }
}
