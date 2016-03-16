using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.Ref
{
    [TestClass]
    public class RefTest
    {
        [TestMethod]
        public void When_Modify_Reference_WithoutRef_Then_OuterMethodClassRemains()
        {
            var myClass = new MyTestClass() { AProperty = "Hello Motto" };
            MethodThatChangesParamNotByRef(myClass);
            Assert.AreEqual("Hello Motto", myClass.AProperty);
        }

        [TestMethod]
        public void When_Modify_Reference_WithtRef_Then_OuterMethodClassChanges()
        {
            var myClass = new MyTestClass() { AProperty = "Hello Motto" };
            MethodThatChangesParamByRef(ref myClass);
            Assert.AreEqual("Esto SI se debería cambiar", myClass.AProperty);
        }

        private void MethodThatChangesParamByRef(ref MyTestClass myTestClass)
        {
            myTestClass = new MyTestClass() { AProperty = "Esto SI se debería cambiar" };
        }

        private void MethodThatChangesParamNotByRef(MyTestClass myTestClass)
        {
            myTestClass = new MyTestClass() { AProperty = "Esto no se debería cambiar" };
        }
    }

    public class MyTestClass
    {
        public string AProperty { get; set; }
    }

}
