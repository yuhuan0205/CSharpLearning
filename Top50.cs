using System;

namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// a object store the sum of buys and sells by the secBroker.
    /// </summary>
    public class Top50 : IComparable<Top50>
    {
        /// <summary>
        /// Name of stock.
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// Name of secBroker.
        /// </summary>
        public string SecBrokerName { get; set; }

        /// <summary>
        /// buys - sells.
        /// </summary>
        public int BuySellOver { get; set; }

        /// <summary>
        /// a index to recognize which top50 object show early.
        /// </summary>
        private int SortIndex;

        /// <summary>
        /// constructor.
        /// </summary>
        /// <param name="transaction">a Transaction</param>
        /// <param name="index">a index which represent the priority to sort.</param>
        public Top50(Transaction transaction, int index)
        {
            StockName = transaction.StockName;
            SecBrokerName = transaction.SecBrokerName;
            BuySellOver = Convert.ToInt32(transaction.BuyQty) - Convert.ToInt32(transaction.SellQty);
            SortIndex = index;
        }

        /// <summary>
        /// to compare this to other object by BuySellOver, if they equal, then compare their SortIndex.
        /// </summary>
        /// <param name="other">a top50 object will compare to this object.</param>
        /// <returns></returns>
        public int CompareTo(Top50 other)
        {
            int result = other.BuySellOver.CompareTo(this.BuySellOver);
            // they are equal.
            if (result == 0)
            {
                if (this.BuySellOver >= 0)
                {
                    result = this.SortIndex.CompareTo(other.SortIndex);
                }
                else
                {
                    result = other.SortIndex.CompareTo(this.SortIndex);
                }
            }
            return result;
        }
    }
}