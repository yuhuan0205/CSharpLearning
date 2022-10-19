using System;
using System.Collections.Generic;
using System.Text;

namespace LittleComputer
{
    /// <summary>
    /// MyCalculator class implements ICalculator.
    /// </summary>
    public class MyCalculator : ICalculator
    {
        /// <summary>
        /// a List contains 4 types Operator.
        /// </summary>
        private List<IOperators> Operators;

        /// <summary>
        /// a List contains Operands.
        /// </summary>
        private List<decimal> Operands;

        /// <summary>
        /// a string recorded calculated process.
        /// </summary>
        private string CalculatedProcess;

        /// <summary>
        /// a StringBuilder to build calculated process.
        /// </summary>
        private StringBuilder CalculatedProcessBuilder;

        /// <summary>
        /// a string recorded input number.
        /// </summary>
        private string InputNumber;

        /// <summary>
        /// a StringBuilder to build input number.
        /// </summary>
        private StringBuilder InputNumberBuilder;

        /// <summary>
        /// a counter counts how many times which PointBtn is clicked.
        /// </summary>
        private int PointBtnCounts;

        /// <summary>
        /// a index recorded the place of the point in the intput number.
        /// </summary>
        private int PointIndex;

        /// <summary>
        /// a int like a bool to control flow.
        /// LOCK means can not type zero.
        /// UNLOCK means the can type zero.
        /// </summary>
        private int ZeroLock;

        /// <summary>
        /// a int like a bool to control flow.
        /// FALSE means user has not cliked EqualBtn.
        /// TRUE means user just cliked EqualBtn.
        /// </summary>
        private int IsAfterEqual;

        /// <summary>
        /// a int like a bool to control flow.
        /// FALSE means user has not cliked OperatorsBtn.
        /// TRUE means user just cliked OperatorsBtn.
        /// </summary>
        private int IsAfterOperators;

        /// <summary>
        /// Constructor to initialize object members.
        /// </summary>
        public MyCalculator()
        {
            //counters
            PointBtnCounts = Consts.ZERO;
            PointIndex = Consts.ZERO;
            
            //conditions
            ZeroLock = Consts.LOCKED;
            IsAfterEqual = Consts.FALSE;
            IsAfterOperators = Consts.FALSE;
            
            //storage data
            InputNumber = Consts.ZERO_STRING;
            CalculatedProcess = Consts.EMPTY_STRING;
            CalculatedProcessBuilder = new StringBuilder();
            InputNumberBuilder = new StringBuilder();
            Operators = new List<IOperators>();
            Operands = new List<decimal>();
        }

        /// <summary>
        /// get calcultor's current status which contains input and calculated process.
        /// </summary>
        /// <returns>a message to render winform.</returns>
        public MessageObject GetStatus()
        {
            return new MessageObject
            {
                InputNumber = InputNumber,
                CalculatedProcess = CalculatedProcess
            };
        }

        /// <summary>
        /// compute all operands and operators in order.
        /// do * and / first, then do + and - .
        /// </summary>
        public void GetResult()
        {
            // a temporary List to store operands.
            List<decimal> tempListForCalculating = new List<decimal>();

            // do * and / first
            foreach (IOperators Operator in Operators)
            {
                Operator.MultipyOrDivide(Operands, tempListForCalculating);
            }

            //add last operand form original List to tempList.
            tempListForCalculating.Add(Operands[Consts.FIRST_INDEX]);

            //assign Operands tempList.
            Operands = tempListForCalculating;

            // do + and - .
            foreach (IOperators Operator in Operators)
            {
                Operator.AddOrMinus(Operands);
            }

            //remove all Operators.
            Operators.Clear();

            //the first item in Operands is the answer.
            decimal answer = Operands[Consts.FIRST_INDEX];

            //check that if the digits after point are all zero. 
            double digitsAfterPoint = (Convert.ToDouble(answer) % 1);

            // if they are all zero, remaing the number before point.
            for (int isZero = 0; isZero == digitsAfterPoint; isZero++)
            {
                answer = Convert.ToInt64(answer - (answer % 1));
            }

            // change status
            InputNumber = answer.ToString();
            
            //remove answer from Operands.
            Operands.RemoveAt(Consts.FIRST_INDEX);
        }

