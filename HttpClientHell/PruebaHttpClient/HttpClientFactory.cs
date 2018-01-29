using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHttpClient
{
    public static class HttpClientFactory
    {
        public static HttpClient CreateHttpClient(Uri baseAddress, HttpMessageHandler handler = null)
        {
            try
            {
                var httpClient = handler == null ? new HttpClient() : new HttpClient(handler);
                httpClient.BaseAddress = baseAddress;
                //httpClient.DefaultRequestHeaders.ConnectionClose = true;
                //ServicePointManager.FindServicePoint(baseAddress).ConnectionLeaseTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
                //ServicePointManager.DnsRefreshTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;

                ServicePointManager.FindServicePoint(baseAddress).ConnectionLeaseTimeout = 0;
                ServicePointManager.DnsRefreshTimeout = 0;

                return httpClient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                throw;
            }
        }
    }
}
