using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            StockDBEntities db = new StockDBEntities();
            var Results = from row in db.交易所產業分類代號表 select row;
            dataGridView1.DataSource = Results.ToList();
        }

        private void Markets_Click(object sender, EventArgs e)
        {
            NestedDictionary nestedDictionary =  NestedDictionary.Create();
            Markets.DataSource = nestedDictionary.GetMarkets();
            //Industries.DataSource = 
        }
    }
}
