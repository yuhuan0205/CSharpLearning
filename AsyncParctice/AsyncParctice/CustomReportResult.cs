namespace AsyncParctice
{
    /// <summary>
    /// a json like object came from ICustomReportService.
    /// </summary>
    public class CustomReportResult
    {
        /// <summary>
        /// value IsCompleted
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// value IsFaulted
        /// </summary>
        public bool IsFaulted { get; set; }

        /// <summary>
        /// value Signature
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// value Exception
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// value Result
        /// </summary>
        public string Result { get; set; }
    }
}
