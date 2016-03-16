using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitySamples
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RegisterByConventionTest()
        {
            var container = new UnityContainer();
            container.RegisterTypes(
                    AllClasses.FromLoadedAssemblies(),
                    WithMappings.FromMatchingInterface,
                    WithName.Default,
                    WithLifetime.Transient);

            var coso = container.Resolve<ICoso>();
            Assert.AreEqual("Que hashe fiera?",coso.Munra());
        }
    }


    public interface ICoso
    {
        string Munra();
    }

    public class Coso : ICoso
    {
        public string Munra()
        {
            return "Que hashe fiera?";
        }
    }
}
