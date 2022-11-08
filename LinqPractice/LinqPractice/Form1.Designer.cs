
namespace LinqPractice
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.FunctionTab = new System.Windows.Forms.TabControl();
            this.FunctionTab1 = new System.Windows.Forms.TabPage();
            this.Industries = new System.Windows.Forms.ComboBox();
            this.Markets = new System.Windows.Forms.ComboBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FunctionTab2 = new System.Windows.Forms.TabPage();
            this.FunctionTab3 = new System.Windows.Forms.TabPage();
            this.FunctionTab4 = new System.Windows.Forms.TabPage();
            this.DataViewTab = new System.Windows.Forms.TabControl();
            this.DataViewTab1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DataViewTab2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DataViewTab3 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ResponseTime = new System.Windows.Forms.RichTextBox();
            this.FunctionTab.SuspendLayout();
            this.FunctionTab1.SuspendLayout();
            this.DataViewTab.SuspendLayout();
            this.DataViewTab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.DataViewTab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.DataViewTab3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // FunctionTab
            // 
            this.FunctionTab.Controls.Add(this.FunctionTab1);
            this.FunctionTab.Controls.Add(this.FunctionTab2);
            this.FunctionTab.Controls.Add(this.FunctionTab3);
            this.FunctionTab.Controls.Add(this.FunctionTab4);
            this.FunctionTab.Location = new System.Drawing.Point(12, 12);
            this.FunctionTab.Name = "FunctionTab";
            this.FunctionTab.SelectedIndex = 0;
            this.FunctionTab.Size = new System.Drawing.Size(851, 159);
            this.FunctionTab.TabIndex = 0;
            this.FunctionTab.Tag = "";
            // 
            // FunctionTab1
            // 
            this.FunctionTab1.Controls.Add(this.Industries);
            this.FunctionTab1.Controls.Add(this.Markets);
            this.FunctionTab1.Controls.Add(this.SearchBtn);
            this.FunctionTab1.Controls.Add(this.label2);
            this.FunctionTab1.Controls.Add(this.label1);
            this.FunctionTab1.Location = new System.Drawing.Point(4, 22);
            this.FunctionTab1.Name = "FunctionTab1";
            this.FunctionTab1.Padding = new System.Windows.Forms.Padding(3);
            this.FunctionTab1.Size = new System.Drawing.Size(843, 133);
            this.FunctionTab1.TabIndex = 0;
            this.FunctionTab1.Text = "交易所產業分類下拉選單";
            this.FunctionTab1.UseVisualStyleBackColor = true;
            // 
            // Industries
            // 
            this.Industries.FormattingEnabled = true;
            this.Industries.Location = new System.Drawing.Point(453, 47);
            this.Industries.Name = "Industries";
            this.Industries.Size = new System.Drawing.Size(121, 20);
            this.Industries.TabIndex = 4;
            this.Industries.SelectedIndexChanged += new System.EventHandler(this.Markets_Click);
            this.Industries.Click += new System.EventHandler(this.Markets_Click);
            // 
            // Markets
            // 
            this.Markets.FormattingEnabled = true;
            this.Markets.Location = new System.Drawing.Point(174, 47);
            this.Markets.Name = "Markets";
            this.Markets.Size = new System.Drawing.Size(121, 20);
            this.Markets.TabIndex = 3;
            this.Markets.Click += new System.EventHandler(this.Markets_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(602, 46);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "查詢";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 16F);
            this.label2.Location = new System.Drawing.Point(326, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "產業名稱：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16F);
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "市場別名稱：";
            // 
            // FunctionTab2
            // 
            this.FunctionTab2.Location = new System.Drawing.Point(4, 22);
            this.FunctionTab2.Name = "FunctionTab2";
            this.FunctionTab2.Padding = new System.Windows.Forms.Padding(3);
            this.FunctionTab2.Size = new System.Drawing.Size(843, 133);
            this.FunctionTab2.TabIndex = 1;
            this.FunctionTab2.Text = "日收盤查詢及轉置";
            this.FunctionTab2.UseVisualStyleBackColor = true;
            // 
            // FunctionTab3
            // 
            this.FunctionTab3.Location = new System.Drawing.Point(4, 22);
            this.FunctionTab3.Name = "FunctionTab3";
            this.FunctionTab3.Padding = new System.Windows.Forms.Padding(3);
            this.FunctionTab3.Size = new System.Drawing.Size(843, 133);
            this.FunctionTab3.TabIndex = 2;
            this.FunctionTab3.Text = "日收盤本益比優劣榜";
            this.FunctionTab3.UseVisualStyleBackColor = true;
            // 
            // FunctionTab4
            // 
            this.FunctionTab4.Location = new System.Drawing.Point(4, 22);
            this.FunctionTab4.Name = "FunctionTab4";
            this.FunctionTab4.Padding = new System.Windows.Forms.Padding(3);
            this.FunctionTab4.Size = new System.Drawing.Size(843, 133);
            this.FunctionTab4.TabIndex = 3;
            this.FunctionTab4.Text = "總統大選類股表現";
            this.FunctionTab4.UseVisualStyleBackColor = true;
            // 
            // DataViewTab
            // 
            this.DataViewTab.Controls.Add(this.DataViewTab1);
            this.DataViewTab.Controls.Add(this.DataViewTab2);
            this.DataViewTab.Controls.Add(this.DataViewTab3);
            this.DataViewTab.Location = new System.Drawing.Point(16, 186);
            this.DataViewTab.Name = "DataViewTab";
            this.DataViewTab.SelectedIndex = 0;
            this.DataViewTab.Size = new System.Drawing.Size(1044, 382);
            this.DataViewTab.TabIndex = 1;
            // 
            // DataViewTab1
            // 
            this.DataViewTab1.Controls.Add(this.dataGridView1);
            this.DataViewTab1.Location = new System.Drawing.Point(4, 22);
            this.DataViewTab1.Name = "DataViewTab1";
            this.DataViewTab1.Padding = new System.Windows.Forms.Padding(3);
            this.DataViewTab1.Size = new System.Drawing.Size(1036, 356);
            this.DataViewTab1.TabIndex = 0;
            this.DataViewTab1.Text = "共用";
            this.DataViewTab1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1033, 356);
            this.dataGridView1.TabIndex = 0;
            // 
            // DataViewTab2
            // 
            this.DataViewTab2.Controls.Add(this.dataGridView2);
            this.DataViewTab2.Location = new System.Drawing.Point(4, 22);
            this.DataViewTab2.Name = "DataViewTab2";
            this.DataViewTab2.Padding = new System.Windows.Forms.Padding(3);
            this.DataViewTab2.Size = new System.Drawing.Size(1036, 356);
            this.DataViewTab2.TabIndex = 1;
            this.DataViewTab2.Text = "Q4-d-類股報酬率最高、最低前五名";
            this.DataViewTab2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1040, 356);
            this.dataGridView2.TabIndex = 0;
            // 
            // DataViewTab3
            // 
            this.DataViewTab3.Controls.Add(this.dataGridView3);
            this.DataViewTab3.Location = new System.Drawing.Point(4, 22);
            this.DataViewTab3.Name = "DataViewTab3";
            this.DataViewTab3.Padding = new System.Windows.Forms.Padding(3);
            this.DataViewTab3.Size = new System.Drawing.Size(1036, 356);
            this.DataViewTab3.TabIndex = 2;
            this.DataViewTab3.Text = "Q4-d-計算後原始資料";
            this.DataViewTab3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(-8, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(1044, 360);
            this.dataGridView3.TabIndex = 0;
            // 
            // ResponseTime
            // 
            this.ResponseTime.Location = new System.Drawing.Point(870, 34);
            this.ResponseTime.Name = "ResponseTime";
            this.ResponseTime.ReadOnly = true;
            this.ResponseTime.Size = new System.Drawing.Size(183, 137);
            this.ResponseTime.TabIndex = 2;
            this.ResponseTime.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 580);
            this.Controls.Add(this.ResponseTime);
            this.Controls.Add(this.DataViewTab);
            this.Controls.Add(this.FunctionTab);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FunctionTab.ResumeLayout(false);
            this.FunctionTab1.ResumeLayout(false);
            this.FunctionTab1.PerformLayout();
            this.DataViewTab.ResumeLayout(false);
            this.DataViewTab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.DataViewTab2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.DataViewTab3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl FunctionTab;
        private System.Windows.Forms.TabPage FunctionTab1;
        private System.Windows.Forms.TabPage FunctionTab2;
        private System.Windows.Forms.TabPage FunctionTab3;
        private System.Windows.Forms.TabPage FunctionTab4;
        private System.Windows.Forms.TabControl DataViewTab;
        private System.Windows.Forms.TabPage DataViewTab1;
        private System.Windows.Forms.TabPage DataViewTab2;
        private System.Windows.Forms.TabPage DataViewTab3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Industries;
        private System.Windows.Forms.ComboBox Markets;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox ResponseTime;
    }
}

