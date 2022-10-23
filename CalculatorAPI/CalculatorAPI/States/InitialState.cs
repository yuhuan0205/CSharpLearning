using CalculatorAPI.Inertfaces;
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

        public IState AddCalculatedProcess(string Operator)
        {
            Memory.AddOperand();
            Memory.AddOperator(Operator);
            return new OperatingState(Memory);
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

        public IState AddPoint()
        {
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
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

        public IState SquareRoot()
        {
            double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            Memory.SetDigits(root.ToString());
            return this;
        }
    }
}
