using System;
using System.Collections.Generic;
using System.Text;

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
        public override void OnClick(ICalculator calculator)
        {
            //AbstractBtn's vitral function.
            calculator.ClickOperatorBtn(new MultiplyBtn());
        }
        public string GetSign()
        {
            return Consts.MULTIPLY_SIGN;
        }

        void IOperators.AddOrMinus(List<decimal> oldOperands)
        {

        }

        void IOperators.MultipyOrDivide(List<decimal> oldOperands, List<decimal> newOperands)
        {
            decimal firstNumber = oldOperands[Consts.FIRST_INDEX];
            oldOperands.RemoveAt(Consts.FIRST_INDEX);
            oldOperands[Consts.FIRST_INDEX] = firstNumber * oldOperands[Consts.FIRST_INDEX];
        }
    }
}
