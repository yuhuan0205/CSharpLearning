using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncParctice
{
    public class BlockQueueCustomReportServiceDistributer : ICustomReportService
    {
        /// <summary>
        /// the resource of service.
        /// </summary>
        private ConcurrentBag<(CustomReportRequest, TaskCompletionSource<CustomReportResult>)> BlockingQueue;

        /// <summary>
        /// block request when service are all busy.
        /// </summary>
        private SemaphoreSlim Resources;

        /// <summary>
        /// block request when service are all busy.
        /// </summary>
        private SemaphoreSlim Requests;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="services"> services </param>
        /// <param name="maxRequests"> each service's max requests number. </param>
        public BlockQueueCustomReportServiceDistributer(List<ICustomReportService> services, List<int> maxRequests)
        {
            if (services.Count != maxRequests.Count)
            {
                throw new CustomReportServiceException("services and maxRequest have different length.");
            }
            else
            {
                ConcurrentQueue<ICustomReportService> servicesQueue = new ConcurrentQueue<ICustomReportService>(services);
                BlockingQueue = new ConcurrentBag<(CustomReportRequest, TaskCompletionSource<CustomReportResult>)>();

                //counting the upbound of the requests.
                int totalRequests = 0;
                foreach (int i in maxRequests)
                {
                    totalRequests += i;
                }

                Resources = new SemaphoreSlim(0, totalRequests);
                Requests = new SemaphoreSlim(totalRequests);

                for (int indexOfservices = 0; indexOfservices < services.Count; indexOfservices++)
                {
                    servicesQueue.TryDequeue(out ICustomReportService service);
                    for (int num = 0; num < maxRequests[indexOfservices]; num++)
                    {
                        Task.Run(() => RunService(service));
                    }
                }
            }
        }

        /// <summary>
        /// wait for resource if all services are busy now.
        /// </summary>
        /// <param name="request"> a CustomReportRequest object contains params for posting to server. </param>
        /// <returns> a CustomReportResult object contains result from server. </returns>
        public async Task<CustomReportResult> GetCustomReport(CustomReportRequest request)
        {
            await Requests.WaitAsync();
            TaskCompletionSource<CustomReportResult> tcs = new TaskCompletionSource<CustomReportResult>();
            BlockingQueue.Add((request, tcs));
            Resources.Release();
            var result = await tcs.Task;
            Requests.Release();
            return result;
        }

        /// <summary>
        /// run a service.
        /// </summary>
        /// <param name="service"> a service instance </param>
        /// <returns> a task.</returns>
        private async Task RunService(ICustomReportService service) 
        {
            while (true)
            {
                await Resources.WaitAsync();
                BlockingQueue.TryTake(out var task);
                var x = await service.GetCustomReport(task.Item1);
                task.Item2.SetResult(x);
            }
        }
    }
}
