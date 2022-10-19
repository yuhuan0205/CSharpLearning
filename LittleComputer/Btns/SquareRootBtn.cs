namespace LittleComputer.Btns
{
    /// <summary>
    /// do square root to number.
    /// </summary>
    public class SquareRootBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickSquareRootBtn();
        }
    }
}
