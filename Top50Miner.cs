using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// a object to sum selected transacions up to Top50 object. 
    /// </summary>
    public static class Top50Miner
    {
        /// <summary>
        /// Get top 50 BuySellOver SecBrokers from each stock which user queryed.
        /// </summary>
        /// <param name="querys">unique querys from QueryParser</param>
        /// <returns>return a list of Top50</returns>
        public static List<Top50> GetTop50(HashSet<string> querys)
        {
            // a list will return.
            List<Top50> top50s = new List<Top50>();
            foreach (string query in querys)
            {
                int showingIndex = 0;
                Dictionary<string, Top50> secBrokerIdToBuySellOver = new Dictionary<string, Top50>();
                foreach (Transaction transaction in CsvDataBase.StockIdToTrascations[query])
                {
                    if (secBrokerIdToBuySellOver.TryGetValue(transaction.SecBrokerId, out Top50 top50))
                    {
                        top50.BuySellOver += transaction.BuyQty - transaction.SellQty;
                    }
                    else
                    {
                        secBrokerIdToBuySellOver.Add(transaction.SecBrokerId, new Top50(transaction, showingIndex));
                        showingIndex += 1;
                    }
                }

                List<Top50> sortedTop50s = new List<Top50>();
                foreach (KeyValuePair<string, Top50> top50ItemForEachSecBroker in secBrokerIdToBuySellOver)
                {
                    sortedTop50s.Add(top50ItemForEachSecBroker.Value);
                }

                // sort
                sortedTop50s.Sort();

                // add top 50 items
                bool isTop = true;
                AddingTopOrLast50(top50s, isTop, sortedTop50s);

                // add last 50 items
                isTop = false;
                AddingTopOrLast50(top50s, isTop, sortedTop50s);
            }
            return top50s;
        }

        /// <summary>
        /// adding top 50 secBrokers which buy or sell more than other.
        /// </summary>
        /// <param name="top50s">the list will render.</param>
        /// <param name="isTop">get top 50 or last 50.</param>
        /// <param name="sortedTop50s">all sorted transactions. </param>
        private static void AddingTopOrLast50(List<Top50> top50s, bool isTop, List<Top50> sortedTop50s)
        {
            int sortedTop50Index = 0;
            int sortedTop50LastIndex = sortedTop50s.Count - 1;
            if (isTop)
            {
                while (sortedTop50Index < sortedTop50LastIndex)
                {
                    if (sortedTop50Index >= 50 | sortedTop50s[sortedTop50Index].BuySellOver <= 0)
                    {
                        break;
                    }
                    else
                    {
                        top50s.Add(sortedTop50s[sortedTop50Index]);
                        sortedTop50Index += 1;
                    }
                }
            }
            else
            {
                while (sortedTop50Index < sortedTop50LastIndex)
                {
                    if (sortedTop50Index >= 50 | sortedTop50s[sortedTop50LastIndex - sortedTop50Index].BuySellOver >= 0)
                    {
                        break;
                    }
                    else
                    {
                        top50s.Add(sortedTop50s[sortedTop50LastIndex - sortedTop50Index]);
                        sortedTop50Index += 1;
                    }
                }
            }
        }
    }
}