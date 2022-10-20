using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorAPI.Inertfaces;

namespace CalculatorAPI.States
{
    public class EqualState : IState
    {
        private IMemory Memory;

        public EqualState(IMemory memory)
        {
            Memory = memory;
        }


        public IState AddCalculatedProcess(string Operator)
        {
            Memory.ClearCalculatedProcess();
            Memory.AddOperand();
            Memory.AddOperator(Operator);
            return new OperatingState(Memory);

        }

        public IState AddDigit(string digit)
        {
            Memory.ClearCalculatedProcess();
            Memory.ClearDigits();
            Memory.AddDigit(digit);
            return new NormalState(Memory);
        }

        public IState AddDigitZero()
        {
            Memory.ClearCalculatedProcess();
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        public IState AddPoint()
        {
            Memory.ClearCalculatedProcess();
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
        }

        public IState Backspace()
        {
            Memory.ClearCalculatedProcess();
            return new InitialState(Memory);
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
