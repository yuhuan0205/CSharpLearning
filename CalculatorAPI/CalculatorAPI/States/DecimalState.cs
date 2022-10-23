using CalculatorAPI.Inertfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.States
{
    public class DecimalState : IState
    {
        private IMemory Memory;

        private int PointIndex;

        public DecimalState(IMemory memory)
        {
            Memory = memory;
            PointIndex = 0;
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
            PointIndex ++;
            return this;
        }

        public IState AddDigitZero()
        {
            Memory.AddDigit(Consts.ZERO_STRING);
            PointIndex++;
            return this;
        }

        public IState AddPoint()
        {
            return this;
        }

        public IState Backspace()
        {
            Memory.RemoveLastDigit();
            for ( ; PointIndex == 0 ; )
            {
                for( ; Memory.GetDigits() == Consts.ZERO_STRING ; )
                {
                    return new InitialState(Memory);
                }

                return new NormalState(Memory);
            }
            PointIndex--;
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
