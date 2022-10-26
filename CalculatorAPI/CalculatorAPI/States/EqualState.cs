using System;
using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.States
{
    /// <summary>
    /// EqualState is a state implement IState.
    /// </summary>
    public class EqualState : IState
    {
        /// <summary>
        /// a object store data.
        /// </summary>
        private IMemory Memory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="memory"> DI memory </param>
        public EqualState(IMemory memory)
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
            Memory.ClearCalculatedProcess();
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
        /// <returns>NormalState.</returns>
        public IState AddDigit(string digit)
        {
            Memory.ClearCalculatedProcess();
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
            Memory.ClearCalculatedProcess();
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            return new InitialState(Memory);
        }

        /// <summary>
        /// add left parenthese into Elements, and change state to LeftParentheseState.
        /// </summary>
        /// <param name="element"> left parenthese </param>
        /// <returns> LeftParentheseState. </returns>
        public IState AddLeftParenthese(IElement element)
        {
            Memory.ClearCalculatedProcess();
            Memory.ClearDigits();
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() + Consts.ONE);
            return new LeftParentheseState(Memory);
        }

        /// <summary>
        /// set digits zero, adding point into digits, and change state to DecimalState.
        /// </summary>
        /// <returns> DecimalState </returns>
        public IState AddPoint()
        {
            Memory.ClearCalculatedProcess();
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
        }

        /// <summary>
        /// in EqualState, user can not type right parenthese 
        /// </summary>
        /// <param name="element"> right parenthese </param>
        /// <returns> this state </returns>
        public IState AddRightParenthese(IElement element)
        {
            return this;
        }

        /// <summary>
        /// clear all status, and change state to InitialState.
        /// </summary>
        /// <returns> InitialState </returns>
        public IState Backspace()
        {
            Memory.ClearCalculatedProcess();
            return new InitialState(Memory);
        }

        /// <summary>
        /// change operand's sign, and change state to InitialState.
        /// </summary>
        /// <returns> InitialState </returns>
        public IState ChangeSign()
        {
            Memory.SetDigits((Convert.ToDecimal(Memory.GetDigits()) * -1).ToString());
            return new InitialState(Memory);
        }

        /// <summary>
        /// after click equal, add operand into Elements.
        /// </summary>
        public void EqualClick()
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
        }

        /// <summary>
        /// get a square root of operand, if root is not a valid number, then change state to ErrorState.
        /// </summary>
        /// <returns> next state. </returns>
        public IState SquareRoot()
        {
            double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            for (; root is double.NaN;)
            {
                Memory.ClearCalculatedProcess();
                Memory.SetDigits(Consts.SQUARE_ROOT_WITH_NAGATIVE);
                return new ErrorState(Memory);
            }
            Memory.SetDigits(root.ToString());
            return new InitialState(Memory);
        }
    }
}