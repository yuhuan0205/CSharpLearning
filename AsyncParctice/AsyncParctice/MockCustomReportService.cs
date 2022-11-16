using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncParctice
{
    /// <summary>
    /// a mock service in order to simulate real service.
    /// </summary>
    public class MockCustomReportService : ICustomReportService
    {
        /// <summary>
        /// result would be send after AvgResponseTime latter.
        /// </summary>
        private int AvgResponseTime;

        /// <summary>
        /// the number of request which service can handle.
        /// </summary>
        private int MaxRequests;

        /// <summary>
        /// how many requests are in service's queue.
        /// </summary>
        private int CurrentRequestQuantity;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="avgResponseTime"> avgResponseTime </param>
        /// <param name="maxRequests"> maxRequests </param>
        public MockCustomReportService(int avgResponseTime, int maxRequests)
        {
            AvgResponseTime = avgResponseTime;
            MaxRequests = maxRequests;
            CurrentRequestQuantity = 0;
        }

        /// <summary>
        /// simulately call api with params user setted.
        /// </summary>
        /// <param name="request"> a CustomReportRequest object contains params for posting to server. </param>
        /// <returns> a CustomReportResult object contains result from server. </returns>
        public async Task<CustomReportResult> GetCustomReport(CustomReportRequest request)
        {
            if (Interlocked.Increment(ref CurrentRequestQuantity) > MaxRequests)
            {
                throw new CustomReportServiceException("Requests is full");
            }
            else 
            {
                var result = new CustomReportResult { IsCompleted = true };
                await Task.Delay(AvgResponseTime);
                Interlocked.Decrement(ref CurrentRequestQuantity);
                return result;
            }
        }
    }
}