using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleProyect.Controllers.ViewContextViewData
{
    public class ViewContextViewDataWithPartialController : Controller
    {
        //
        // GET: /ViewContextViewData/

        public ActionResult Index()
        {
            ViewBag.FromIndex = "FromIndex";
            return View();
        }

        public ActionResult ThePartial()
        {
            var fromIndex = ViewBag.FromIndexView;
            ViewBag.FromPartial = "FromPartial";
            return View();
        }
    }
}
