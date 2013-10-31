using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.DynamicAndGenerics
{
    [TestClass]
    public class DynamicAndGenericTests
    {
        [TestMethod]
        public void GetWithGeneric()
        {
            var classWithSome = new ClassWithSomething();
            var some = classWithSome.GetSomething<Something>();
            Assert.IsNotNull(some);
        }

        [TestMethod]
        public void GetWithDynamicAutoCast()
        {
            var classWithSome = new ClassWithSomething();
            // Necesita referencia Microsoft.CSharp, para utilizar modelBinder
            Something some = classWithSome.Something;
            Assert.IsNotNull(some);
        }

    }

    public class ClassWithSomething
    {
        public T GetSomething<T>()
            where T : class
        {
            return new Something() as T;
        }
        public dynamic Something
        {
            get { return GetSomething<object>(); }
        }
    }

    public class Something{ }
}
