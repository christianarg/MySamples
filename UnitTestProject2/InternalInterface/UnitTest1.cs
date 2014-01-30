using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.InternalInterface
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    internal class Implementation : IInternalInterface
    {
        public string MyMethod()
        {
            throw new NotImplementedException();
        }
    }

    internal interface IInternalInterface
    {
        string MyMethod();
    }
}
