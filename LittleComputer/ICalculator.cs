namespace LittleComputer
{
    /// <summary>
    /// a interface that any Calculator should implement follow functions.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// get calcultor's current status which contains input and calculated process.
        /// </summary>
        /// <returns>a message to render winform.</returns>
        public abstract MessageObject GetStatus();

        /// <summary>
        /// put InputNumber into Operands, and put Operator into Operators.
        /// Then add a calculated process into CalculatedProcess.
        /// </summary>
        /// <param name="Operator"> a OperatorsBtn </param>
        public abstract void ClickOperatorBtn(IOperators Operator);

        /// <summary>
        /// put digit into InputNumber and InputNumberBuilder.
        /// </summary>
        /// <param name="digit"> a digit on the button, AKA button's Text. </param>
        public abstract void ClickDigitBtn(string digit);

        /// <summary>
        /// get a result from Operand and Operators, and then reset all status.
        /// </summary>
        public abstract void ClickEqualBtn();

        /// <summary>
        /// change number's sign.
        /// </summary>
        public abstract void ClickNegativeBtn();

        /// <summary>
        /// remove last digit.
        /// </summary>
        public abstract void ClickBackSpaceBtn();

        /// <summary>
        /// reset all status.
        /// </summary>
        public abstract void ClickCBtn();

        /// <summary>
        /// reset inputNumber.
        /// </summary>
        public abstract void ClickCEBtn();

        /// <summary>
        /// add point to inputNumber.
        /// </summary>
        public abstract void ClickPointBtn();

        /// <summary>
        /// do square root.
        /// </summary>
        public abstract void ClickSquareRootBtn();
    }
}
