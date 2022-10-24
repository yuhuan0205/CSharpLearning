using CalculatorAPI.Elements;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Controllers
{
    public class CalculatorController : ControllerBase
    {
        private ICalculatorPool CalculatorPool;

        /// <summary>
        /// create a singleton CalculatorPool
        /// </summary>
        /// <param name="_CalculatorPool"></param>
        public CalculatorController(ICalculatorPool _CalculatorPool)
        {
            CalculatorPool = _CalculatorPool;
        }

        [HttpGet("enroll")]
        public int Enroll()
        {
            return CalculatorPool.Enroll();
        }

        [HttpDelete("calculator/{id:int}")]
        public void LogOut(int id)
        {
            CalculatorPool.LogOut(id);
        }

        [HttpGet("status/{id:int}")]
        public string GetStatus(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            return calculator.GetStatus();
        }

        [HttpGet("input/{id:int}/{digit}")]
        public void DigitBtnClick(int id, string digit)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddDigit(digit);
        }

        [HttpGet("inputzero/{id:int}")]
        public void ZeroBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddDigitZero();
        }

        [HttpGet("add/{id:int}")]
        public void AddBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddCalculatedProcess(new Adder());
        }

        [HttpGet("minus/{id:int}")]
        public void MinusBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddCalculatedProcess(new Minuser());
        }

        [HttpGet("multipy/{id:int}")]
        public void MultipyBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddCalculatedProcess(new Multipyer());
        }

        [HttpGet("divide/{id:int}")]
        public void DivideBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddCalculatedProcess(new Divider());
        }

        [HttpGet("backspace/{id:int}")]
        public void BackspaceBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.Backspace();
        }

        [HttpGet("changesign/{id:int}")]
        public void ChangeSignBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.ChangeSign();
        }

        [HttpGet("squareroot/{id:int}")]
        public void SquareRootBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.SquareRoot();
        }

        [HttpGet("point/{id:int}")]
        public void PointBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddPoint();
        }

        [HttpGet("ce/{id:int}")]
        public void CEBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.ResetDigits();
        }


        [HttpGet("c/{id:int}")]
        public void CBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.ResetDigits();
            calculator.ResetCalculatedProcess();
        }


        [HttpGet("getresult/{id:int}")]
        public void EqualBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.GetResult();
        }

        [HttpGet("leftparenthese/{id:int}")]
        public void LeftParentheseBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddLeftParenthese(new LeftParenthese());
        }

        [HttpGet("rightparenthese/{id:int}")]
        public void RightParentheseBtnClick(int id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddRightParenthese(new RightParenthese());
        }
    }
}
