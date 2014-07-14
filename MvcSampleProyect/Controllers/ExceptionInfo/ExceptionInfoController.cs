using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleProyect.Controllers.ExceptionInfo
{
    public class ExceptionInfoController : Controller
    {
        //
        // GET: /ExceptionInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActionWithError()
        {
            Response.StatusCode = 500;
            return Json(new { Titulo = "He petado", Descripcion = "Pero te devuelvo un objeto custom" });
        }

        public ActionResult ActionWithError2()
        {
            // Petar para que salte el OnException
            throw new Exception("He petado con dos pelotas");
        }

        // Gestión del error (podría ser un ActionFilter)
        protected override void OnException(ExceptionContext filterContext)
        {
            // Le avisamos que nos encargamos nosotros, para que no envía toda la parafernalia
            // de error
            filterContext.ExceptionHandled = true;

            // Pero le decimos que es un error (queremos que $.ajax().fail() se dispare)
            Response.StatusCode = 500;

            // y ponemos nuestra información custom
            filterContext.Result = Json(new { Titulo = "Ha habido una excepción", Descripcion = "Pero te devuelvo un objeto custom, con dos pelotas" });
        }

        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    if(filterContext.Exception != null && !filterContext.Canceled)
        //    {
        //        //filterContext.ActionDescriptor.
        //    }
        //    //base.OnActionExecuted(filterContext);
        //}
    }
}
