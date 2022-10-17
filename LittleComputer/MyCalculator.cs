using System;
using System.Collections.Generic;
using System.Text;

namespace LittleComputer
{
    public class MyCalculator : ICalculator
    {

        private List<IOperators> Operators;

        private List<decimal> Operands;

        private string CalculatedProcess;

        private StringBuilder CalculatedProcessBuilder;

        private string InputNumber;

        private StringBuilder InputNumberBuilder;

        private int NegativeBtnCounts;

        private int PointBtnCounts;

        private int PointIndex;

        private int HeadDigitZero;

        public MyCalculator()
        {
            NegativeBtnCounts = Consts.ZERO;
            PointBtnCounts = Consts.ZERO;
            PointIndex = Consts.ZERO;
            HeadDigitZero = Consts.ZERO;
            InputNumber = Consts.ZERO_STRING;
            CalculatedProcess = Consts.EMPTY_STRING;
            CalculatedProcessBuilder = new StringBuilder();
            InputNumberBuilder = new StringBuilder();
            Operators = new List<IOperators>();
            Operands = new List<decimal>();

        }

        public MessageObject GetStatus()
        {
            return new MessageObject
            {
                InputNumber = InputNumber,
                CalculatedProcess = CalculatedProcess
            };
        }

        // TODO: output 尾數為0的小數
        /// <summary>
        /// do * / first and then do + -
        /// compute all operands and operators in order.
        /// </summary>
        public void GetResult()
        {
            List<decimal> tempListForCalculating = new List<decimal>();
            // do * and / first
            foreach (IOperators Operator in Operators)
            {
                Operator.MultipyOrDivide(Operands, tempListForCalculating);
            }
            tempListForCalculating.Add(Operands[Consts.FIRST_INDEX]);
            Operands = tempListForCalculating;

            // do + and - next.
            foreach (IOperators Operator in Operators)
            {
                Operator.AddOrMinus(Operands);
            }

            //remove all Operators.
            Operators.Clear();

            //the last number is the answer.
            InputNumber = (Operands[Consts.FIRST_INDEX]).ToString();
            Operands.RemoveAt(Consts.FIRST_INDEX);
        }

        /// <summary>
        /// reset all counters.
        /// </summary>
        public void ResetCounters()
        {
            PointIndex = Consts.ZERO;
            PointBtnCounts = Consts.ZERO;
            NegativeBtnCounts = Consts.ZERO;
            HeadDigitZero = Consts.ZERO;
        }

        // TODO: 複數個 0
        public void ClickDigitBtn(string digit)
        {
            //reset
            CalculatedProcess = Consts.EMPTY_STRING;

            //show Number that user typed. 
            for (int headDigit = Convert.ToInt16(digit); headDigit > HeadDigitZero; headDigit = HeadDigitZero)
            {
                InputNumberBuilder.Append(digit);
                InputNumber = InputNumberBuilder.ToString();
                HeadDigitZero --;
            }
        }

        public void ClickOperatorBtn(IOperators operators)
        {
            for (int runTimes = 0; runTimes < InputNumber.Length; runTimes = InputNumber.Length)
            {
                //rest for next input
                Operands.Add(Convert.ToDecimal(InputNumber));
                CalculatedProcessBuilder.Append(InputNumber);

                InputNumberBuilder.Clear();

                ResetCounters();

                CalculatedProcessBuilder.Append(operators.GetSign());
                Operators.Add(operators);
            }
        }

        public void ClickEqualBtn()
        {
            // check InputNumber's Length and only do once.
            for (int inputLength = 0; inputLength < InputNumber.Length; inputLength = InputNumber.Length)
            {
                //add NowNumber to Operands.
                Operands.Add(Convert.ToDecimal(InputNumber));

                //finish a compute process.
                CalculatedProcessBuilder.Append(InputNumber);
                CalculatedProcessBuilder.Append(Consts.EQUAL_SIGN);
                CalculatedProcess = CalculatedProcessBuilder.ToString();

                //reset all StreamBuilders.
                InputNumberBuilder.Clear();
                CalculatedProcessBuilder.Clear();

                //reset Counters 
                ResetCounters();

                //call computer.
                GetResult();
            }
        }

        public void ClickNegativeBtn()
        {
            //insert negative sign.
            for(int headCheck = HeadDigitZero; headCheck < 0; headCheck = 0)
            {
                InputNumberBuilder.Insert(0, Consts.MIMUS_SIGN);
                //NegativeBtnCounts is a odd Number means NowNumber is a negative number, should remove its negative sign. 
                for (int negativeBtnCounts = 0; negativeBtnCounts < (NegativeBtnCounts % 2); negativeBtnCounts++)
                {
                    InputNumberBuilder.Remove(0, 2);
                }
                NegativeBtnCounts ++;
                InputNumber = InputNumberBuilder.ToString();
            }
        }

        //TODO : InputNumberBuilder.Length == 0
        public void ClickBackSpaceBtn()
        {
            // remove the last digit.
            InputNumberBuilder.Remove(InputNumberBuilder.Length - 1, 1);

            // show now number.
            InputNumber = InputNumberBuilder.ToString();

            // when  Computer.NowNumber.Length == 0, turn inputNumber into 0. 
            for (int inputLength = InputNumber.Length; inputLength < 1; inputLength++)
            {
                InputNumber = Consts.ZERO_STRING;
                HeadDigitZero = Consts.ZERO;
            }

            // when remove point, reset PointBtnCounts.
            for (int disdenceOfPoint = InputNumber.Length - PointIndex;
                disdenceOfPoint <= 0; disdenceOfPoint ++)
            {
                PointIndex = Consts.ZERO;
                PointBtnCounts = Consts.ZERO;
            }

        }

        public void ClickCBtn()
        {
            //clear all Compute Process.
            CalculatedProcess = Consts.EMPTY_STRING;
            CalculatedProcessBuilder.Clear();

            //clear now number.
            InputNumber = Consts.ZERO_STRING;
            InputNumberBuilder.Clear();

            //clear all Number we would compute.
            Operands.Clear();
            Operators.Clear();

            ResetCounters();
        }

        public void ClickCEBtn()
        {
            //clear now number.
            InputNumber = Consts.ZERO_STRING;
            InputNumberBuilder.Clear();

            ResetCounters();
        }

        public void ClickPointBtn()
        {
            // there is only one point in a number. 
            for (int counts = PointBtnCounts; counts < 1; counts++)
            {
                // adding zero if there is no digit before point.
                for (int inputLength = InputNumberBuilder.Length; inputLength <= 0; inputLength++)
                {
                    InputNumberBuilder.Append(Consts.ZERO_STRING);
                }
                InputNumberBuilder.Append(Consts.POINT);
                InputNumber = InputNumberBuilder.ToString();
                PointBtnCounts ++;
                PointIndex = InputNumber.Length;
            }
        }

        public void ClickSquareRootBtn()
        {
            InputNumber = Math.Sqrt(Convert.ToDouble(InputNumber)).ToString();
        }
    }
}