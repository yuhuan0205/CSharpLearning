using CalculatorAPI.States;
using CalculatorAPI.Inertfaces;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public void AddCalculatedProcess(string Operator)
        {
            State = State.AddCalculatedProcess(Operator);
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
            ICompute computeEnging = new ComputingTree();
            computeEnging.GetResult(Memory.GetCalculatedProcess());
            State = new EqualState(Memory);
        }
    }
}