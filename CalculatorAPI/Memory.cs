using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public class Memory : IMemory
    {
        private string InputDigits;

        private StringBuilder InputDigitsBuilder;

        private string CalculatedProcess;

        private StringBuilder CalculatedProcessBuilder;

        public Memory()
        {
            InputDigits = Consts.ZERO_STRING;
            InputDigitsBuilder = new StringBuilder(InputDigits);
            CalculatedProcess = Consts.EMYPT_STRING;
            CalculatedProcessBuilder = new StringBuilder();
        }

        public void AddDigit(string digit)
        {
            InputDigitsBuilder.Append(digit);
            InputDigits = InputDigitsBuilder.ToString();
        }

        public void AddOperand()
        {
            CalculatedProcessBuilder.Append(InputDigits);
            CalculatedProcess = CalculatedProcessBuilder.ToString();
        }

        public void AddOperator(string Operator)
        {
            CalculatedProcessBuilder.Append(Operator);
            CalculatedProcess = CalculatedProcessBuilder.ToString();
        }

        public void ClearCalculatedProcess()
        {
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
    }
}
