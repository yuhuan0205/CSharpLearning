using LittleComputer;

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
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickBackSpaceBtn();
        }
    }
}