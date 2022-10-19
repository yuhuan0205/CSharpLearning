using System.Collections.Generic;
using System.Windows.Forms;

namespace LittleComputer.Btns
{
    /// <summary>
    /// a button that can add Multiply operation into Operators queue.
    /// </summary>
    public class DivideBtn : AbstractBtn, IOperators
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickOperatorBtn(new DivideBtn());
        }

        /// <summary>
        /// return operator's sign.
        /// </summary>
        /// <returns> return "/" </returns>
        public string GetSign()
        {
            return Consts.DIVIDE_SIGN;
        }

        /// <summary>
        /// do nothing here.
        /// </summary>
        /// <param name="oldOperands"> original Operands List </param>
        public void AddOrMinus(List<decimal> oldOperands)
        {
        }

        /// <summary>
        /// do divide.
        /// </summary>
        /// <param name="originalOperands"> original Operands List </param>
        /// <param name="newOperands"> new Operands List for output </param>
        public void MultipyOrDivide(List<decimal> originalOperands, List<decimal> newOperands)
        {
            decimal firstNumber = originalOperands[Consts.FIRST_INDEX];
            originalOperands.RemoveAt(Consts.FIRST_INDEX);
            try
            {
                originalOperands[Consts.FIRST_INDEX] = firstNumber / originalOperands[Consts.FIRST_INDEX];
            }
            catch (System.DivideByZeroException)
            {
                MessageBox.Show("DivideByZeroException", "DO NOT divide by zero.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                originalOperands[Consts.FIRST_INDEX] = firstNumber / 1;
            }
        }
    }
}