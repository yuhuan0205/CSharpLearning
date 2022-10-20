using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorUI
{
    /// <summary>
    /// a button that call Computer object to compute all operands and operators in order.
    /// And reset some Computer's parameter.
    /// </summary>
    public class EqualBtn : AbstractBtn
    {
        //TODO: set right api.
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="id"> id of this application</param>
        /// <param name="client"> a object to call api </param>
        public async override Task OnClick(int id, HttpClient client)
        {
            _ = await client.GetAsync($"getresult/{id}");
        }
    }
}