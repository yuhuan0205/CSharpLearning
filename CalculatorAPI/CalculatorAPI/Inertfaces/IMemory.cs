using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public interface IMemory
    {
        public string GetDigits();
        public void SetDigits(string digits);
        public void AddDigit(string digit);
        public void RemoveLastDigit();
        public void ClearDigits();
        public string GetCalculatedProcess();
        public void AddOperator(string Operator);
        public void RemoveLastOperator();
        public void AddOperand();
        public void ClearCalculatedProcess();
        public void SetCalculatedProcess(string calculatedProcess);
    }
}
