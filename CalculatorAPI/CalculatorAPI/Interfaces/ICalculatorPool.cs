namespace CalculatorAPI
{
    /// <summary>
    /// a interface define what things a CalculatorPool should implement.
    /// </summary>
    public interface ICalculatorPool
    {
        /// <summary>
        /// enroll in poll.
        /// </summary>
        /// <returns> user's id </returns>
        public string Enroll();

        /// <summary>
        /// get calculator instence by user's id.
        /// </summary>
        /// <param name="id"> user's id </param>
        /// <returns></returns>
        public ICalculator GetCalculatorById(string id);

        /// <summary>
        /// remove calculator instence by user's id.
        /// </summary>
        /// <param name="id"> user's id </param>
        public void LogOut(string id);
    }
}