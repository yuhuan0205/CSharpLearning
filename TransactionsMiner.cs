using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// give transactions and querys, then output results for rendering.
    /// </summary>
    public class TransactionsMiner
    {
        /// <summary>
        /// sum buys, sells, secBrokers, and averge the prices out by stockId from selected transactions.
        /// </summary>
        /// <param name="querys">unique querys from QueryParser</param>
        /// <returns>a Tuple contains a List of Results and a List of selected Transactions</returns>
        public static Tuple<List<Result>, List<Transaction>> GetResults(HashSet<string> querys)
        {
            List<Transaction> selectedTransactions = new List<Transaction>();
            List<Result> results = new List<Result>();
            //ensure each SecBroker is unique.
            HashSet<string> SecBrokerCnt = new HashSet<string>();

            Dictionary<string, List<Transaction>> stockIdToTransactions = CsvDataBase.StockIdToTrascations;
            foreach (string query in querys)
            {
                Result result = new Result();
                result.StockId = query;
                foreach (Transaction transaction in stockIdToTransactions[query])
                {
                    result.BuyTotal += transaction.BuyQty;
                    result.SellTotal += transaction.SellQty;
                    //加權平均
                    result.AvgPrice += (transaction.Price * transaction.BuyQty) +
                        (transaction.Price * transaction.SellQty);
                    result.StockName = transaction.StockName;
                    SecBrokerCnt.Add(transaction.SecBrokerId);
                    selectedTransactions.Add(transaction);
                }

                result.BuySellOver = result.BuyTotal - result.SellTotal;
                result.SecBrokerCnt = SecBrokerCnt.Count;
                if ((result.BuyTotal + result.SellTotal) == 0)
                {
                    result.AvgPrice = 0;
                }
                else
                {
                    result.AvgPrice = result.AvgPrice / (result.BuyTotal + result.SellTotal);
                }
                results.Add(result);
                SecBrokerCnt.Clear();
            }
            Tuple<List<Result>, List<Transaction>> output = new Tuple<List<Result>, List<Transaction>>(results, selectedTransactions);
            return output;
        }
    }
}