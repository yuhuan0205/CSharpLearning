using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncParctice
{
    /// <summary>
    /// this Distributer distributed requests to services in list randomly.
    /// </summary>
    public class RandomCustomReportServiceDistributer : ICustomReportService
    {
        /// <summary>
        /// a list contains several CustomReportServices.
        /// </summary>
        private List<ICustomReportService> CustomReportServices;

        /// <summary>
        /// a object to generate random number.
        /// </summary>
        private Random RandomGenerator;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="customReportServices"> a list of ICustomReportServices </param>
        public RandomCustomReportServiceDistributer(List<ICustomReportService> customReportServices)
        {
            CustomReportServices = new List<ICustomReportService>(customReportServices);
            RandomGenerator = new Random();
        }

        /// <summary>
        /// get the CustomReport from a random service in CustomReportServices.
        /// </summary>
        /// <param name="request"> a CustomReportRequest object contains params for posting to server. </param>
        /// <returns> a CustomReportResult object contains result from server. </returns>
        public async Task<CustomReportResult> GetCustomReport(CustomReportRequest request)
        {
            return await CustomReportServices[RandomGenerator.Next(0, CustomReportServices.Count)].GetCustomReport(request);
        }
    }
}
