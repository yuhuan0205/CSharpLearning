using System.Collections.Generic;

namespace LittleComputer.Btns
{
    /// <summary>
    /// a button that can add Multiply operation into Operators queue.
    /// </summary>
    public class MultiplyBtn : AbstractBtn, IOperators
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickOperatorBtn(new MultiplyBtn());
        }

        /// <summary>
        /// return operator's sign.
        /// </summary>
        /// <returns> return "*" </returns>
        public string GetSign()
        {
            return Consts.MULTIPLY_SIGN;
        }

        /// <summary>
        /// do nothing here.
        /// </summary>
        /// <param name="originalOperands"> original Operands List </param>
        void IOperators.AddOrMinus(List<decimal> originalOperands)
        {
        }

        /// <summary>
        /// do multipy.
        /// </summary>
        /// <param name="originalOperands"> original Operands List </param>
        /// <param name="newOperands"> new Operands List for output </param>
        void IOperators.MultipyOrDivide(List<decimal> originalOperands, List<decimal> newOperands)
        {
            decimal firstNumber = originalOperands[Consts.FIRST_INDEX];
            originalOperands.RemoveAt(Consts.FIRST_INDEX);
            originalOperands[Consts.FIRST_INDEX] = firstNumber * originalOperands[Consts.FIRST_INDEX];
        }
    }
}