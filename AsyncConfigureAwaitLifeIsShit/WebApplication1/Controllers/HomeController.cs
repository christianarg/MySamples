using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient httpClient = new HttpClient();

        public ActionResult Index(string data)
        {
            ViewBag.data = data;
            return View();
        }

        public ActionResult DeadLock()
        {
            var data = GetDataWithDefaultAwait().Result;
            return RedirectToAction("Index", new { data = Server.UrlEncode(data.Substring(0, 100)) });
        }

		public ActionResult AvoidDeadLockHack()
		{
			var data = RunSync(GetDataWithDefaultAwait());
			return RedirectToAction("Index", new { data = Server.UrlEncode(data.Substring(0, 100)) });
		}

		public ActionResult NotDeadlockSinAwait()
		{
			var data = httpClient.GetStringAsync("https://www.google.es").Result;
			return RedirectToAction("Index", new { data = Server.UrlEncode(data.Substring(0, 100)) });
		}

		public ActionResult NotDeadlock()
        {
			// T1
            var data = GetDataWithAwaitFalse().Result;
            return RedirectToAction("Index", new { data = Server.UrlEncode(data.Substring(0, 100)) });
        }

        public async Task<ActionResult> ActualCorrectWay()
        {
            var data = await GetDataWithDefaultAwait();
            return RedirectToAction("Index", new { data = Server.UrlEncode(data.Substring(0, 100)) });
        }

        public async Task<string> GetDataWithDefaultAwait()
        {
            return await httpClient.GetStringAsync("https://www.google.es");
        }

        public async Task<string> GetDataWithAwaitFalse()
        {
            return await httpClient.GetStringAsync("https://www.google.es").ConfigureAwait(false);
        }

		/// <summary>
		/// Ver The Thread Pool Hack en https://msdn.microsoft.com/en-us/magazine/mt238404.aspx?f=255&MSPPError=-2147217396
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="asyncTask"></param>
		/// <returns></returns>
		public T RunSync<T>(Task<T> asyncTask)
		{
			var data = Task.Run(() => asyncTask.Result).Result;
			return data;
		}
    }
}