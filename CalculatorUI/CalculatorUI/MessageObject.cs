namespace CalculatorUI
{
    /// <summary>
    /// a object that enable calculator transmit its status to winform.
    /// </summary>
    public class MessageObject
    {
        /// <summary>
        /// InputNumber status.
        /// </summary>
        public string InputNumber { get; set; }

        /// <summary>
        /// CalculatedProcess status.
        /// </summary>
        public string CalculatedProcess { get; set; }
    }
}
