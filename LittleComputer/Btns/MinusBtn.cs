using System.Collections.Generic;

namespace LittleComputer
{
    /// <summary>
    /// a button that can add Minus operation into Operators queue.
    /// </summary>
    public class MinusBtn : AbstractBtn, IOperators
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickOperatorBtn(new MinusBtn());
        }

        /// <summary>
        /// return operator's sign.
        /// </summary>
        /// <returns> return "-" </returns>
        public string GetSign()
        {
            return Consts.MIMUS_SIGN;
        }

        /// <summary>
        /// do minus.
        /// </summary>
        /// <param name="originalOperands"> original Operands List </param>
        public void AddOrMinus(List<decimal> originalOperands)
        {
            decimal firstNumber = originalOperands[Consts.FIRST_INDEX];
            originalOperands.RemoveAt(Consts.FIRST_INDEX);
            originalOperands[Consts.FIRST_INDEX] = firstNumber - originalOperands[Consts.FIRST_INDEX];
        }

        /// <summary>
        /// put frist item form originalOperands into newOperands.
        /// </summary>
        /// <param name="originalOperands"> original Operands List </param>
        /// <param name="newOperands"> new Operands List </param>
        public void MultipyOrDivide(List<decimal> originalOperands, List<decimal> newOperands)
        {
            newOperands.Add(originalOperands[Consts.FIRST_INDEX]);
            originalOperands.RemoveAt(Consts.FIRST_INDEX);
        }
    }
}
