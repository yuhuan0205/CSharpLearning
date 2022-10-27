using System.Collections.Generic;

namespace CalculatorAPI.Interfaces
{
    /// <summary>
    /// a interface define what things a Engine should implement.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// get the answer from infix.
        /// </summary>
        /// <param name="infix"> infix expression </param>
        /// <returns> a message contain answer and calculated process.</returns>
        public MessageObject GetResult(List<IElement> infix);
    }
}
