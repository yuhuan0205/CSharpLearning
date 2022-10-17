using LittleComputer;
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
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickPointBtn();
        }
    }
}