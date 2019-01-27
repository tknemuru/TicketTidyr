using System.Collections.Generic;
using System.Linq;
using System;
using CsvHelper;
using System.IO;
using System.Text;

namespace TicketTidyr.Helpers
{
    /// <summary>
    /// TicketTidyr向けにカスタマイズしたCSV補助機能を提供します。
    /// </summary>
    public static class CustomCsvHelper
    {
        /// <summary>
        /// エンコードの初期値
        /// UTF-8, Shift_JIS
        /// </summary>
        private const string DefaultEncoding = "Shift_JIS";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static CustomCsvHelper()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// CSVファイルを読み込み、Dictionaryのリストに格納します。
        /// </summary>
        /// <returns>Dictionaryのリスト</returns>
        /// <param name="csvPath">CSVファイルのパス</param>
        /// <param name="encoding">エンコーディング</param>
        public static IEnumerable<Dictionary<string, string>> ToDictionarys(string csvPath, string encoding = null)
        {
            if (encoding == null) { encoding = DefaultEncoding; }

            var records = new List<Dictionary<string, string>>();
            using (var reader = new CsvReader(new StreamReader(csvPath, Encoding.GetEncoding(encoding))))
            {
                reader.Read();
                reader.ReadHeader();
                while (reader.Read())
                {
                    var length = reader.Context.HeaderRecord.Length;
                    var record = new Dictionary<string, string>();
                    for (int i = 0; i < length; i++)
                    {
                        record.Add(reader.Context.HeaderRecord[i], reader.GetField(i));
                    }
                    records.Add(record);
                }
            }
            return records;
        }
    }
}
