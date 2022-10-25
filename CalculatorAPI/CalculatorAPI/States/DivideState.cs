using CalculatorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.States
{
    public class DivideState: OperatingState
    {
        private IMemory Memory;

        private int ZeroCount;

        public DivideState(IMemory memory):base(memory)
        {
            Memory = memory;
            ZeroCount = Consts.ZERO;
        }

        public override IState AddDigitZero()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            ZeroCount++;
            return this;
        }

        public override IState AddOperator(IElement element)
        {
            for(;ZeroCount == Consts.ZERO ;)
            {
                Memory.RemoveLastOperator();
                Memory.AddElement(element);
                return new OperatingState(Memory);
            }
            Memory.ClearCalculatedProcess();
            Memory.SetDigits(Consts.DIVIDE_BY_ZERO_ERROR);
            return new ErrorState(Memory);
        }

        public override IState AddOperatorDivide(IElement element)
        {
            return this;
        }
    }
}
