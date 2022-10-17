using System;
using System.Collections.Generic;
using System.Text;

namespace LittleComputer.Btns
{
    public class SquareRootBtn : AbstractBtn
    {
        public override void OnClick(ICalculator calculator)
        {
            calculator.ClickSquareRootBtn();
        }
    }
}