        /// <summary>
        /// reset all counters.
        /// </summary>
        public void ResetCounters()
        {
            PointIndex = Consts.ZERO;
            PointBtnCounts = Consts.ZERO;

            ZeroLock = Consts.LOCKED;
            IsAfterEqual = Consts.FALSE;
            IsAfterOperators = Consts.FALSE;
        }

        /// <summary>
        /// put digit into InputNumber and InputNumberBuilder.
        /// </summary>
        /// <param name="digit"> a digit on the button, AKA button's Text. </param>
        public void ClickDigitBtn(string digit)
        {
            //after click Equal, clear all status
            for (int isAfterEqual = IsAfterEqual; isAfterEqual == Consts.TRUE; isAfterEqual = Consts.FALSE)
            {
                ClickCBtn();
            }

            //after click operators,  clear input.
            for (int isAfterOperators = IsAfterOperators; isAfterOperators == Consts.TRUE; isAfterOperators = Consts.FALSE)
            {
                ClickCEBtn();
            }

            //show Number that user typed.
            //And DO NOT type multiple zero on digits' head only if user are typing a float. 
            for (int inputDigit = Convert.ToInt16(digit); inputDigit != ZeroLock; inputDigit = ZeroLock)
            {
                InputNumberBuilder.Append(digit);
                InputNumber = InputNumberBuilder.ToString();
                ZeroLock  = Consts.UNLOCKED;
            }
        }

        /// <summary>
        /// put InputNumber into Operands, and put Operator into Operators.
        /// Then add a calculated process into CalculatedProcess.
        /// </summary>
        /// <param name="Operator"> a OperatorsBtn </param>
        public void ClickOperatorBtn(IOperators Operator)
        {
            //change operator.
            for (int isAfterOperators = IsAfterOperators; isAfterOperators == Consts.TRUE; isAfterOperators = Consts.FALSE)
            {
                //adding calculated process
                CalculatedProcessBuilder.Remove( CalculatedProcess.Length - 1, 1);
                CalculatedProcessBuilder.Append( Operator.GetSign() );
                CalculatedProcess = CalculatedProcessBuilder.ToString();

                Operators.RemoveAt(Operators.Count - 1);
                Operators.Add(Operator);
            }

            //first type operator.
            for (int isAfterOperators = IsAfterOperators; isAfterOperators == Consts.FALSE; isAfterOperators = Consts.TRUE)
            {
                //adding Operand
                Operands.Add(Convert.ToDecimal(InputNumber));

                //adding Operator
                Operators.Add(Operator);

                //adding calculated process
                CalculatedProcessBuilder.Append(InputNumber);
                CalculatedProcessBuilder.Append(Operator.GetSign());
                CalculatedProcess = CalculatedProcessBuilder.ToString();

                //reset
                InputNumberBuilder.Clear();
                ResetCounters();
                IsAfterOperators = Consts.TRUE;
            }
        }

        /// <summary>
        /// get a result from Operand and Operators, and then reset all status.
        /// </summary>
        public void ClickEqualBtn()
        {
            // make sure InputNumber's Length > 0.
            for (int inputLength = 0; inputLength < InputNumber.Length; inputLength = InputNumber.Length)
            {
                // add last inputNumber into Operands.
                Operands.Add(Convert.ToDecimal(InputNumber));

                //finish a compute process.
                CalculatedProcessBuilder.Append(InputNumber);
                CalculatedProcessBuilder.Append(Consts.EQUAL_SIGN);
                CalculatedProcess = CalculatedProcessBuilder.ToString();
                CalculatedProcessBuilder.Clear();

                //reset all Counters and set IsAfterEqual TRUE.
                ResetCounters();
                IsAfterEqual = Consts.TRUE;

                //call calculate function.
                GetResult();

                //load answer into InputNumberBuilder for next computing.
                InputNumberBuilder.Clear();
                InputNumberBuilder.Append(InputNumber);
            }
        }

