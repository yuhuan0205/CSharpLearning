namespace LittleComputer.Btns
{
    /// <summary>
    /// add point to number.
    /// </summary>
    public class PointBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickPointBtn();
        }
    }
}