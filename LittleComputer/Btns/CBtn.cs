namespace LittleComputer.Btns
{
    /// <summary>
    /// a button that delete all status.
    /// </summary>
    public class CBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickCBtn();
        }
    }
}