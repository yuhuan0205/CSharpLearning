namespace CalculatorAPI.Interfaces
{
    /// <summary>
    /// a interface define what things a State should implement.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// add digit into digits.
        /// </summary>
        /// <param name="digit"> a digit expect zero. </param>
        /// <returns> next state. </returns>
        public IState AddDigit(string digit);

        /// <summary>
        /// add zero into digits
        /// </summary>
        /// <returns> next state. </returns>
        public IState AddDigitZero();

        /// <summary>
        /// add operator into expression.
        /// </summary>
        /// <param name="element"> operators except divide. </param>
        /// <returns> next state. </returns>
        public IState AddOperator(IElement element);

        /// <summary>
        /// add divide into expression.
        /// </summary>
        /// <param name="element"> divide. </param>
        /// <returns> next state. </returns>
        public IState AddOperatorDivide(IElement element);

        /// <summary>
        /// remove the last digit from digits.
        /// </summary>
        /// <returns> next state. </returns>
        public IState Backspace();

        /// <summary>
        /// change operand's sign.
        /// </summary>
        /// <returns> next state. </returns>
        public IState ChangeSign();

        /// <summary>
        /// get a square root of operand.
        /// </summary>
        /// <returns> next state. </returns>
        public IState SquareRoot();

        /// <summary>
        /// add a point into digits.
        /// </summary>
        /// <returns> next state. </returns>
        public IState AddPoint();

        /// <summary>
        /// add left parenthese into Elements.
        /// </summary>
        /// <param name="element"> left parenthese </param>
        /// <returns> next state. </returns>
        public IState AddLeftParenthese(IElement element);

        /// <summary>
        /// add right parenthese into Elements.
        /// </summary>
        /// <param name="element"> right parenthese </param>
        /// <returns> next state. </returns>
        public IState AddRightParenthese(IElement element);

        /// <summary>
        /// after click equal.
        /// </summary>
        public void EqualClick();
    }
}
