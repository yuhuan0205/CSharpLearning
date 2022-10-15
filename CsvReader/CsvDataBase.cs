using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// store every transaction in Csv file, comboBox's Lables, and other useful information.
    /// </summary>
    public class CsvDataBase
    {
        /// <summary>
        /// a object store raw data.
        /// </summary>
        private readonly Stream FileStream;

        /// <summary>
        /// a object to read Stream object.
        /// </summary>
        private readonly StreamReader Reader;

        /// <summary>
        /// a dictionary, key is comboBox's lable, value is StockId. 
        /// </summary>
        public Dictionary<string, string> LableToStockID { get; set; }

        /// <summary>
        /// a dictionary, key is StockId, value is Transactions for this stockId.
        /// </summary>
        public static Dictionary<string, List<Transaction>> StockIdToTrascations { get; set; }

        /// <summary>
        /// a bool to check is the csv file format vaild?
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fileStream">raw data of csv from file stream</param>
        public CsvDataBase(Stream fileStream)
        {
            FileStream = fileStream;
            Reader = new StreamReader(fileStream);
            IsValid = Validate();
            LableToStockID = new Dictionary<string, string>();
            StockIdToTrascations = new Dictionary<string, List<Transaction>>();
        }

        /// <summary>
        /// read and store Transactions from Csv fileStream.
        /// return Transactions to winform.
        /// </summary>
        /// <returns>All Transactions.</returns>
        public List<Transaction> ReadFileStream()
        {
            string[] transactionString;
            string line;
            char spliter = ',';
            int stockId = TableInfo.STOCK_ID;
            while ((line = Reader.ReadLine()) != null)
            {
                transactionString = line.Split(spliter);

                if (StockIdToTrascations.TryGetValue(transactionString[stockId], out List<Transaction> sortedTrascations))
                {
                    sortedTrascations.Add(new Transaction(transactionString));
                }
                else
                {
                    sortedTrascations = new List<Transaction>
                    {
                        new Transaction(transactionString)
                    };
                    StockIdToTrascations.Add(transactionString[stockId], sortedTrascations);
                }
            }
            Reader.Close();

            List<Transaction> Transactions = new List<Transaction>(StockIdToTrascations.Count);
            foreach (KeyValuePair<string, List<Transaction>> stockIdToTrascation in StockIdToTrascations)
            {
                Transactions.AddRange(stockIdToTrascation.Value);
            }
            return Transactions;
        }

        /// <summary>
        /// validate the file's format.
        /// </summary>
        /// <returns>csv data format is valid or not.</returns>
        private bool Validate()
        {
            if ((Reader.ReadLine().Split(',')).Length == TableInfo.DOCUMENT_COLUMN_LENTH)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return ComboBoxLables to winform.
        /// </summary>
        /// <returns>a List contains all unique string $"{stockId} - {stickName}"</returns>
        public List<string> GetLables()
        {
            StringBuilder allBuilder = new StringBuilder(string.Empty);
            List<string> comboBoxLables = new List<string>();
            comboBoxLables.Add(TableInfo.ALL);
            int firstIndex = 0;
            foreach (KeyValuePair<string, List<Transaction>> transactions in StockIdToTrascations)
            {
                string lable = $"{transactions.Value[firstIndex].StockId} - {transactions.Value[firstIndex].StockName}";
                LableToStockID.Add(lable, transactions.Value[firstIndex].StockId);
                allBuilder.Append($"{transactions.Value[firstIndex].StockId},");
            }
            //remove last empty string.
            string all = allBuilder.ToString().Remove(allBuilder.Length - 1);
            comboBoxLables.AddRange(LableToStockID.Keys);
            LableToStockID.Add(TableInfo.ALL, all);
            return comboBoxLables;
        }
    }
}