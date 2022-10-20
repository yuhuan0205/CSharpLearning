﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public interface ICalculator
    {
        public string GetStatus();
        public void AddDigit(string digit);
        public void AddDigitZero();
        public void ResetDigits();
        public void AddCalculatedProcess(string Operator);
        public void ResetCalculatedProcess();
        public void Backspace();
        public void ChangeSign();
        public void SquareRoot();
        public void AddPoint();
        public void GetResult();
    }
}
