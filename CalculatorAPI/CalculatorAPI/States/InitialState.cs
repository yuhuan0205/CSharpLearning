using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.States
{
    public class InitialState : IState
    {
        private IMemory Memory;

        public InitialState(IMemory memory)
        {
            Memory = memory;
        }

        public virtual IState AddOperator(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
            Memory.AddElement(element);
            return new OperatingState(Memory);
        }

        public virtual IState AddOperatorDivide(IElement element)
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

        public virtual IState AddLeftParenthese(IElement element)
        {
            Memory.ClearCalculatedProcess();
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() + Consts.ONE);
            return new LeftParentheseState(Memory);
        }

        public IState AddPoint()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
        }

        public IState AddRightParenthese(IElement element)
        {
            for(; Memory.GetParentheseCounts() != 0 ;)
            {
                NumberElement number = new NumberElement(Memory.GetDigits());
                Memory.AddElement(number);
                Memory.AddElement(element);
                Memory.SetParentheseCounts(Memory.GetParentheseCounts() - Consts.ONE);
                return new RightParentheseState(Memory);
            }
            return this;
        }

        public virtual IState Backspace()
        {
            return this;
        }

        public virtual IState ChangeSign()
        {
            Memory.SetDigits((Convert.ToDecimal(Memory.GetDigits()) * -1).ToString());
            return this;
        }

        public virtual void EqualClick()
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
        }

        public  virtual IState SquareRoot()
        {
            double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            for (; root is double.NaN;)
            {
                Memory.ClearCalculatedProcess();
                Memory.SetDigits(Consts.SQUARE_ROOT_WITH_NAGATIVE);
                return new ErrorState(Memory);
            }
            Memory.SetDigits(root.ToString());
            return this;
        }
    }
}
