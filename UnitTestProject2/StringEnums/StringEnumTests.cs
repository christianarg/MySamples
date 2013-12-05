using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.StringEnums
{
    [TestClass]
    public class StringEnumTests
    {
        [TestMethod]
        public void CannotCompareStringEnumWithoutEnumParse()
        {
            var enumString = MyEnum.OneState.ToString();

            Assert.AreNotEqual(MyEnum.OneState, enumString);
        }

        [TestMethod]
        public void CanCompareWithEnumParse()
        {
            var enumString = MyEnum.OneState.ToString();
            var parsedEnumString = ((MyEnum)Enum.Parse(typeof(MyEnum), enumString));
            Assert.AreEqual(MyEnum.OneState, parsedEnumString);
        }
    }

    public enum MyEnum 
    {
        OneState,
        OtherState
    }
}
