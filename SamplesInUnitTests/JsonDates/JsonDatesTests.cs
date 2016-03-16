using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace SamplesTestProyect.JsonDates
{
    [TestClass]
    public class JsonDatesTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var fechaDeToJsonDeJavascript = "2015-00-29";
            var dateTime = JsonConvert.DeserializeObject<DateTime>(fechaDeToJsonDeJavascript);
        }
    }
}
