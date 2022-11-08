using System.Collections.Generic;
using System.Linq;

namespace LinqPractice
{
    /// <summary>
    /// a Nested Dictionary contains data from StockDB.dbo.交易所產業分類代號表
    /// </summary>
    public class NestedDictionary
    {
        private static NestedDictionary NestedDictionaryInstance;
        public Dictionary<string, Dictionary<string, List<交易所產業分類代號表>>> MarketToIndustry { get; private set; }
        
        private NestedDictionary()
        {
            MarketToIndustry = new Dictionary<string, Dictionary<string, List<交易所產業分類代號表>>>();
            StockDBEntities db = new StockDBEntities();
            var Results = from row in db.交易所產業分類代號表 select row;
            foreach (var Result in Results)
            {
                if (MarketToIndustry.TryGetValue(Result.市場別名稱, out Dictionary<string, List<交易所產業分類代號表>> IndustryToData))
                {
                    if (IndustryToData.TryGetValue(Result.名稱, out List<交易所產業分類代號表> data))
                    {
                        data.Add(Result);
                    }
                    else
                    {
                        IndustryToData.Add(Result.名稱, new List<交易所產業分類代號表>());
                    }
                }
                else
                {
                    MarketToIndustry.Add(Result.市場別名稱, new Dictionary<string, List<交易所產業分類代號表>>());
                }
            }
        }

        public static  NestedDictionary Create()
        {
            if (NestedDictionaryInstance is null)
            {
                NestedDictionaryInstance = new NestedDictionary();
            }
            return NestedDictionaryInstance;
        }

        public List<string> GetMarkets()
        {
            List<string> Markets = new List<string>();
            foreach (KeyValuePair<string, Dictionary<string, List<交易所產業分類代號表>>> pair in MarketToIndustry)
            {
                Markets.Add(pair.Key);
            }
            return Markets;
        }

        public List<string> GetIndustries()
        {
            return new List<string>();
        }
    }
}
