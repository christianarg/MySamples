using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace SamplesTestProyect.JsonNet
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var theClass = ClassWithPrivateConstructor.createClass("hola mostro", "pepe");
            var theSerializedClass = JsonConvert.SerializeObject(theClass);

            var theDeserializedClass = JsonConvert.DeserializeObject<ClassWithPrivateConstructor>(theSerializedClass);
        }
    }

    public class ClassWithPrivateConstructor
    {
        public string Property { get; set; }
        public string Property2 { get; set; }
        public static ClassWithPrivateConstructor createClass(string property, string property2)
        {
            return new ClassWithPrivateConstructor(property,property2);
        }

        [JsonConstructor]
        private ClassWithPrivateConstructor(string property, string property2)
         {
             Property = property;
             Property2 = property2;
         }
    }
}
