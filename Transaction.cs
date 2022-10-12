using System;

namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// a object store each transaction, and binding to dataViewGrid.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// the Date which deal is maked.
        /// </summary>
        public string DealDate { get; set; }

        /// <summary>
        /// Id of the stock.
        /// </summary>
        public string StockId { get; set; }

        /// <summary>
        /// Name of the stock.
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// Id of the SecBroker.
        /// </summary>
        public string SecBrokerId { get; set; }

        /// <summary>
        /// Name of the SecBroker.
        /// </summary>
        public string SecBrokerName { get; set; }

        /// <summary>
        /// The deal price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// How many stock the secBroker buy ?
        /// </summary>
        public int BuyQty { get; set; }

        /// <summary>
        /// How many stock the secBroker sell ?
        /// </summary>
        public int SellQty { get; set; }
        
        /// <summary>
        /// Transaction constructor.
        /// </summary>
        /// <param name="row">a row data from a line of csv data.</param>
        public Transaction(string[] row)
        {
            DealDate = row[TableInfo.DEAL_DATE];
            StockId = row[TableInfo.STOCK_ID];
            StockName = row[TableInfo.STOCK_NAME];
            SecBrokerId = row[TableInfo.SEC_BROKER_ID];
            SecBrokerName = row[TableInfo.SEC_BROKER_NAME];
            Price = Convert.ToDecimal(row[TableInfo.PRICE]);
            BuyQty = Convert.ToInt16(row[TableInfo.BUT_QTY]);
            SellQty = Convert.ToInt16(row[TableInfo.SELL_QTY]);
        }
    }
}
