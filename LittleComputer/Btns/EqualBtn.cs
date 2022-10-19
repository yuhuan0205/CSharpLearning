namespace LittleComputer
{
    /// <summary>
    /// a button that call Computer object to compute all operands and operators in order.
    /// And reset some Computer's parameter.
    /// </summary>
    public class EqualBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickEqualBtn();
        }
    }
}