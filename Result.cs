namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// each result are sumed by transactions which have same stockId.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Id of the stock.
        /// </summary>
        public string StockId { get; set; }

        /// <summary>
        /// Name of the stock.
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// BuyQty's sum of the stock.
        /// </summary>
        public int BuyTotal { get; set; }

        /// <summary>
        /// SellQty's sum of the stock.
        /// </summary>
        public int SellTotal { get; set; }

        /// <summary>
        /// Average price of the stock.
        /// </summary>
        public decimal AvgPrice { get; set; }

        /// <summary>
        /// BuyTotal - SellTotal.
        /// </summary>
        public int BuySellOver { get; set; }

        /// <summary>
        /// How many SecBroker buy or sell this stock.
        /// </summary>
        public int SecBrokerCnt { get; set; }

        /// <summary>
        /// constructor.
        /// </summary>
        public Result()
        {
            StockId = string.Empty;
            StockName = string.Empty;
            BuySellOver = 0;
            SellTotal = 0;
            AvgPrice = 0;
            BuySellOver = 0;
            SecBrokerCnt = 0;
        }
    }
}