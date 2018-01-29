using System;
using System.Collections.Generic;
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
            //ViewBag.Values = await RequestWithStaticHttpClient();
            ViewBag.Values = await RequestWithHttpClientFromFactory();
            return View();
        }

        //public async Task<ActionResult> Index()
        //{
        //    //ViewBag.Values = await RequestWithStaticHttpClient();
        //    ViewBag.Values = await RequestWithHttpClientFromFactory();
        //    return View();
        //}

        private async Task<string> RequestWithHttpClientFromFactory()
        {
            var httpClient = HttpClientFactory.CreateHttpClient(new Uri("http://local.webapi.com"));
            var values = await httpClient.GetAsync("/api/values");
            return await values.Content.ReadAsStringAsync();
        }


        private async Task<string> RequestWithStaticHttpClient()
        {
            if(staticHttpClient == null)
            {
                staticHttpClient = new HttpClient();
                staticHttpClient.BaseAddress = new Uri("http://local.webapi.com");
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