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
        /// <param name="computeEnging"> a computingEngine </param>
        /// <returns> EqualState </returns>
        public IState GetResult(IEngine computeEnging)
        {
            //make all single left parenthese become a pair.
            for (int singleParenthese = Memory.GetParentheseCounts(); singleParenthese > 0; singleParenthese--)
            {
                Memory.AddElement(new RightParenthese());
            }

            MessageObject message = computeEnging.GetResult(Memory.GetInfix());
            Memory.SetDigits(message.InputNumber);
            Memory.SetCalculatedProcess(message.CalculatedProcess);
            Memory.SetParentheseCounts(0);
            return new EqualState(Memory);
        }

        /// <summary>
        /// in RightParentheseState user can not get the square root of operand.
        /// </summary>
        /// <returns> this state. </returns>
        public IState SquareRoot()
        {
            return this;
        }

        /// <summary>
        /// reset Digits
        /// </summary>
        /// <returns>this State</returns>
        public IState ResetDigits()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            return this;
        }
    }
}