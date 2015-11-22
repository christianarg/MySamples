using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SamplesTestProyect.Lists
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))] // vaya kakota.
        public void OMG()
        {
            var kito = new ClaseConList { List = { "pa", "quito" } };   // vaya kakota. Deja hacer esto pero dará null :O
            Assert.AreEqual("pa", kito.List[0]);
            Assert.AreEqual("quito", kito.List[1]);
        }

        [TestMethod]
        public void EsteSi()
        {
            var kito = new ClaseConList { List = new List<string> { "pa", "quito" } };
            Assert.AreEqual("pa", kito.List[0]);
            Assert.AreEqual("quito", kito.List[1]);
        }


        [TestMethod]
        public void Munra()
        {
            var list = new List<ClaseConList> { new ClaseConList() };

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            var serializedList = JsonConvert.SerializeObject(list, settings);
        }
    }

    public class ClaseConList
    {
        public List<string> List { get; set; }
    }
}
