using CalculatorAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.States
{
    public class ErrorState : InitialState
    {
        private IMemory Memory;
        public ErrorState(IMemory memory) : base(memory)
        {
            Memory = memory;
        }
        public override IState AddOperator(IElement element)
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        public override IState AddOperatorDivide(IElement element)
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }
        public override IState AddLeftParenthese(IElement element)
        {
            return base.AddLeftParenthese(element);
        }
        public override IState Backspace()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }
        public override IState ChangeSign()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }
        public override void EqualClick()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
        }
        public override IState SquareRoot()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }
    }
}
