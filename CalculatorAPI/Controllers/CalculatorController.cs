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
        /// <param name="calculatorPool"></param>
        public CalculatorController(ICalculatorPool calculatorPool)
        {
            CalculatorPool = calculatorPool;
        }

        [HttpGet("enroll")]
        public string Enroll()
        {
            string guid;
            lock (CalculatorPool)
            {
                guid = CalculatorPool.Enroll();
            }
            return guid;
        }

        [HttpDelete("calculator/{id}")]
        public void LogOut(string id)
        {
            CalculatorPool.LogOut(id);
        }

        [HttpGet("status/{id}")]
        public string GetStatus(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            return calculator.GetStatus();
        }

        [HttpGet("input/{id}/{digit}")]
        public void DigitBtnClick(string id, string digit)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddDigit(digit);
        }

        [HttpGet("inputzero/{id}")]
        public void ZeroBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddDigitZero();
        }

        [HttpGet("add/{id}")]
        public void AddBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddCalculatedProcess(new Adder());
        }

        [HttpGet("minus/{id}")]
        public void MinusBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddCalculatedProcess(new Minuser());
        }

        [HttpGet("multipy/{id}")]
        public void MultipyBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddCalculatedProcess(new Multipyer());
        }

        [HttpGet("divide/{id}")]
        public void DivideBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddCalculatedProcess(new Divider());
        }

        [HttpGet("backspace/{id}")]
        public void BackspaceBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.Backspace();
        }

        [HttpGet("changesign/{id}")]
        public void ChangeSignBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.ChangeSign();
        }

        [HttpGet("squareroot/{id}")]
        public void SquareRootBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.SquareRoot();
        }

        [HttpGet("point/{id}")]
        public void PointBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddPoint();
        }

        [HttpGet("ce/{id}")]
        public void CEBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.ResetDigits();
        }


        [HttpGet("c/{id}")]
        public void CBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.ResetDigits();
            calculator.ResetCalculatedProcess();
        }


        [HttpGet("getresult/{id}")]
        public void EqualBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.GetResult();
        }

        [HttpGet("leftparenthese/{id}")]
        public void LeftParentheseBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddLeftParenthese(new LeftParenthese());
        }

        [HttpGet("rightparenthese/{id}")]
        public void RightParentheseBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.AddRightParenthese(new RightParenthese());
        }
    }
}
