using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Elements
{
    public class EndSign : IElement
    {
        private string ValueString;

        private int Priority;
        public EndSign()
        {
            Priority = Consts.PRIORITY_END;
        }

        //do nothing.
        public decimal DoOperation(decimal firstNumber, decimal LastNumber)
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
