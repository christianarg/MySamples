using System;
using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.Inheritance
{
    [TestClass]
    public class InheritanceTests
    {
        public class BaseClass{ }
        public class InheritedClass1 : BaseClass{ }
        public class InheritedClass2 :BaseClass{ }


        
        [TestMethod]
        public void IsOperatorDoesNotApplyToBaseClass()
        {
            var inherited1 = new InheritedClass1();

            Assert.IsTrue(inherited1 is BaseClass);
        }

        [TestMethod]
        public void MustCheckInheritanceWithIsAssignableFrom()
        {
            var inherited1 = new InheritedClass1();
            Assert.IsTrue(inherited1.GetType().IsAssignableFrom(typeof(BaseClass)));            
        }
    }
}
