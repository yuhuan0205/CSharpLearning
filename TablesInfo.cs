namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// this class store some static values about columns.
    /// </summary>
    public static class TableInfo
    {
        /// <summary>
        /// a valid csv should has 8 columns.
        /// </summary>
        public const int DOCUMENT_COLUMN_LENTH = 8;

        /// <summary>
        /// string All.
        /// </summary>
        public const string ALL = "All";

        /// <summary>
        /// transaction column 0
        /// </summary>
        public const int DEAL_DATE = 0;

        /// <summary>
        /// transaction column 1
        /// </summary>
        public const int STOCK_ID = 1;

        /// <summary>
        /// transaction column 2
        /// </summary>
        public const int STOCK_NAME = 2;

        /// <summary>
        /// transaction column 3
        /// </summary>
        public const int SEC_BROKER_ID = 3;

        /// <summary>
        /// transaction column 4
        /// </summary>
        public const int SEC_BROKER_NAME = 4;

        /// <summary>
        /// transaction column 5
        /// </summary>
        public const int PRICE = 5;

        /// <summary>
        /// transaction column 6
        /// </summary>
        public const int BUT_QTY = 6;

        /// <summary>
        /// transaction column 7
        /// </summary>
        public const int SELL_QTY = 7;

        /// <summary>
        /// column's name to column's index.
        /// </summary>
        //public enum TransactionField : int
        //{
        //    DealDate = 0,
        //    StockId = 1,
        //    StockName = 2,
        //    SecBrokerId = 3,
        //    SecBrokerName = 4,
        //    Price = 5,
        //    BuyQty = 6,
        //    SellQty = 7
        //}
    }
}