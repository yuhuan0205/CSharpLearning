using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorUI.Btns
{
    /// <summary>
    /// add point to number.
    /// </summary>
    public class PointBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="id"> id of this application</param>
        /// <param name="client"> a object to call api </param>
        /// <returns> task </returns>
        public async override Task OnClick(string id, HttpClient client)
        {
            await client.GetAsync($"point/{id}");
        }
    }
}