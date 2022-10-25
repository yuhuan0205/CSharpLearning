namespace CalculatorAPI.Interfaces
{
    /// <summary>
    /// a interface define what things a Engine should implement.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// get the answer from infix.
        /// </summary>
        /// <returns> a message contain answer and calculated process.</returns>
        public MessageObject GetResult();
    }
}
