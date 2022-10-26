using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.States
{
    /// <summary>
    /// RightParentheseState is a state implement IState.
    /// </summary>
    public class RightParentheseState : IState
    {
        /// <summary>
        /// a object store data.
        /// </summary>
        private IMemory Memory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="memory"> DI memory </param>
        public RightParentheseState(IMemory memory)
        {
            Memory = memory;
        }

        /// <summary>
        /// add operator into expression, and change state to OperatingState.
        /// </summary>
        /// <param name="element"> operators except divide. </param>
        /// <returns> OperatingState </returns>
        public IState AddOperator(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(element);
            return new OperatingState(Memory);
        }

        /// <summary>
        /// add divide into expression, and change state to DivideState.
        /// </summary>
        /// <param name="element"> divide. </param>
        /// <returns> DivideState </returns>
        public IState AddOperatorDivide(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
            Memory.AddElement(element);
            return new DivideState(Memory);
        }

        /// <summary>
        /// in RightParentheseState user can not add digit into digits.
        /// </summary>
        /// <param name="digit">digit</param>
        /// <returns> this state. </returns>
        public IState AddDigit(string digit)
        {
            return this;
        }

        /// <summary>
        /// in RightParentheseState user can not add zero into digits.
        /// </summary>
        /// <returns> this state. </returns>
        public IState AddDigitZero()
        {
            return this;
        }

        /// <summary>
        /// in RightParentheseState user can not add LeftParenthese into Elements .
        /// </summary>
        /// <param name="element">LeftParenthese</param>
        /// <returns> this state. </returns>
        public IState AddLeftParenthese(IElement element)
        {
            return this;
        }

        /// <summary>
        /// in RightParentheseState user can not add point into digits.
        /// </summary>
        /// <returns> this state. </returns>
        public IState AddPoint()
        {
            return this;
        }

        /// <summary>
        /// add right parenthese into Elements, and change state to RightParentheseState.
        /// </summary>
        /// <param name="element"> right parenthese </param>
        /// <returns> RightParentheseState. </returns>
        public IState AddRightParenthese(IElement element)
        {
            for (; Memory.GetParentheseCounts() != 0;)
            {
                Memory.AddElement(new RightParenthese());
                Memory.SetParentheseCounts(Memory.GetParentheseCounts() - Consts.ONE);
                return new RightParentheseState(Memory);
            }
            return this;
        }

        /// <summary>
        /// in RightParentheseState user can not add remove the last digit from digits.
        /// </summary>
        /// <returns> this state. </returns>
        public IState Backspace()
        {
            return this;
        }

        /// <summary>
        /// in RightParentheseState user can not change operand's sign.
        /// </summary>
        /// <returns> this state. </returns>
        public IState ChangeSign()
        {
            return this;
        }

        /// <summary>
        /// in RightParentheseState operand will not add into Elements.
        /// </summary>
        public void EqualClick()
        {
        }

        /// <summary>
        /// in RightParentheseState user can not get the square root of operand.
        /// </summary>
        /// <returns> this state. </returns>
        public IState SquareRoot()
        {
            return this;
        }
    }
}