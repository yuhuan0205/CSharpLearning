using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.States
{
    public class RightParentheseState : IState
    {
        private IMemory Memory;

        public RightParentheseState(IMemory memory)
        {
            Memory = memory;
        }

        public IState AddCalculatedProcess(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(element);
            return new OperatingState(Memory);
        }

        public IState AddDigit(string digit)
        {
            return this;
        }

        public IState AddDigitZero()
        {
            return this;
        }

        public IState AddLeftParenthese(IElement element)
        {
            return this;
        }

        public IState AddPoint()
        {
            return this;
        }

        public IState AddRightParenthese(IElement element)
        {
            for (; Memory.GetParentheseCounts() != 0;)
            {
                Memory.AddElement(new RightParenthese());
                Memory.SetParentheseCounts(Memory.GetParentheseCounts() - Consts.ONE);
                return new RightParentheseState(Memory);
            }
            return this;
        }

        public IState Backspace()
        {
            return this;
        }

        public IState ChangeSign()
        {
            //Memory.SetDigits((Convert.ToDecimal(Memory.GetDigits()) * -1).ToString());
            return this;
        }

        public void EqualClick()
        {
            
        }

        public IState SquareRoot()
        {
            //double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            //Memory.SetDigits(root.ToString());
            return this;
        }
    }
}
