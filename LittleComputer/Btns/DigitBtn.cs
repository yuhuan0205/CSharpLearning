namespace LittleComputer
{
    /// <summary>
    /// a button that user can type digits into Computer.
    /// </summary>
    public class DigitBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickDigitBtn(Text);
        }
    }
}
