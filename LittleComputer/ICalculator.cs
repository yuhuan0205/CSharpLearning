namespace LittleComputer
{
    public interface  ICalculator
    {
        public abstract MessageObject GetStatus();

        public abstract void ClickOperatorBtn(IOperators operators);
        public abstract void ClickDigitBtn(string digit);
        public abstract void ClickEqualBtn();
        public abstract void ClickNegativeBtn();
        public abstract void ClickBackSpaceBtn();
        public abstract void ClickCBtn();
        public abstract void ClickCEBtn();
        public abstract void ClickPointBtn();
        public abstract void ClickSquareRootBtn();
    }
}
