using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleProyect.Controllers.ViewContextViewData
{
    public class ViewContextViewDataController : Controller
    {
        //
        // GET: /ViewContextViewData/

        public ActionResult Index()
        {
            ViewBag.FromController = "FromController";
            //ViewBag.FromView = "FromView";
            return View();
        }
    }
}
