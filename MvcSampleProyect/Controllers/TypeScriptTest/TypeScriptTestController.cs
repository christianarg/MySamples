using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleProyect.Controllers.TypeScriptTest
{
    public class TypeScriptTestController : Controller
    {
        //
        // GET: /TypeScriptTest/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult AjaxCall(int id)
        {
           return Json(new{ MyProperty= "HolaMostro"});
        }

    }

}
