using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;
using TicketTidyr.Helpers;

namespace TicketTidyr.Tests.Helpers
{
    /// <summary>
    /// CustomCsvHelperに関するテスト機能を提供します。
    /// </summary>
    [TestClass]
    public class CustomCsvHelperTest
    {
        /// <summary>
        /// 001:ToDictionarysで正常にDictionaryのリストが作成できる。
        /// </summary>
        [TestMethod]
        public void ToDictionarysで正常にDictionaryのリストが作成できる()
        {
            // 001:正常系
            var expecteds = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    {
                        "い",
                        "1"
                    },
                    {
                        "ろ",
                        "R"
                    },
                    {
                        "は",
                        "に"
                    }
                },
                new Dictionary<string, string>()
                {
                    {
                        "い",
                        "2"
                    },
                    {
                        "ろ",
                        "S"
                    },
                    {
                        "は",
                        "ほ"
                    }
                }
            };
            var actuals = CustomCsvHelper.ToDictionarys(UnitTestHelper.GetResourcePath(1, 1, ResourceType.In, "CustomCsvHelper", "csv"), "UTF-8").ToList();
            Assert.AreEqual(expecteds.Count(), actuals.Count());
            for (var i = 0; i < expecteds.Count(); i++)
            {
                CollectionAssert.AreEqual(expecteds[i], actuals[i]);
            }
        }
    }
}
