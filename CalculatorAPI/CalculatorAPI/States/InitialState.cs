using CalculatorAPI.Elements;
using CalculatorAPI.Interfaces;
using System;

namespace CalculatorAPI.States
{
    /// <summary>
    /// InitialState is a state implement IState.
    /// </summary>
    public class InitialState : IState
    {
        /// <summary>
        /// a object store data.
        /// </summary>
        private IMemory Memory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="memory"> DI memory </param>
        public InitialState(IMemory memory)
        {
            Memory = memory;
        }

        /// <summary>
        /// add operator into expression, and change state to OperatingState.
        /// </summary>
        /// <param name="element"> operators except divide. </param>
        /// <returns> OperatingState </returns>
        public virtual IState AddOperator(IElement element)
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
        public virtual IState AddOperatorDivide(IElement element)
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
            Memory.AddElement(element);
            return new DivideState(Memory);
        }

        /// <summary>
        /// add digit into digits, and change state to NormalState.
        /// </summary>
        /// <param name="digit">digit</param>
        /// <returns> NormalState </returns>
        public IState AddDigit(string digit)
        {
            Memory.ClearDigits();
            Memory.AddDigit(digit);
            return new NormalState(Memory);
        }

        /// <summary>
        /// in InitialState user can not type zero in this state.
        /// </summary>
        /// <returns> this state. </returns>
        public IState AddDigitZero()
        {
            Memory.SetDigits(Consts.ZERO_STRING);
            return this;
        }

        /// <summary>
        /// add left parenthese into Elements, and change state to LeftParentheseState.
        /// </summary>
        /// <param name="element"> left parenthese </param>
        /// <returns> LeftParentheseState. </returns>
        public virtual IState AddLeftParenthese(IElement element)
        {
            Memory.ClearCalculatedProcess();
            Memory.AddElement(element);
            Memory.SetParentheseCounts(Memory.GetParentheseCounts() + Consts.ONE);
            return new LeftParentheseState(Memory);
        }

        /// <summary>
        /// add point into digits, and change state to DecimalState.
        /// </summary>
        /// <returns> DecimalState </returns>
        public IState AddPoint()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            Memory.AddDigit(Consts.POINT);
            return new DecimalState(Memory);
        }

        /// <summary>
        /// add left parenthese into Elements, and change state to RightParentheseState.
        /// </summary>
        /// <param name="element"> left parenthese </param>
        /// <returns> RightParentheseState. </returns>
        public IState AddRightParenthese(IElement element)
        {
            for (; Memory.GetParentheseCounts() != 0; )
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
        /// in InitialState user can not remove the last digit.
        /// </summary>
        /// <returns> this state. </returns>
        public virtual IState Backspace()
        {
            return this;
        }

        /// <summary>
        /// change operand's sign.
        /// </summary>
        /// <returns> this state </returns>
        public virtual IState ChangeSign()
        {
            Memory.SetDigits((Convert.ToDecimal(Memory.GetDigits()) * -1).ToString());
            return this;
        }

        /// <summary>
        /// after click equal, add operand into Elements.
        /// </summary>
        /// <param name="computeEnging"> a computingEngine </param>
        /// <returns> EqualState </returns>
        public virtual IState GetResult(IEngine computeEnging)
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
        /// get a square root of operand, if root is not a valid number, then change state to ErrorState.
        /// </summary>
        /// <returns> next state. </returns>
        public virtual IState SquareRoot()
        {
            double root = Math.Sqrt(Convert.ToDouble(Memory.GetDigits()));
            for (; root is double.NaN;)
            {
                Memory.ClearCalculatedProcess();
                Memory.SetDigits(Consts.SQUARE_ROOT_WITH_NAGATIVE);
                return new ErrorState(Memory);
            }
            Memory.SetDigits(root.ToString());
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