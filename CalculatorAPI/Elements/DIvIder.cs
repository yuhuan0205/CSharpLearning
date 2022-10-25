using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    public class Divider : IElement
    {
        private string ValueString;

        private int Priority;

        public Divider()
        {
            ValueString = Consts.DIVIDE_SIGN;
            Priority = Consts.PRIORITY_OPERTOR_HIGH;
        }

        public decimal DoOperation(decimal firstNumber, decimal secondNumber)
        {
            try
            {
                return firstNumber / secondNumber;
            }
            catch (DivideByZeroException)
            {
                return firstNumber;
            }
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
