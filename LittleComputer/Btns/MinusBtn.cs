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
        public override void OnClick(ICalculator calculator)
        {
            //AbstractBtn's vitral function.
            calculator.ClickOperatorBtn(new MinusBtn());
        }
        public string GetSign()
        {
            return Consts.MIMUS_SIGN;
        }

        public void AddOrMinus(List<decimal> oldOperands)
        {
            decimal firstNumber = oldOperands[Consts.FIRST_INDEX];
            oldOperands.RemoveAt(Consts.FIRST_INDEX);
            oldOperands[Consts.FIRST_INDEX] = firstNumber - oldOperands[Consts.FIRST_INDEX];
        }

        public void MultipyOrDivide(List<decimal> oldOperands, List<decimal> newOperands)
        {
            newOperands.Add(oldOperands[Consts.FIRST_INDEX]);
            oldOperands.RemoveAt(Consts.FIRST_INDEX);
        }
    }
}
