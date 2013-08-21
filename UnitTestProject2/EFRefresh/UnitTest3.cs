using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.EFRefresh
{
    [TestClass]
    public class UnitTest3
    {
        public class TestClass
        {
            public string Id { get; set; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var objectStateEntries = new List<TestClass>();
            var testClass1 = CreateTestClass("1");
            var testClass2 = CreateTestClass("2");
            var testClass3 = CreateTestClass("3");

            objectStateEntries.Add(testClass1);
            objectStateEntries.Add(testClass2);
            objectStateEntries.Add(testClass3);


            var entities = new List<TestClass>();

            entities.Add(testClass1);
            entities.Add(testClass2);


            var objectsInBothLists = (from c in objectStateEntries
                                        where entities.Contains(c)
                                        select c).ToList();

           Assert.AreEqual(objectsInBothLists.Count,2);

        }

        private static TestClass CreateTestClass(string id)
        {
            return new TestClass() { Id = id };
        }
    }
}
