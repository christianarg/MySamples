using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApiConsumer.Controllers
{
    public class HomeController : Controller
    {
        public static HttpClient staticHttpClient;

        public async Task<ActionResult> Index()
        {

            try
            {
                if (UseHttpClientFactory())
                {
                    ViewBag.Values = await RequestWithHttpClientFromFactory();
                }
                else
                {
                    ViewBag.Values = await RequestWithStaticHttpClient();
                }
            }
            catch (Exception ex)
            {

                ViewBag.Exception = ex;
            }

            return View();
        }

        private bool UseHttpClientFactory()
        {
            string useClientFactoryStr = ConfigurationManager.AppSettings["useHttpClientFactory"];
            if (bool.TryParse(useClientFactoryStr, out bool useClientFactory))
            {
                return useClientFactory;
            }
            return false;
        }
        //public async Task<ActionResult> Index()
        //{
        //    //ViewBag.Values = await RequestWithStaticHttpClient();
        //    ViewBag.Values = await RequestWithHttpClientFromFactory();
        //    return View();
        //}

        private async Task<string> RequestWithHttpClientFromFactory()
        {
            var httpClient = HttpClientFactory.CreateHttpClient(GetApiBaseUrl());
            var values = await httpClient.GetAsync("/api/values");
            return await values.Content.ReadAsStringAsync();
        }

        private static Uri GetApiBaseUrl()
        {
            return new Uri(ConfigurationManager.AppSettings["apiurl"]);
        }

        private async Task<string> RequestWithStaticHttpClient()
        {
            if(staticHttpClient == null)
            {
                staticHttpClient = new HttpClient();
                staticHttpClient.BaseAddress = GetApiBaseUrl();
            }
            
            var values = await staticHttpClient.GetAsync("/api/values");
            return await values.Content.ReadAsStringAsync();
        }
    }

    public static class HttpClientFactory
    {
        public static HttpClient CreateHttpClient(Uri baseAddress, HttpMessageHandler handler = null)
        {
            var httpClient = handler == null ? new HttpClient() : new HttpClient(handler);
            httpClient.BaseAddress = baseAddress;
            //ServicePointManager.FindServicePoint(baseAddress).ConnectionLeaseTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
            //ServicePointManager.DnsRefreshTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;

            ServicePointManager.FindServicePoint(baseAddress).ConnectionLeaseTimeout = 0;
            ServicePointManager.DnsRefreshTimeout = 0;

            return httpClient;
        }
    }
}