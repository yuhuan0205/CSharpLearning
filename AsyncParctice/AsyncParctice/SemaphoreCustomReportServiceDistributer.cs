using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncParctice
{
    /// <summary>
    /// a object disstributes requests based on resource.
    /// </summary>
    public class SemaphoreCustomReportServiceDistributer : ICustomReportService
    {
        /// <summary>
        /// the resource of service.
        /// </summary>
        private ConcurrentBag<ICustomReportService> AvailableServices;

        /// <summary>
        /// a semaphore represents that whether the resource is available.
        /// </summary>
        private SemaphoreSlim Semaphore;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="services"> services </param>
        /// <param name="maxRequests"> each service's max requests number. </param>
        public SemaphoreCustomReportServiceDistributer(List<ICustomReportService> services, List<int> maxRequests) 
        {
            if (services.Count != maxRequests.Count)
            {
                throw new CustomReportServiceException("services and maxRequest have different length.");
            }
            else
            {
                AvailableServices = new ConcurrentBag<ICustomReportService>();
                List<ICustomReportService> Services = new List<ICustomReportService>(services);
                for (int indexOfservices = 0; indexOfservices < Services.Count; indexOfservices++)
                {
                    for (int num = 0; num < maxRequests[indexOfservices]; num++)
                    {
                        AvailableServices.Add(Services[indexOfservices]);
                    }
                }

                Semaphore = new SemaphoreSlim(AvailableServices.Count);
            }
        }

        /// <summary>
        /// wait for resource if all services are busy now.
        /// </summary>
        /// <param name="request"> a CustomReportRequest object contains params for posting to server. </param>
        /// <returns> a CustomReportResult object contains result from server. </returns>
        public async Task<CustomReportResult> GetCustomReport(CustomReportRequest request) 
        {
            await Semaphore.WaitAsync();
            AvailableServices.TryTake(out ICustomReportService service);
            CustomReportResult result;
            try 
            {
                result  = await service.GetCustomReport(request);
                return result;
            }
            finally
            {
                AvailableServices.Add(service);
                Semaphore.Release();
            }
        }
    }
}
