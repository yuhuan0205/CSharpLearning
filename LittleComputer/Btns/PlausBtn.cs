using System.Collections.Generic;

namespace LittleComputer
{
    /// <summary>
    /// a button that can add Plaus operation into Operators queue.
    /// </summary>
    public class PlausBtn : AbstractBtn, IOperators
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickOperatorBtn(new PlausBtn());
        }

        /// <summary>
        /// return operator's sign.
        /// </summary>
        /// <returns> return "+" </returns>
        public string GetSign()
        {
            return Consts.PLAUS_SIGN;
        }

        /// <summary>
        /// do add.
        /// </summary>
        /// <param name="originalOperands"> original Operands List </param>
        void IOperators.AddOrMinus(List<decimal> originalOperands)
        {
            decimal firstNumber = originalOperands[Consts.FIRST_INDEX];
            originalOperands.RemoveAt(Consts.FIRST_INDEX);
            originalOperands[Consts.FIRST_INDEX] += firstNumber;
        }

        /// <summary>
        /// put frist item form originalOperands into newOperands.
        /// </summary>
        /// <param name="originalOperands"> original Operands List </param>
        /// <param name="newOperands"> new Operands List </param>
        void IOperators.MultipyOrDivide(List<decimal> originalOperands, List<decimal> newOperands)
        {
            newOperands.Add(originalOperands[Consts.FIRST_INDEX]);
            originalOperands.RemoveAt(Consts.FIRST_INDEX);
        }
    }
}