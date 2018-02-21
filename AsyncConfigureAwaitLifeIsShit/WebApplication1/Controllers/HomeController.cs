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

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(string data)
        {
            ViewBag.data = data;
            return View();
        }


        public ActionResult DeadLock()
        {
            var data = GetDataWithDefaultAwait().Result;
            return RedirectToAction("Index", new { data = "got data from google" });
        }

      
        public ActionResult NotDeadlock()
        {
            var data = GetDataWithAwaitFalse().Result;
            return RedirectToAction("Index", new { data = "got data from google"});
        }

        public async Task<ActionResult> ActualCorrectWay()
        {
            var data = await GetDataWithDefaultAwait();
            return RedirectToAction("Index", new { data = "got data from google" });
        }

        public async Task<string> GetDataWithDefaultAwait()
        {
            return await httpClient.GetStringAsync("https://www.google.es");
        }

        public async Task<string> GetDataWithAwaitFalse()
        {
            return await httpClient.GetStringAsync("https://www.google.es").ConfigureAwait(false);
        }
    }
}