using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.IO;

/// <summary>
/// winform entry point
/// </summary>
namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// Form object.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Form constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitMembers();
        }

        /// <summary>
        /// a object to record time spending.
        /// </summary>
        private Stopwatch TimeRecorder;

        /// <summary>
        /// a object to format time display.
        /// </summary>
        private TimeSpan Time;

        /// <summary>
        /// a object to create dialog for user to find file path.
        /// </summary>
        private OpenFileDialog Dialog;

        /// <summary>
        /// a object to read, store, and select data.
        /// </summary>
        private CsvDataBase DataBase;

        /// <summary>
        /// a object to parse querys.
        /// </summary>
        private QueryParser Parser;

        /// <summary>
        /// a object to sum selected transactions up.
        /// </summary>
        private TransactionsMiner Miner;

        /// <summary>
        /// a function to init members.
        /// </summary>
        private void InitMembers()
        {
            TimeRecorder = new Stopwatch();
            Time = new TimeSpan();
            Miner = new TransactionsMiner();
            Dialog = new OpenFileDialog
            {
                //Dialog setting
                Title = "請選擇檔案",
                InitialDirectory = "c:\\Users\\user1\\Desktop\\C_Sharp練習",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true
            };
        }

        /// <summary>
        /// click button open a dialog, then choose a file.
        /// Read csv file into CsvDataBase.
        /// render data to the DataGridView and ComboBox.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event's param</param>
        private void FindFilePathClick(object sender, EventArgs e)
        {
            //open a dialog
            DialogResult dialogResult = Dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                TimeRecorder.Start();
                FilePath.Text = Dialog.FileName;
                Status.Text = "讀取中";
                Stream fileStream = Dialog.OpenFile();
                DataBase = new CsvDataBase(fileStream);
                if (DataBase.IsValid)
                {
                    //use backgroundWorker to read CSV file and rendering dataGridView
                    ReadFileBW.RunWorkerAsync();                    
                }
                else
                {
                    MessageBox.Show("資料格式錯誤！", "資料格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// click button, get a query from comboBox's selection or querys user typed.
        /// get results from dataBase, and rendering.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event's param</param>
        private void SearchBtnClick(object sender, EventArgs e)
        {
            TimeRecorder.Restart();
            if (DataBase != null)
            {
                //parsing query
                Parser = QueryParser.CreateQueryParser(DataBase.LableToStockID);
                HashSet<string> querys = Parser.Parsing(Lables.Text);
                ShowResultBW.RunWorkerAsync(querys);
            }
        }

        /// <summary>
        /// click button, get a query from comboBox's selection or querys user typed.
        /// get Top50results from dataBase, and rendering.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event's param</param>
        private void Top50BtnClick(object sender, EventArgs e)
        {
            TimeRecorder.Restart();
            if (DataBase != null)
            {
                //parsing query
                Parser = QueryParser.CreateQueryParser(DataBase.LableToStockID);
                HashSet<string> querys = Parser.Parsing(Lables.Text);
                ShowTop50BW.RunWorkerAsync(querys);
            }
        }

        /// <summary>
        /// a backgroundWorker read CSV file and recording process time.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event, it can get Arguments and send results</param>
        private void ReadFileBW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = DataBase.ReadFileStream();
        }

        /// <summary>
        /// when ReadFileBW's task done, this function will be called
        /// it is for rendering transactions and spending time.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event, it can get results</param>
        private void ReadFileBW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //rendering
            TransactionShow.DataSource = (List<Transaction>)e.Result;
            Status.Text = "讀取完成";

            //rendering time
            TimeRecorder.Stop();
            TimeSpan Time = TimeSpan.FromMilliseconds(TimeRecorder.ElapsedMilliseconds);
            ResponseTime.AppendText(
                                    string.Format("查詢時間:{0:D2}:{1:D2}:{2:D1}:{3:D2}",
                                    Time.Hours, Time.Minutes, Time.Seconds, Time.Milliseconds) +
                                    Environment.NewLine);
            //make comboBox's lables.
            ComboBoxBW.RunWorkerAsync();
        }

        /// <summary>
        /// a backgroundWorker to make comboBox's Lables.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event, it can get Arguments and send results</param>
        private void ComboBoxBW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            TimeRecorder.Restart();
            e.Result = DataBase.GetLables();
        }

        /// <summary>
        /// when ComboBoxBW's task done, this function will be called
        /// it is for rendering comboBox's Lables and spending time.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event, it can get results</param>
        private void ComboBoxBW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //rendering
            Lables.DataSource = (List<string>)e.Result;
            //rendering time
            TimeRecorder.Stop();
            Time = TimeSpan.FromMilliseconds(TimeRecorder.ElapsedMilliseconds);
            ResponseTime.AppendText(
                                    string.Format("ComboBox產生時間:{0:D2}:{1:D2}:{2:D1}:{3:D2}",
                                    Time.Hours, Time.Minutes, Time.Seconds, Time.Milliseconds) +
                                    Environment.NewLine);
        }

        /// <summary>
        /// a backgroundWorker to sum the selected transactions which user queryed.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event, it can get Arguments and send results</param>
        private void ShowResultBW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = TransactionsMiner.GetResults((HashSet<string>)e.Argument);
        }

        /// <summary>
        /// when ShowResultBW's task done, this function will be called
        /// it is for rendering ShowResults, selected Transactions and spending time.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event, it can get results</param>
        private void ShowResultBW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //this it a Tuple contains Results and selected Transactions. 
            Tuple<List<Result>, List<Transaction>> tupleOfResults =
                (Tuple<List<Result>, List<Transaction>>)e.Result;

            //rendering
            ResultShow.DataSource = tupleOfResults.Item1;
            TransactionShow.DataSource = tupleOfResults.Item2;
            //rendering time
            TimeRecorder.Stop();
            Time = TimeSpan.FromMilliseconds(TimeRecorder.ElapsedMilliseconds);
            ResponseTime.AppendText(
                                        string.Format("查詢時間:{0:D2}:{1:D2}:{2:D1}:{3:D2}",
                                        Time.Hours, Time.Minutes, Time.Seconds, Time.Milliseconds) +
                                        Environment.NewLine);
        }

        /// <summary>
        /// a backgroundWorker to get top 50 BuySellOver SecBrokers from each stock which user queryed.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event, it can get Arguments and send results</param>
        private void ShowTop50BW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = Top50Miner.GetTop50((HashSet<string>)e.Argument);
        }

        /// <summary>
        /// when ShowTop50BW's task done, this function will be called
        /// it is for rendering ShowTop50s and spending time.
        /// </summary>
        /// <param name="sender">button's param</param>
        /// <param name="e">event, it can get results</param>
        private void ShowTop50BW_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Top50Show.DataSource = (List<Top50>)e.Result;
            //rendering time.
            TimeRecorder.Stop();
            Time = TimeSpan.FromMilliseconds(TimeRecorder.ElapsedMilliseconds);
            ResponseTime.AppendText(
                                        string.Format("Top50產生時間:{0:D2}:{1:D2}:{2:D1}:{3:D2}",
                                        Time.Hours, Time.Minutes, Time.Seconds, Time.Milliseconds) +
                                        Environment.NewLine);
        }
    }
}