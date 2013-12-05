using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MvcSampleProyect.Controllers.WebConfiguration
{
    /// <summary>
    /// Como leer una sección de configuración
    /// </summary>
    public class WebConfigurationController : Controller
    {
        public ActionResult Index()
        {
            var section = WebConfigurationManager.GetSection("system.web/caching/outputCacheSettings") as OutputCacheSettingsSection;


            return View();
        }

    }
}
