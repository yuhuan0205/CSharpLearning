using System;

namespace CsvReaderWFCodingStyleVertion
{
    /// <summary>
    /// Form1 class
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer Components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Components != null))
            {
                Components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TransactionShow = new System.Windows.Forms.DataGridView();
            this.ResultShow = new System.Windows.Forms.DataGridView();
            this.Top50Show = new System.Windows.Forms.DataGridView();
            this.Lables = new System.Windows.Forms.ComboBox();
            this.Status = new System.Windows.Forms.Label();
            this.FindFileBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.Top50Btn = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.ResponseTime = new System.Windows.Forms.RichTextBox();
            this.ReadFileBW = new System.ComponentModel.BackgroundWorker();
            this.ShowResultBW = new System.ComponentModel.BackgroundWorker();
            this.ShowTop50BW = new System.ComponentModel.BackgroundWorker();
            this.ComboBoxBW = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Top50Show)).BeginInit();
            this.SuspendLayout();
            // TransactionShow
            this.TransactionShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionShow.Location = new System.Drawing.Point(12, 81);
            this.TransactionShow.Name = "TransactionShow";
            this.TransactionShow.RowTemplate.Height = 24;
            this.TransactionShow.Size = new System.Drawing.Size(793, 254);
            this.TransactionShow.TabIndex = 0;
            // ResultShow
            this.ResultShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultShow.Location = new System.Drawing.Point(12, 341);
            this.ResultShow.Name = "ResultShow";
            this.ResultShow.RowTemplate.Height = 24;
            this.ResultShow.Size = new System.Drawing.Size(793, 249);
            this.ResultShow.TabIndex = 1;
            // Top50Show
            this.Top50Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Top50Show.Location = new System.Drawing.Point(812, 81);
            this.Top50Show.Name = "Top50Show";
            this.Top50Show.RowTemplate.Height = 24;
            this.Top50Show.Size = new System.Drawing.Size(323, 509);
            this.Top50Show.TabIndex = 2;
            // Lables
            this.Lables.FormattingEnabled = true;
            this.Lables.Location = new System.Drawing.Point(12, 55);
            this.Lables.Name = "Lables";
            this.Lables.Size = new System.Drawing.Size(617, 20);
            this.Lables.TabIndex = 3;
            // Status
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(733, 17);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(53, 12);
            this.Status.TabIndex = 5;
            this.Status.Text = "讀取狀態";
            // FindFileBtn
            this.FindFileBtn.ForeColor = System.Drawing.Color.Black;
            this.FindFileBtn.Location = new System.Drawing.Point(635, 12);
            this.FindFileBtn.Name = "FindFileBtn";
            this.FindFileBtn.Size = new System.Drawing.Size(75, 23);
            this.FindFileBtn.TabIndex = 6;
            this.FindFileBtn.Text = "讀取檔案";
            this.FindFileBtn.UseVisualStyleBackColor = true;
            this.FindFileBtn.Click += new System.EventHandler(this.FindFilePathClick);
            // SearchBtn
            this.SearchBtn.Location = new System.Drawing.Point(635, 55);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 7;
            this.SearchBtn.Text = "股票查詢";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtnClick);
            // 
            // Top50Btn
            // 
            this.Top50Btn.Location = new System.Drawing.Point(716, 55);
            this.Top50Btn.Name = "Top50Btn";
            this.Top50Btn.Size = new System.Drawing.Size(89, 23);
            this.Top50Btn.TabIndex = 8;
            this.Top50Btn.Text = "買賣超 Top50";
            this.Top50Btn.UseVisualStyleBackColor = true;
            this.Top50Btn.Click += new System.EventHandler(this.Top50BtnClick);
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(13, 12);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(616, 22);
            this.FilePath.TabIndex = 4;
            // 
            // ResponseTime
            // 
            this.ResponseTime.Location = new System.Drawing.Point(812, 6);
            this.ResponseTime.Name = "ResponseTime";
            this.ResponseTime.Size = new System.Drawing.Size(323, 69);
            this.ResponseTime.TabIndex = 10;
            this.ResponseTime.Text = "";
            // 
            // ReadFileBW
            // 
            this.ReadFileBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadFileBW_DoWork);
            this.ReadFileBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ReadFileBW_RunWorkerCompleted);
            // 
            // ShowResultBW
            // 
            this.ShowResultBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ShowResultBW_DoWork);
            this.ShowResultBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ShowResultBW_RunWorkerCompleted);
            // 
            // ShowTop50BW
            // 
            this.ShowTop50BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ShowTop50BW_DoWork);
            this.ShowTop50BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ShowTop50BW_RunWorkerCompleted);
            // 
            // ComboBoxBW
            // 
            this.ComboBoxBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ComboBoxBW_DoWork);
            this.ComboBoxBW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ComboBoxBW_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 602);
            this.Controls.Add(this.ResponseTime);
            this.Controls.Add(this.Top50Btn);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.FindFileBtn);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.Lables);
            this.Controls.Add(this.Top50Show);
            this.Controls.Add(this.ResultShow);
            this.Controls.Add(this.TransactionShow);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TransactionShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Top50Show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.DataGridView TransactionShow;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.DataGridView ResultShow;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.DataGridView Top50Show;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.ComboBox Lables;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.Label Status;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.Button FindFileBtn;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.Button SearchBtn;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.Button Top50Btn;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.TextBox FilePath;

        /// <summary>
        /// winform elements
        /// </summary>
        private System.Windows.Forms.RichTextBox ResponseTime;

        /// <summary>
        /// BackgroundWorker for read CSV file.
        /// </summary>
        private System.ComponentModel.BackgroundWorker ReadFileBW;

        /// <summary>
        /// BackgroundWorker for searching.
        /// </summary>
        private System.ComponentModel.BackgroundWorker ShowResultBW;

        /// <summary>
        /// BackgroundWorker for get top50.
        /// </summary>
        private System.ComponentModel.BackgroundWorker ShowTop50BW;

        /// <summary>
        /// BackgroundWorker for make comboBox's lables.
        /// </summary>
        private System.ComponentModel.BackgroundWorker ComboBoxBW;
    }
}