using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    public class LeftParenthese : IElement
    {
        public string ValueString;

        public int Priority;
        public LeftParenthese()
        {
            ValueString = Consts.LEFT_PARENTHESE;
            Priority = Consts.PRIORITY_LEFT_PARENTHESE;
        }
        public decimal DoOperation(decimal firstNumber, decimal secondNumber)
        {
            return 0;
        }

        public int GetPriority()
        {
            return Priority;
        }

        public decimal GetValue()
        {
            return 0;
        }

        public string GetValueString()
        {
            return ValueString;
        }
    }
}
