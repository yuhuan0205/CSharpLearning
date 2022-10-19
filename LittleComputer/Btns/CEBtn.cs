namespace LittleComputer.Btns
{
    /// <summary>
    /// a button that delete now number.
    /// </summary>
    public class CEBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickCEBtn();
        }
    }
}