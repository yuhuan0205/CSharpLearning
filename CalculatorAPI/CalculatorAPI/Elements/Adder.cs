using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    public class Adder : IElement
    {
        private string ValueString;

        private int Priority;

        public Adder()
        {
            ValueString = Consts.ADD_SIGN;
            Priority = Consts.PRIORITY_OPERTOR_LOW;
        }
        public decimal DoOperation(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber + secondNumber;
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
