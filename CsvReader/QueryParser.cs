using System.Collections.Generic;

namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// parsing query form comboBox to valid and unique query.
    /// </summary>
    public class QueryParser
    {
        /// <summary>
        /// Spliter for spliting querys.
        /// </summary>
        private readonly char Spliter;

        /// <summary>
        /// Singleton 模式
        /// </summary>
        private static QueryParser Parser;

        /// <summary>
        /// a dictionary, key is comboBox's lable, value is StockId. 
        /// </summary>
        private static Dictionary<string, string> LableToStockID;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="lableToStockID">a dictionary, key is comboBox's lable, value is StockId.</param>
        private QueryParser(Dictionary<string, string> lableToStockID)
        {
            LableToStockID = lableToStockID;
            Spliter = ',';
        }

        /// <summary>
        /// create only one QueryParser object.
        /// </summary>
        /// <param name="lableToStockID">a dictionary, key is comboBox's lable, value is StockId.</param>
        /// <returns></returns>
        public static QueryParser CreateQueryParser(Dictionary<string, string> lableToStockID)
        {
            if (Parser == null)
            {
                Parser = new QueryParser(lableToStockID);
            }
            return Parser;
        }

        /// <summary>
        /// Parsing querys to valid a HashSet of single parsed query.
        /// </summary>
        /// <param name="query">unparsed querys.</param>
        /// <returns>a HashSet of parsed querys</returns>
        public HashSet<string> Parsing(string query)
        {
            string[] querys;
            //case 1 using comboBox, case 2 type stockID to search.
            if (LableToStockID.TryGetValue(query, out string id))
            {
                querys = LableToStockID[query].Split(Spliter);
            }
            else
            {
                querys = query.Split(Spliter);
            }
            return new HashSet<string>(querys);
        }
    }
}