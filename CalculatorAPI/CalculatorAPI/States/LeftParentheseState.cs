using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.States
{
    public class LeftParentheseState : IState
    {
        private IMemory Memory;

        public LeftParentheseState(IMemory memory)
        {
            Memory = memory;
        }

        public IState AddOperator(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
            Memory.AddElement(element);
            return new OperatingState(Memory);
        }
        public IState AddOperatorDivide(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
            Memory.AddElement(element);
            return new DivideState(Memory);
        }

        public IState AddDigit(string digit)
        {
            Memory.ClearDigits();
            Memory.AddDigit(digit);
            return new NormalState(Memory);
        }

        public IState AddDigitZero()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return this;
        }

        public IState AddLeftParenthese(IElement element)
        {
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() + Consts.ONE);
            return this;
        }

        public IState AddPoint()
        {
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
        }

        public IState AddRightParenthese(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() - Consts.ONE);
            return new RightParentheseState(Memory);
            
        }

        public IState Backspace()
        {
            return this;
        }

        public IState ChangeSign()
        {
            Memory.SetDigits((Convert.ToDecimal(Memory.GetDigits()) * -1).ToString());
            return this;
        }

        public void EqualClick()
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
        }

        public IState SquareRoot()
        {
            //double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            //Memory.SetDigits(root.ToString());
            return this;
        }
    }
}
