
namespace CalculatorAPI.Interfaces
{
    public interface IState
    {
        public IState AddDigit(string digit);
        public IState AddDigitZero();
        public IState AddCalculatedProcess(IElement element);
        public IState Backspace();
        public IState ChangeSign();
        public IState SquareRoot();
        public IState AddPoint();
        public IState AddLeftParenthese(IElement element);
        public IState AddRightParenthese(IElement element);
        public void EqualClick();
    }
}
