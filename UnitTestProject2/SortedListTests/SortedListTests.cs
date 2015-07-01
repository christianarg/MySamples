using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SamplesTestProyect.SortedListTests
{
    [TestClass]
    public class SortedListTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var list = new SortedList<string, object>();
            list.Add("my", "valor");
            list["my"] = "jose";

        }
    }
}
