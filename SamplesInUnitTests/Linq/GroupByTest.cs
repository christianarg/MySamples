using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.Linq
{
    [TestClass]
    public class GroupByTest
    {
        class Persona
        {
            
            public string Name { get; set; }
            public string LastName { get; set; }
        }

        [TestMethod]
        public void SimpleGroupBy()
        {
            var personas = InitPersonas();

            var result = personas
                            .GroupBy(p => p.Name)
                            .Select(p => p.Key).ToList();

            AssertResult(result);
        }
      
        [TestMethod]
        public void WithoutLinq()
        {
            var personas = InitPersonas();

            var result = new List<string>();

            foreach (var p in personas)
            {
                if (!result.Contains(p.Name))
                    result.Add(p.Name);
            }

            AssertResult(result);
        }

        [TestMethod]
        public void GroupBySelectObject()
        {
            var personas = InitPersonas();

            var result = personas
                            .GroupBy(p => p.Name).ToList();
                            //.Select(p => p.).ToList();

            //AssertResult(result);
        }


        private static void AssertResult(List<string> result)
        {
            Assert.AreEqual(result.First(), "Christian");
            Assert.AreEqual(result.First(), "Pepo");
        }

        private static List<Persona> InitPersonas()
        {
            var personas = new List<Persona>()
                {
                    new Persona() {Name = "Christian",LastName = "Rodriguez"},
                    new Persona() {Name = "Pepo", LastName = "Perez"},
                    new Persona() {Name = "Christian",LastName = "Andres"}
                };
            return personas;
        }
    }
}
