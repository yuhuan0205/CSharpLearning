using LittleComputer;
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
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickCEBtn();
        }
    }
}