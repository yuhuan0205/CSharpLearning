using System.Threading.Tasks;
using System.Net.Http;

namespace CalculatorUI
{
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Abstract Button class.
    /// </summary>
    public abstract class AbstractBtn : Button
    {
        /// <summary>
        /// every child class should implement this abstract function.
        /// it makes each button has its own OnClick function.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public abstract Task OnClick(string id, HttpClient client);
    }
}