using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI
{
    public interface ICalculator
    {
        public string GetStatus();
        public void AddDigit(string digit);
        public void AddDigitZero();
        public void ResetDigits();
        public void AddCalculatedProcess(IElement element);
        public void ResetCalculatedProcess();
        public void Backspace();
        public void ChangeSign();
        public void SquareRoot();
        public void AddPoint();
        public void GetResult();
        public void AddLeftParenthese(IElement element);
        public void AddRightParenthese(IElement element);

    }
}
