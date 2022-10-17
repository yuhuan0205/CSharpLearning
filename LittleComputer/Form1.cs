using System;
using System.Windows.Forms;

namespace LittleComputer
{
    /// <summary>
    /// winform
    /// </summary>
    public partial class Form1 : Form
    {
        public ICalculator Calculator { get; set; }
        /// <summary>
        /// Form init, Computer init.
        /// </summary>
        public Form1()
        {
            //Computer.Init();
            InitializeComponent();
            InitMembers();
        }

        private void InitMembers()
        {
            Calculator = new MyCalculator();
        }

        /// <summary>
        /// button_click, the executing fuction depends on which button object class was pressed.   
        /// </summary>
        /// <param name="sender">which button is pressed.</param>
        /// <param name="e">event</param>
        private void Button_Click(object sender, EventArgs e)
        {
            //Polymorphism, in order to use different type of buttons.
            ((AbstractBtn)sender).OnClick(Calculator);
            MessageObject message = Calculator.GetStatus();
            InputNumber.Text = message.InputNumber;
            CaculatedProcess.Text = message.CalculatedProcess;
        }
    }
}
