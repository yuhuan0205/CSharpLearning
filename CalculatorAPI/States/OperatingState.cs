﻿using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.States
{
    public class OperatingState : IState
    {
        private IMemory Memory;

        public OperatingState(IMemory memory)
        {
            Memory = memory;
        }

        public IState AddCalculatedProcess(IElement element)
        {
            Memory.RemoveLastOperator();
            Memory.AddElement(element);
            return this;
        }

        public IState AddDigit(string digit)
        {
            Memory.ClearDigits();
            Memory.AddDigit(digit);
            return new NormalState(Memory);
        }

        public IState AddDigitZero()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        public IState AddLeftParenthese(IElement element)
        {
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
            return this;
        }

        public IState ChangeSign()
        {
            Memory.SetDigits((Convert.ToDecimal(Memory.GetDigits()) * -1).ToString());
            return new InitialState(Memory);
        }

        public IState SquareRoot()
        {
            double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            Memory.SetDigits(root.ToString());
            return new InitialState(Memory);
        }
    }
}