        /// <summary>
        /// change number's sign.
        /// </summary>
        public void ClickNegativeBtn()
        {
            //record inputNumber's status.
            decimal numberSign = Convert.ToDecimal(InputNumber) * (1 / Math.Abs( Convert.ToDecimal( InputNumber)));
            long NumberStatus = Convert.ToInt64(numberSign);

            //check and insert negative sign.
            for (long numberStatus = NumberStatus; numberStatus > 0; numberStatus = 0)
            {
                InputNumberBuilder.Insert(0, Consts.MIMUS_SIGN);
                InputNumber = InputNumberBuilder.ToString();
            }
            //check and remove negative sign.
            for (long numberStatus = NumberStatus; numberStatus < 0; numberStatus = 0)
            {
                InputNumberBuilder.Remove(0, 1);
                InputNumber = InputNumberBuilder.ToString();
            }
        }
        
        /// <summary>
        /// remove last digit.
        /// </summary>
        public void ClickBackSpaceBtn()
        {
            // remove the last digit.
            for (int inputLength = InputNumberBuilder.Length; inputLength > 0; inputLength = 0)
            {
                InputNumberBuilder.Remove(InputNumber.Length - 1, 1);
                InputNumber = InputNumberBuilder.ToString();
            }

            // when  Computer.NowNumber.Length == 0, turn inputNumber into 0. 
            for (int inputLength = InputNumber.Length; inputLength < 1; inputLength++)
            {
                InputNumber = Consts.ZERO_STRING;
                ZeroLock = Consts.LOCKED;
            }

            // when remove point, reset PointBtnCounts.
            for (int disdenceOfPoint = InputNumber.Length - PointIndex;
                disdenceOfPoint <= 0; disdenceOfPoint ++)
            {
                PointIndex = Consts.ZERO;
                PointBtnCounts = Consts.ZERO;
            }
        }

        /// <summary>
        /// reset all status.
        /// </summary>
        public void ClickCBtn()
        {
            //clear all Calculated Process.
            CalculatedProcess = Consts.EMPTY_STRING;
            CalculatedProcessBuilder.Clear();

            //clear inputNumber.
            InputNumber = Consts.ZERO_STRING;
            InputNumberBuilder.Clear();

            //clear all Operands and Operators we would calculate.
            Operands.Clear();
            Operators.Clear();

            //reset counters.
            ResetCounters();
        }

        /// <summary>
        /// reset inputNumber.
        /// </summary>
        public void ClickCEBtn()
        {
            //clear input number.
            InputNumber = Consts.ZERO_STRING;
            InputNumberBuilder.Clear();

            //reset counters.
            ResetCounters();
        }

        /// <summary>
        /// add point to inputNumber.
        /// </summary>
        public void ClickPointBtn()
        {
            // after equal, clear all status
            for (int isAfterEqual = IsAfterEqual; isAfterEqual == Consts.TRUE; isAfterEqual = Consts.FALSE )
            {
                ClickCBtn();
            }

            //if there is no digit.
            for (int inputLength = InputNumberBuilder.Length; inputLength <= 0; inputLength++)
            {
                InputNumberBuilder.Append(Consts.ZERO_STRING);
                InputNumberBuilder.Append(Consts.POINT);
                PointBtnCounts++;
                PointIndex = InputNumber.Length;

                // enable DigitBtn can type multiple Zero.
                ZeroLock = Consts.UNLOCKED;
            }

            //check inputNumber is float or int
            double NumberStatus = ( Convert.ToDouble( InputNumber ) % 1 ) + PointBtnCounts;
            for (int isInt = 0; isInt == NumberStatus; isInt++)
            {
                InputNumberBuilder.Append(Consts.POINT);
                PointBtnCounts++;
                PointIndex = InputNumber.Length;
            }
            InputNumber = InputNumberBuilder.ToString();
        }

        /// <summary>
        /// do square root.
        /// </summary>
        public void ClickSquareRootBtn()
        {
            InputNumber = Math.Sqrt(Convert.ToDouble(InputNumber)).ToString();
        }
    }
}