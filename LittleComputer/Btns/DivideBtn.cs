using System.Collections.Generic;

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
        public override void OnClick(ICalculator calculator)
        {
            //AbstractBtn's vitral function.
            calculator.ClickOperatorBtn(new DivideBtn());
        }
        public string GetSign()
        {
            return Consts.DIVIDE_SIGN;
        }

        public void AddOrMinus(List<decimal> oldOperands)
        {

        }

        public void MultipyOrDivide(List<decimal> oldOperands, List<decimal> newOperands)
        {
            decimal firstNumber = oldOperands[Consts.FIRST_INDEX];
            oldOperands.RemoveAt(Consts.FIRST_INDEX);
            try
            {
                oldOperands[Consts.FIRST_INDEX] = firstNumber / oldOperands[Consts.FIRST_INDEX];
            }
            catch (System.DivideByZeroException)
            {
                //MessageBox.Show("DivideByZeroException", "try divide by zero.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                oldOperands[Consts.FIRST_INDEX] = firstNumber / 1;
            }
        }
    }
}
