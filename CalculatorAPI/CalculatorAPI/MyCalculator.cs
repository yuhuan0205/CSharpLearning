using CalculatorAPI.States;
using CalculatorAPI.Interfaces;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using CalculatorAPI.Elements;

namespace CalculatorAPI
{
    public class MyCalculator : ICalculator
    {
        private IMemory Memory;

        private IState State;

        public MyCalculator()
        {
            Memory = new Memory();
            State = new InitialState(Memory);
        }

        public string GetStatus()
        {
            return JsonSerializer.Serialize( new MessageObject { InputNumber = Memory.GetDigits(), 
                                                                CalculatedProcess = Memory.GetCalculatedProcess() });
        }

        public void AddDigit(string digit)
        {
            State = State.AddDigit(digit);
        }

        public void AddDigitZero()
        {
            State = State.AddDigitZero();
        }

        public void ResetDigits()
        {
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            State = new InitialState(Memory);
        }

        public void AddCalculatedProcess(IElement element)
        {
            State = State.AddCalculatedProcess(element);
        }

        public void ResetCalculatedProcess()
        {
            Memory.ClearCalculatedProcess();
            Memory.ClearDigits();
            Memory.AddDigit(Consts.ZERO_STRING);
            State =  new InitialState(Memory);
        }

        public void Backspace()
        {
            State = State.Backspace();
        }

        public void ChangeSign()
        {
            State = State.ChangeSign();
        }

        public void SquareRoot()
        {
            State = State.SquareRoot();
        }

        public void AddPoint()
        {
            State = State.AddPoint();
        }

        public void GetResult()
        {
            NumberElement number = new NumberElement(Memory.GetDigits());
            Memory.AddElement(number);
            IEngine computeEnging = new EngineTree(Memory.GetInfix());
            MessageObject message =  computeEnging.GetResult();
            Memory.SetDigits(message.InputNumber);
            Memory.SetCalculatedProcess(message.CalculatedProcess);
            State = new EqualState(Memory);
        }

        public void AddLeftParenthese(IElement element)
        {
            State = State.AddLeftParenthese(element);
        }

        public void AddRightParenthese(IElement element)
        {
            State = State.AddRightParenthese(element);
        }
    }
}