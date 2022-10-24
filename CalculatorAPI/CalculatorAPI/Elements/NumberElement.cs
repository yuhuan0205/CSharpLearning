using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    public class NumberElement : IElement
    {
        private decimal Value;

        private string ValueString;

        private int Priority;
        public NumberElement(string value)
        {
            ValueString = value;
            Value = Convert.ToDecimal(ValueString);
            Priority = Consts.PRIORITY_OPERAND;
        }

        //do nothing.
        public decimal DoOperation(decimal firstNumber, decimal LastNumber)
        {
            return 0 ;
        }

        public int GetPriority()
        {
            return Priority;
        }

        public decimal GetValue()
        {
            return Value;
        }

        public string GetValueString()
        {
            return ValueString;
        }
    }
}
