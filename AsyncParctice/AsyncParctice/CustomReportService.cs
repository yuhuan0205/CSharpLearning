using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace AsyncParctice
{
    /// <summary>
    /// a service calls api with params, returning result.
    /// </summary>
    public class CustomReportService : ICustomReportService
    {
        /// <summary>
        /// HttpClient instance to call api.
        /// </summary>
        private HttpClient Client;

        /// <summary>
        /// constructor.
        /// </summary>
        /// <param name="ip"> target ip address </param>
        public CustomReportService(string ip)
        {
           Client = new HttpClient { BaseAddress = new Uri(ip) };
        }

        /// <summary>
        /// call api /api/customreport/ with params user setted.
        /// </summary>
        /// <param name="request"> a CustomReportRequest object contains params for posting to server. </param>
        /// <returns> a CustomReportResult object contains result from server. </returns>
        public async Task<CustomReportResult> GetCustomReport(CustomReportRequest request)
        {
            string content = JsonSerializer.Serialize(request);
            HttpResponseMessage result = await Client.PostAsync("customreport", new StringContent(content, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
            string jsonString = await result.Content.ReadAsStringAsync();
            CustomReportResult customReport = JsonSerializer.Deserialize<CustomReportResult>(jsonString);
            return customReport;
        }
    }
}
