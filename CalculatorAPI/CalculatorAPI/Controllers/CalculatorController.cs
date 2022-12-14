using CalculatorAPI.Elements;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    /// <summary>
    /// my CalculatorController inherits ControllerBase.
    /// </summary>
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// CalculatorPool contains lots of calculators.
        /// </summary>
        private readonly ICalculatorPool CalculatorPool;

        /// <summary>
        /// create a singleton CalculatorPool with DI.
        /// </summary>
        /// <param name="calculatorPool">DI from service</param>
        public CalculatorController(ICalculatorPool calculatorPool)
        {
            CalculatorPool = calculatorPool;
        }

        /// <summary>
        /// enroll in CalculatorPool and get a userid.
        /// </summary>
        /// <returns> user's id </returns>
        [HttpGet("enroll")]
        public string Enroll()
        {
            return CalculatorPool.Enroll();
        }

        /// <summary>
        /// delete user's calculator instence.
        /// </summary>
        /// <param name="id"> user's id</param>
        [HttpDelete("calculator/{id}")]
        public void LogOut(string id)
        {
            CalculatorPool.LogOut(id);
        }

        /// <summary>
        /// get calculator's status by user's id.
        /// </summary>
        /// <param name="id"> user's id</param>
        /// <returns> calculator's status </returns>
        [HttpGet("status/{id}")]
        public string GetStatus(string id)
        {
            return CalculatorPool.GetCalculatorById(id).GetStatus();
        }

        /// <summary>
        /// add a digit into specific calculator operand.
        /// </summary>
        /// <param name="id"> user's id </param>
        /// <param name="digit">a digit is going to add into operand </param>
        [HttpGet("input/{id}/{digit}")]
        public void DigitBtnClick(string id, string digit)
        {
            CalculatorPool.GetCalculatorById(id).AddDigit(digit);
        }

        /// <summary>
        /// add a zero digit into specific calculator operand.
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("inputzero/{id}")]
        public void ZeroBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).AddDigitZero();
        }

        /// <summary>
        /// add a add operator into specific calculator. 
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("add/{id}")]
        public void AddBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).AddOperator(new Adder());
        }

        /// <summary>
        /// add a miuns operator into specific calculator. 
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("minus/{id}")]
        public void MinusBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).AddOperator(new Minuser());
        }

        /// <summary>
        /// add a multipy operator into specific calculator. 
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("multipy/{id}")]
        public void MultipyBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).AddOperator(new Multipyer());
        }

        /// <summary>
        /// add a divide operator into specific calculator. 
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("divide/{id}")]
        public void DivideBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).AddOperatorDivide(new Divider());
        }

        /// <summary>
        /// remove the last digit form specific calculator's operand. 
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("backspace/{id}")]
        public void BackspaceBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).Backspace();
        }

        /// <summary>
        /// change the sign of specific calculator's operand. 
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("changesign/{id}")]
        public void ChangeSignBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).ChangeSign();
        }

        /// <summary>
        /// get a square root of operand from specific calculator.  
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("squareroot/{id}")]
        public void SquareRootBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).SquareRoot();
        }

        /// <summary>
        /// add point into specific calculator's operand.  
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("point/{id}")]
        public void PointBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).AddPoint();
        }

        /// <summary>
        /// reset operand from specific calculator.  
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("ce/{id}")]
        public void CEBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).ResetDigits();
        }

        /// <summary>
        /// reset all status from specific calculator.  
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("c/{id}")]
        public void CBtnClick(string id)
        {
            ICalculator calculator = CalculatorPool.GetCalculatorById(id);
            calculator.ResetDigits();
            calculator.ResetCalculatedProcess();
        }

        /// <summary>
        /// get answer from specific calculator's calculated process.  
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("getresult/{id}")]
        public void EqualBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).GetResult();
        }

        /// <summary>
        /// add left parenthese into specific calculator's calculated process.  
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("leftparenthese/{id}")]
        public void LeftParentheseBtnClick(string id)
        {
           CalculatorPool.GetCalculatorById(id).AddLeftParenthese(new LeftParenthese());
        }

        /// <summary>
        /// add right parenthese into specific calculator's calculated process.  
        /// </summary>
        /// <param name="id"> user's id </param>
        [HttpGet("rightparenthese/{id}")]
        public void RightParentheseBtnClick(string id)
        {
            CalculatorPool.GetCalculatorById(id).AddRightParenthese(new RightParenthese());
        }
    }
}