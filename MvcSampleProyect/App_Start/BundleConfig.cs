using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MvcSampleProyect
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Clasess/jquery").Include(
                "~/Scripts/Lib/jquery/jquery-{version}.js",
                "~/Scripts/Lib/jquery/jquery.*",
                "~/Scripts/Lib/jquery/jquery-ui-{version}.js")
            );
        }
    }
}