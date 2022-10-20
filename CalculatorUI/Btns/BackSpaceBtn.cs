using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorUI.Btns
{
    /// <summary>
    /// a button that delete the last digit of NowNumber.
    /// </summary>
    public class BackSpaceBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="id"> id of this application</param>
        /// <param name="client"> a object to call api </param>
        public async override Task OnClick(int id, HttpClient client)
        {
            _ = await client.GetAsync($"backspace/{id}");
        }
    }
}