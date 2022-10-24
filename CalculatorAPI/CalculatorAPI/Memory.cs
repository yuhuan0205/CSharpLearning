using CalculatorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public class Memory : IMemory
    {
        private List<IElement> Elements;

        private string InputDigits;

        private StringBuilder InputDigitsBuilder;

        private string CalculatedProcess;

        private StringBuilder CalculatedProcessBuilder;

        private int ParentheseCount;

        public Memory()
        {
            Elements = new List<IElement>();
            InputDigits = Consts.ZERO_STRING;
            InputDigitsBuilder = new StringBuilder(InputDigits);
            CalculatedProcess = Consts.EMYPT_STRING;
            CalculatedProcessBuilder = new StringBuilder();
            ParentheseCount = Consts.ZERO;
        }

        public void AddDigit(string digit)
        {
            InputDigitsBuilder.Append(digit);
            InputDigits = InputDigitsBuilder.ToString();
        }

        public void AddElement(IElement element)
        {
            Elements.Add(element);
            CalculatedProcessBuilder.Append(element.GetValueString());
            CalculatedProcess = CalculatedProcessBuilder.ToString();
        }

        public void ClearCalculatedProcess()
        {
            Elements.Clear();
            CalculatedProcessBuilder.Clear();
            CalculatedProcess = CalculatedProcessBuilder.ToString();
        }

        public void SetCalculatedProcess(string calculatedProcess)
        {
            CalculatedProcess = calculatedProcess;
            CalculatedProcessBuilder = new StringBuilder(CalculatedProcess);
        }

        public void ClearDigits()
        {
            InputDigitsBuilder.Clear();
            InputDigits = InputDigitsBuilder.ToString();
        }

        public string GetCalculatedProcess()
        {
            return CalculatedProcess;
        }

        public string GetDigits()
        {
            return InputDigits;
        }

        public void SetDigits(string digits)
        {
            InputDigits = digits;
            InputDigitsBuilder = new StringBuilder(InputDigits);
        }

        public void RemoveLastDigit()
        {
            InputDigitsBuilder.Remove(InputDigits.Length - 1, 1);
            InputDigits = InputDigitsBuilder.ToString();
        }

        public void RemoveLastOperator()
        {
            CalculatedProcessBuilder.Remove(CalculatedProcessBuilder.Length - 1, 1);
            CalculatedProcess = CalculatedProcessBuilder.ToString();
        }
        public int GetParentheseCounts()
        {
            return ParentheseCount;
        }

        public void SetParentheseCounts(int counts)
        {
            ParentheseCount = counts;
        }
        public List<IElement> GetInfix()
        {
            return Elements;
        }
    }
}
