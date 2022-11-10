using System;

namespace AsyncParctice
{
    /// <summary>
    /// The Exceptions will throw when something wrong.
    /// </summary>
    public class CustomReportServiceException : Exception
    {
        /// <summary>
        /// The Exceptions will throw when something wrong.
        /// </summary>
        /// <param name="message"> exception message. </param>
        public CustomReportServiceException(string message) : base(message) 
        {
        }
    }
}