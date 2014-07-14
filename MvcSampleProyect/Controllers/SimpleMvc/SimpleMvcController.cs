using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleProyect.Controllers.SimpleMvc
{
    public class SimpleMvcController : Controller
    {
        private static List<Content> Contents = new List<Content>(); 
        //
        // GET: /SimpleMvc/

        public ActionResult Index()
        {
            return View(Contents);
        }

        public ActionResult CreateContent()
        {
            return View();
        }

        public ActionResult ShowCreateContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExecuteCreateContent(Content content)
        {
            Contents.Add(content);
            return View("Index",Contents);
        }
    }

    public class Content
    {
        public string Name { get; set; }
    }
}
