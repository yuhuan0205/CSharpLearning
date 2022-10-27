using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CalculatorUI
{
    /// <summary>
    /// winform
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// a client object in order to call api.
        /// </summary>
        private HttpClient Client;

        /// <summary>
        /// a object implemented ICalculator. In order to compute.
        /// </summary>
        private string Id;

        /// <summary>
        /// Form init, Calculator init.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitMembers();
        }

        /// <summary>
        /// new a object which implement ICalculator.
        /// </summary>
        private async void InitMembers()
        {
            Client = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
            HttpResponseMessage response = await Client.GetAsync("enroll");
            Id = await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// button_click, the executing fuction depends on which button object class was pressed.   
        /// </summary>
        /// <param name="sender">which button is pressed.</param>
        /// <param name="e">event</param>
        private async void Button_Click(object sender, EventArgs e)
        {
            //Polymorphism, in order to use different type of buttons.
            await ((AbstractBtn)sender).OnClick(Id, Client);

            HttpResponseMessage result = await Client.GetAsync($"status/{Id}");

            string jsonString = await result.Content.ReadAsStringAsync();

            MessageObject message = JsonSerializer.Deserialize<MessageObject>(jsonString);

            //render data to winform.
            InputNumber.Text = message.InputNumber;
            CaculatedProcess.Text = message.CalculatedProcess;
        }

        /// <summary>
        /// log out from server.
        /// </summary>
        /// <param name="sender"> the parameter is not used </param>
        /// <param name="e"> object </param>
        private async void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await Client.DeleteAsync($"calculator/{Id}");
        }
    }
}