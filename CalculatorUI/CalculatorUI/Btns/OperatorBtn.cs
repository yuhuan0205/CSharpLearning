using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorUI
{
    /// <summary>
    /// a button that user can type digits into Computer.
    /// </summary>
    public class OperatorBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="id"> id of this application</param>
        /// <param name="client"> a object to call api </param>
        public async override Task OnClick(string id, HttpClient client)
        {
            _ = await client.GetAsync($"operator/{id}/{Tag}");
        }
    }
}
