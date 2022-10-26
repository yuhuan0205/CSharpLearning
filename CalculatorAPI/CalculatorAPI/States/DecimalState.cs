using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;
using System;

namespace CalculatorAPI.States
{
    /// <summary>
    /// DecimalState is a state implement IState.
    /// </summary>
    public class DecimalState : IState
    {
        /// <summary>
        /// a object store data.
        /// </summary>
        private IMemory Memory;

        /// <summary>
        /// a int store the index of point in operand.
        /// </summary>
        private int PointIndex;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="memory"> DI memory </param>
        public DecimalState(IMemory memory)
        {
            Memory = memory;
            PointIndex = 0;
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
        /// add digit into digits.
        /// </summary>
        /// <param name="digit"> digit. </param>
        /// <returns> this state. </returns>
        public IState AddDigit(string digit)
        {
            Memory.AddDigit(digit);
            PointIndex ++;
            return this;
        }

        /// <summary>
        /// add zero into digits
        /// </summary>
        /// <returns> this state. </returns>
        public IState AddDigitZero()
        {
            Memory.AddDigit(Consts.ZERO_STRING);
            PointIndex++;
            return this;
        }

        /// <summary>
        /// add left parenthese into Elements, and change state to LeftParentheseState.
        /// </summary>
        /// <param name="element"> left parenthese </param>
        /// <returns> LeftParentheseState. </returns>
        public IState AddLeftParenthese(IElement element)
        {
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() + Consts.ONE);
            return new LeftParentheseState(Memory);
        }

        /// <summary>
        /// in DecimalState user can not type point.
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
                NumberElement number = new NumberElement(Memory.GetDigits());
                Memory.AddElement(number);
                Memory.AddElement(element);
                Memory.SetParentheseCounts(Memory.GetParentheseCounts() - Consts.ONE);
                return new RightParentheseState(Memory);
            }
            return this;
        }

        /// <summary>
        /// remove the last digit from digits, if point has been remove, then change state to NormalState.
        /// </summary>
        /// <returns> next state. </returns>
        public IState Backspace()
        {
            Memory.RemoveLastDigit();
            for (; PointIndex == 0;)
            {
                for (; Memory.GetDigits() == Consts.ZERO_STRING; )
                {
                    return new InitialState(Memory);
                }

                return new NormalState(Memory);
            }
            PointIndex--;
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