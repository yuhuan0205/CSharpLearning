﻿using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.States
{
    public class NormalState : IState
    {
        private IMemory Memory;

        public NormalState(IMemory memory)
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
            Memory.AddDigit(digit);
            return this;
        }

        public IState AddDigitZero()
        {
            Memory.AddDigit(Consts.ZERO_STRING);
            return this;
        }

        public IState AddLeftParenthese(IElement element)
        {
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() + Consts.ONE);
            return new LeftParentheseState(Memory);
        }

        public IState AddPoint()
        {
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
        }

        public IState AddRightParenthese(IElement element)
        {
            for (; Memory.GetParentheseCounts() != 0;)
            {
                NumberElement number = new NumberElement(Memory.GetDigits());
                Memory.AddElement(number);
                Memory.AddElement(element);
                Memory.SetParentheseCounts(Memory.GetParentheseCounts() - Consts.ONE);
                return new RightParentheseState(Memory);
            }
            return this;
        }

        public IState Backspace()
        {
            for( ; Memory.GetDigits().Length == 1 ; )
            {
                Memory.SetDigits(Consts.ZERO_STRING);
                return new InitialState(Memory);
            }

            Memory.RemoveLastDigit();
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
            double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            
            for (; root is double.NaN ;)
            {
                Memory.ClearCalculatedProcess();
                Memory.SetDigits(Consts.SQUARE_ROOT_WITH_NAGATIVE);
                return new ErrorState(Memory);
            }
            Memory.SetDigits(root.ToString());
            return new InitialState(Memory);
        }
    }
}
