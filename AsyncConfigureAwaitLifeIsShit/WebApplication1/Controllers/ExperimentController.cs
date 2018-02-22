using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ExperimentController : Controller
    {
        static HttpClient httpClient = new HttpClient();

        // GET: Experiment
        public ActionResult IsThisDeadLock()
        {
            var data = MethodThatCallsGetDataButThisOneUsesAwaitFalse().Result;
            return Redirect("/");
        }

        public ActionResult IsThisDeadLock2()
        {
            var data = MethodThatCallsGetDataButThisOneUsesAwaitFalse().GetAwaiter().GetResult();
            return Redirect("/");
        }


        public async Task<ActionResult> IsThisDeadLock3()
        {
            //var data = MethodThatCallsGetDataButThisOneUsesAwaitFalse().Result;
            var data = await GetDataWithoutAwait();
            return Redirect("/");
        }


        public async Task<string> MethodThatCallsGetDataButThisOneUsesAwaitFalse()
        {
            return await GetDataWithDefaultAwait().ConfigureAwait(false);
        }

        public async Task<string> GetDataWithDefaultAwait()
        {
            return await httpClient.GetStringAsync("https://www.google.es");
        }

        public Task<string> GetDataWithoutAwait()
        {
            return httpClient.GetStringAsync("https://www.google.es");
        }
    }
}