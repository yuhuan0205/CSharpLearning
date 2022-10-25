using System;
using System.Collections.Generic;
using System.Linq;
namespace CalculatorAPI.Interfaces
{
   public interface IElement
    {
        public int GetPriority();
        public decimal DoOperation(decimal firstNumber, decimal secondNumber);
        public decimal GetValue();
        public string GetValueString();
    }
}
