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

        public IState AddCalculatedProcess(string Operator)
        {
            Memory.AddOperand();
            Memory.AddOperator(Operator);
            return new OperatingState(Memory);
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

        public IState AddPoint()
        {
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
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

        public IState SquareRoot()
        {
            double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            Memory.SetDigits(root.ToString());
            return new InitialState(Memory);
        }
    }
}
