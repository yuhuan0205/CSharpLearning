
namespace CalculatorAPI.Interfaces
{
    public interface IState
    {
        public IState AddDigit(string digit);
        public IState AddDigitZero();
        public IState AddCalculatedProcess(string Operator);
        public IState Backspace();
        public IState ChangeSign();
        public IState SquareRoot();
        public IState AddPoint();
        public IState AddLeftParenthese();
        public IState AddRightParenthese();
    }
}
