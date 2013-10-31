using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSampleProyect
{
    public static class Extensions
    {
        public static void PutInViewData<T>(this WebViewPage<T> webPage, string key, string value)
        {
            webPage.ViewData[key] = value;
        }

    }
}