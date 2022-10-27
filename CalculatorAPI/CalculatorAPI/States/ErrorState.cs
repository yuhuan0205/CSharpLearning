using CalculatorAPI.Interfaces;

namespace CalculatorAPI.States
{
    /// <summary>
    /// ErrorState is a state inherit InitialState.
    /// </summary>
    public class ErrorState : InitialState
    {
        /// <summary>
        /// a object store data.
        /// </summary>
        private IMemory Memory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="memory"> DI memory </param>
        public ErrorState(IMemory memory) : base(memory)
        {
            Memory = memory;
        }

        /// <summary>
        /// set digits zero, and change state to InitialState.
        /// </summary>
        /// <param name="element"> operators except divide. </param>
        /// <returns> InitialState </returns>
        public override IState AddOperator(IElement element)
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        /// <summary>
        /// set digits zero, and change state to InitialState.
        /// </summary>
        /// <param name="element"> divider. </param>
        /// <returns> InitialState </returns>
        public override IState AddOperatorDivide(IElement element)
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        /// <summary>
        /// set digits zero, and change state to LeftParentheseState.
        /// </summary>
        /// <param name="element"> LeftParenthese </param>
        /// <returns> LeftParentheseState </returns>
        public override IState AddLeftParenthese(IElement element)
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return base.AddLeftParenthese(element);
        }

        /// <summary>
        /// set digits zero, and change state to InitialState.
        /// </summary>
        /// <returns> InitialState </returns>
        public override IState Backspace()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        /// <summary>
        /// set digits zero, and change state to InitialState.
        /// </summary>
        /// <returns> InitialState </returns>
        public override IState ChangeSign()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        /// <summary>
        /// set digits zero
        /// </summary>
        /// <param name="computeEnging"> a computingEngine </param>
        /// <returns> initialState </returns>
        public override IState GetResult(IEngine computeEnging)
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        /// <summary>
        /// set digits zero, and change state to InitialState.
        /// </summary>
        /// <returns> InitialState </returns>
        public override IState SquareRoot()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }
    }
}