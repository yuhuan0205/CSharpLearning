using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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
        public override void OnClick(ICalculator calculator)
        {
            //check input is empty or not.
            calculator.ClickOperatorBtn(new PlausBtn());
        }

        public string GetSign()
        {
            return Consts.PLAUS_SIGN;
        }

        void IOperators.AddOrMinus(List<decimal> oldOperands)
        {
            decimal firstNumber = oldOperands[Consts.FIRST_INDEX];
            oldOperands.RemoveAt(Consts.FIRST_INDEX);
            oldOperands[Consts.FIRST_INDEX] += firstNumber;
        }

        void IOperators.MultipyOrDivide(List<decimal> oldOperands, List<decimal> newOperands)
        {
            newOperands.Add(oldOperands[Consts.FIRST_INDEX]);
            oldOperands.RemoveAt(Consts.FIRST_INDEX);
        }
    }
}