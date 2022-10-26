using System.Collections.Generic;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI
{
    /// <summary>
    /// a interface define what things a Memory should implement.
    /// </summary>
    public interface IMemory
    {
        /// <summary>
        /// get digits which user is typing.
        /// </summary>
        /// <returns></returns>
        public string GetDigits();

        /// <summary>
        /// set digits' value.
        /// </summary>
        /// <param name="digits"> the value wants to set. </param>
        public void SetDigits(string digits);

        /// <summary>
        /// add digit into digits.
        /// </summary>
        /// <param name="digit"> a digit </param>
        public void AddDigit(string digit);

        /// <summary>
        /// remove the last digit from digits.
        /// </summary>
        public void RemoveLastDigit();

        /// <summary>
        /// remove all digits.
        /// </summary>
        public void ClearDigits();

        /// <summary>
        /// get the expression.
        /// </summary>
        /// <returns> infix expression for rendering </returns>
        public string GetCalculatedProcess();

        /// <summary>
        /// add Element into Elements.
        /// </summary>
        /// <param name="element"> Element </param>
        public void AddElement(IElement element);

        /// <summary>
        /// remove the last operator from expression and Elements.
        /// </summary>
        public void RemoveLastOperator();

        /// <summary>
        /// remove all Element from Elements and expression.
        /// </summary>
        public void ClearCalculatedProcess();

        /// <summary>
        /// set expression's value.
        /// </summary>
        /// <param name="calculatedProcess"> value wants to set. </param>
        public void SetCalculatedProcess(string calculatedProcess);

        /// <summary>
        /// get the counts of unpaired parenthese.
        /// </summary>
        /// <returns> counts. </returns>
        public int GetParentheseCounts();

        /// <summary>
        /// set counts of unpaired parenthese value.
        /// </summary>
        public void SetParentheseCounts(int counts);

        /// <summary>
        /// get the infix expression.
        /// </summary>
        /// <returns> infix expression for computing. </returns>
        public List<IElement> GetInfix();
    }
}