using LittleComputer;
namespace LittleComputer.Btns
{
    /// <summary>
    /// change the negative and postive sign.
    /// </summary>
    public class NegativeBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickNegativeBtn();
        }
    }
}