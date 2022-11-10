using System.Threading.Tasks;

namespace AsyncParctice
{
    /// <summary>
    /// a interface ensure every class which implemented the interface can get a CustomReportResult from server.
    /// </summary>
    public interface ICustomReportService
    {
        /// <summary>
        /// async get CustomReport from server.
        /// </summary>
        /// <param name="request"> a CustomReportRequest object contains params for posting to server. </param>
        /// <returns> a CustomReportResult object contains result from server. </returns>
        public Task<CustomReportResult> GetCustomReport(CustomReportRequest request);
    }
}