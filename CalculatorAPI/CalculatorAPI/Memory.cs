using CalculatorAPI.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace CalculatorAPI
{
    /// <summary>
    ///  Memory implements IMemory. To store operators and operands.
    /// </summary>
    public class Memory : IMemory
    {
        /// <summary>
        /// a list contains Element which is a infix collection with operators and operands .
        /// </summary>
        private List<IElement> Elements;

        /// <summary>
        /// operand
        /// </summary>
        private string InputDigits;

        /// <summary>
        /// StringBuilder to build operand with a series digits.
        /// </summary>
        private StringBuilder InputDigitsBuilder;

        /// <summary>
        /// CalculatedProcess
        /// </summary>
        private string CalculatedProcess;

        /// <summary>
        /// StringBuilder to build CalculatedProcess with operators and operands.
        /// </summary>
        private StringBuilder CalculatedProcessBuilder;

        /// <summary>
        /// a int to record how many single left parenthese.
        /// </summary>
        private int ParentheseCount;

        /// <summary>
        /// constructor.
        /// </summary>
        public Memory()
        {
            Elements = new List<IElement>();
            InputDigits = Consts.ZERO_STRING;
            InputDigitsBuilder = new StringBuilder(InputDigits);
            CalculatedProcess = Consts.EMYPT_STRING;
            CalculatedProcessBuilder = new StringBuilder();
            ParentheseCount = Consts.ZERO;
        }

        /// <summary>
        /// add a digit into operand.
        /// </summary>
        /// <param name="digit"> a digit </param>
        public void AddDigit(string digit)
        {
            InputDigits = InputDigitsBuilder.Append(digit).ToString();
        }

        /// <summary>
        /// add a operand or operator into Elements. 
        /// </summary>
        /// <param name="element"> IElement </param>
        public void AddElement(IElement element)
        {
            Elements.Add(element);
            CalculatedProcess = CalculatedProcessBuilder.Append(element.GetValueString()).ToString();
        }

        /// <summary>
        /// clear all CalculatedProcess.
        /// </summary>
        public void ClearCalculatedProcess()
        {
            Elements.Clear();
            ParentheseCount = Consts.ZERO;
            CalculatedProcess = CalculatedProcessBuilder.Clear().ToString();
        }

        /// <summary>
        ///  set CalculatedProcess's value.
        /// </summary>
        /// <param name="calculatedProcess"> target value. </param>
        public void SetCalculatedProcess(string calculatedProcess)
        {
            CalculatedProcess = calculatedProcess;
            CalculatedProcessBuilder = new StringBuilder(CalculatedProcess);
        }

        /// <summary>
        /// clear operand which user is typing.
        /// </summary>
        public void ClearDigits()
        {
            InputDigits = InputDigitsBuilder.Clear().ToString();
        }

        /// <summary>
        /// Get CalculatedProcess.
        /// </summary>
        /// <returns> CalculatedProcess </returns>
        public string GetCalculatedProcess()
        {
            return CalculatedProcess;
        }

        /// <summary>
        /// Get operand.
        /// </summary>
        /// <returns> a operand which user is typing. </returns>
        public string GetDigits()
        {
            return InputDigits;
        }

        /// <summary>
        /// Set operand's value.
        /// </summary>
        /// <param name="digits"> target value. </param>
        public void SetDigits(string digits)
        {
            InputDigits = digits;
            InputDigitsBuilder = new StringBuilder(InputDigits);
        }

        /// <summary>
        /// remove the last digit from the operand which user is typing.
        /// </summary>
        public void RemoveLastDigit()
        {
            InputDigitsBuilder.Remove(InputDigits.Length - 1, 1);
            InputDigits = InputDigitsBuilder.ToString();
        }

        /// <summary>
        /// remove the last operator from the CalculatedProcess.
        /// </summary>
        public void RemoveLastOperator()
        {
            Elements.RemoveAt(Elements.Count - 1);
            CalculatedProcessBuilder.Remove(CalculatedProcessBuilder.Length - 1, 1);
            CalculatedProcess = CalculatedProcessBuilder.ToString();
        }

        /// <summary>
        /// get ParentheseCount.
        /// </summary>
        /// <returns></returns>
        public int GetParentheseCounts()
        {
            return ParentheseCount;
        }

        /// <summary>
        /// set ParentheseCount's value.
        /// </summary>
        /// <param name="counts">value</param>
        public void SetParentheseCounts(int counts)
        {
            ParentheseCount = counts;
        }

        /// <summary>
        /// get Elements.
        /// </summary>
        /// <returns></returns>
        public List<IElement> GetInfix()
        {
            return Elements;
        }
    }
}