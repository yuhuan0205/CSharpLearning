using CalculatorAPI.States;
using CalculatorAPI.Interfaces;
using System.Text.Json;
using CalculatorAPI.Elements;

namespace CalculatorAPI
{
    /// <summary>
    /// MyCalculator implements ICalculator, using IMemory and IState to fulfill functions.
    /// </summary>
    public class MyCalculator : ICalculator
    {
        /// <summary>
        /// memory to store operators and operands.
        /// </summary>
        private IMemory Memory;

        /// <summary>
        /// State will change  after click each button.
        /// </summary>
        private IState State;

        /// <summary>
        /// Constructor. loading initial state .
        /// </summary>
        public MyCalculator()
        {
            Memory = new Memory();
            State = new InitialState(Memory);
        }

        /// <summary>
        /// Get calculator's status like answer, calculated process, operand, etc...
        /// </summary>
        /// <returns> return a json formated string. </returns>
        public string GetStatus()
        {
            return JsonSerializer.Serialize( new MessageObject { InputNumber = Memory.GetDigits(), 
                                                                CalculatedProcess = Memory.GetCalculatedProcess() });
        }

        /// <summary>
        /// call State to add digit into operand.
        /// </summary>
        /// <param name="digit"> a digit string </param>
        public void AddDigit(string digit)
        {
            State = State.AddDigit(digit);
        }

        /// <summary>
        /// call State to add zeor digit into operand.
        /// </summary>
        public void AddDigitZero()
        {
            State = State.AddDigitZero();
        }

        /// <summary>
        /// reset operand user typing, and set State initial.
        /// </summary>
        public void ResetDigits()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            State = new InitialState(Memory);
        }

        /// <summary>
        /// call state to add element into memory.
        /// </summary>
        /// <param name="element">add an element which could be operator or operand into memory. </param>
        public void AddCalculatedProcess(IElement element)
        {
            State = State.AddCalculatedProcess(element);
        }

        /// <summary>
        /// reset all status, and set State initail.
        /// </summary>
        public void ResetCalculatedProcess()
        {
            Memory.ClearCalculatedProcess();
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            State =  new InitialState(Memory);
        }

        /// <summary>
        /// call State to remove last digit form operand.
        /// </summary>
        public void Backspace()
        {
            State = State.Backspace();
        }

        /// <summary>
        /// call State to change operand's sign.
        /// </summary>
        public void ChangeSign()
        {
            State = State.ChangeSign();
        }

        /// <summary>
        /// call State do a square root with operand.
        /// </summary>
        public void SquareRoot()
        {
            State = State.SquareRoot();
        }

        /// <summary>
        /// call State to add point into operand.
        /// </summary>
        public void AddPoint()
        {
            State = State.AddPoint();
        }

        /// <summary>
        /// get answer form operators and operands.
        /// </summary>
        public void GetResult()
        {
            State.EqualClick();

            //make all single left parenthese become a pair.
            for (int singleParenthese = Memory.GetParentheseCounts(); singleParenthese > 0; singleParenthese--)
            { 
                Memory.AddElement(new RightParenthese());
            }

            // new a engine to compute
            IEngine computeEnging = new EngineTree(Memory.GetInfix());

            MessageObject message =  computeEnging.GetResult();
            Memory.SetDigits(message.InputNumber);
            Memory.SetCalculatedProcess(message.CalculatedProcess);
            Memory.SetParentheseCounts(0);
            State = new EqualState(Memory);
        }

        /// <summary>
        /// call State to add left parrnthese into operators.
        /// </summary>
        /// <param name="element">a LeftParenthese element</param>
        public void AddLeftParenthese(IElement element)
        {
            State = State.AddLeftParenthese(element);
        }

        /// <summary>
        /// call State to add right parrnthese into operators.
        /// </summary>
        /// <param name="element">a RightParenthese element</param>
        public void AddRightParenthese(IElement element)
        {
            State = State.AddRightParenthese(element);
        }
    }
}