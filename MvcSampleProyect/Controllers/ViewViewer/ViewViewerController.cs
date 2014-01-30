using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleProyect.Controllers.ViewViewer
{
    public class ViewViewerController : Controller
    {
        //
        // GET: /ViewViewer/

        public ActionResult Index()
        {
            return View(Request["view"]);
        }

    }
}
