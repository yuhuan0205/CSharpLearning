using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Interfaces;

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
        public void AddElement(IElement element);
        public void RemoveLastOperator();
        public void ClearCalculatedProcess();
        public void SetCalculatedProcess(string calculatedProcess);
        public int GetParentheseCounts();
        public void SetParentheseCounts(int counts);
        public List<IElement> GetInfix();
    }
}
