using CalculatorAPI.Interfaces;

namespace CalculatorAPI
{
    /// <summary>
    /// a interface define what things a Calculator should implement.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// get calculator's status.
        /// </summary>
        /// <returns> a json like string</returns>
        public string GetStatus();

        /// <summary>
        /// add digit into operand.
        /// </summary>
        /// <param name="digit"> digit </param>
        public void AddDigit(string digit);

        /// <summary>
        /// add zero digit into operand.
        /// </summary>
        public void AddDigitZero();

        /// <summary>
        /// clear input.
        /// </summary>
        public void ResetDigits();

        /// <summary>
        /// add IElemnet into Calculator
        /// </summary>
        /// <param name="element"> operator or operand </param>
        public void AddCalculatedProcess(IElement element);

        /// <summary>
        /// clear all status.
        /// </summary>
        public void ResetCalculatedProcess();

        /// <summary>
        /// remove the last digit from operand. 
        /// </summary>
        public void Backspace();

        /// <summary>
        /// change the sign of operand.
        /// </summary>
        public void ChangeSign();

        /// <summary>
        /// do a square root with operand.
        /// </summary>
        public void SquareRoot();

        /// <summary>
        /// add a point into operand.
        /// </summary>
        public void AddPoint();

        /// <summary>
        /// get a answer from calculated process.
        /// </summary>
        public void GetResult();

        /// <summary>
        /// add left parenthese into operators.
        /// </summary>
        /// <param name="element">left parenthese</param>
        public void AddLeftParenthese(IElement element);

        /// <summary>
        /// add right parenthese into operators.
        /// </summary>
        /// <param name="element">right parenthese</param>
        public void AddRightParenthese(IElement element);
    }
}