using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;
using System;

namespace CalculatorAPI.States
{
    /// <summary>
    /// LeftParentheseState is a state implement IState.
    /// </summary>
    public class LeftParentheseState : IState
    {
        /// <summary>
        /// a object store data.
        /// </summary>
        private IMemory Memory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="memory"> DI memory </param>
        public LeftParentheseState(IMemory memory)
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
            Memory.AddElement(number);
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
        /// set digits from zero to the digit user typed, and change state to NormalState.
        /// </summary>
        /// <param name="digit">digit</param>
        /// <returns> Normalstate. </returns>
        public IState AddDigit(string digit)
        {
            Memory.ClearDigits();
            Memory.AddDigit(digit);
            return new NormalState(Memory);
        }

        /// <summary>
        /// set digits zero, and change state to InitialState.
        /// </summary>
        /// <returns> InitialState </returns>
        public IState AddDigitZero()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return this;
        }

        /// <summary>
        /// add left parenthese into Elements.
        /// </summary>
        /// <param name="element"> left parenthese </param>
        /// <returns> this state. </returns>
        public IState AddLeftParenthese(IElement element)
        {
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() + Consts.ONE);
            return this;
        }

        /// <summary>
        /// set digits zero, adding point into digits, and change state to DecimalState.
        /// </summary>
        /// <returns> DecimalState </returns>
        public IState AddPoint()
        {
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
        }

        /// <summary>
        /// add right parenthese into Elements, and change state to RightParentheseState.
        /// </summary>
        /// <param name="element"> right parenthese </param>
        /// <returns> RightParentheseState. </returns>
        public IState AddRightParenthese(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() - Consts.ONE);
            return new RightParentheseState(Memory);
        }

        /// <summary>
        /// in LeftParentheseState user can not remove the last digit.
        /// </summary>
        /// <returns> this state. </returns>
        public IState Backspace()
        {
            return this;
        }

        /// <summary>
        /// change operand's sign.
        /// </summary>
        /// <returns> this state </returns>
        public IState ChangeSign()
        {
            Memory.SetDigits((Convert.ToDecimal(Memory.GetDigits()) * -1).ToString());
            return this;
        }

        /// <summary>
        /// after click equal, add operand into Elements.
        /// </summary>
        /// <param name="computeEnging"> a computingEngine </param>
        /// <returns> EqualState </returns>
        public IState GetResult(IEngine computeEnging)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
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
        /// in LeftParentheseState user can not get Square Root of operand.
        /// </summary>
        /// <returns> this state. </returns>
        public IState SquareRoot()
        {
            return this;
        }

        /// <summary>
        /// reset Digits
        /// </summary>
        /// <returns>InitialState</returns>
        public IState ResetDigits()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }
    }
}