using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleProyect.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

        public ActionResult Index()
        {
            return Json(new { MyProperty = "Hola Tarola" }, JsonRequestBehavior.AllowGet);
        }


        public string ReturnInput(string input)
        {
            // para pruebas con ajax. Simplemente devuelve la entrada
            return input;
        }
    }
}
