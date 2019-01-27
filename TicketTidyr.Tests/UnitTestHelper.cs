// using System.Collections.Generic;
// using System.Linq;
using System;
namespace TicketTidyr.Tests
{
    /// <summary>
    /// ユニットテストに関する補助機能を提供します。
    /// </summary>
    public static class UnitTestHelper
    {
        /// <summary>
        /// リソースのパスを取得します。
        /// </summary>
        /// <returns>リソースパス</returns>
        /// <param name="index">インデックス</param>
        /// <param name="childIndex">子インデックス</param>
        /// <param name="type">リソース種別</param>
        /// <param name="targetName">テスト対象のクラス名</param>
        /// <param name="extension">拡張子</param>
        public static string GetResourcePath(int index, int childIndex, ResourceType type, string targetName, string extension = "txt")
        {
            return $"../../../Resources/{targetName}/{index.ToString().PadLeft(3, '0')}-{childIndex.ToString().PadLeft(3, '0')}-{type.ToString().ToLower()}.{extension}";
        }
    }
}
