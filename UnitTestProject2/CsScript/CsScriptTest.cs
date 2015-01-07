using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSScriptLibrary;

namespace PruebaCsScript
{
    [TestClass]
    public class CsScriptTest
    {
        public TestContext TestContext { get; set; }
        
        [TestMethod]
        public void LoadFileAndExecuteSimpleCode()
        {

            dynamic sumador = CSScript.Load("CsScript\\Sumador.scriptcs").CreateObject("*");
            var suma = sumador.SumarOcho(8);
            Assert.AreEqual(16,suma);
        }
    }
}
