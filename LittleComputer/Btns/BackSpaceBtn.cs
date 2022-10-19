namespace LittleComputer.Btns
{
    /// <summary>
    /// a button that delete the last digit of NowNumber.
    /// </summary>
    public class BackSpaceBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="calculator">a calculator implemented ICalculator</param>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickBackSpaceBtn();
        }
    }
}