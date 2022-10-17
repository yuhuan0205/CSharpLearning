using System;

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
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickDigitBtn(ButtonText);
        }
    }
}
