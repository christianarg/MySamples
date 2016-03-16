using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.FuncAndAction
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOneFunc()
        {
            Func<int, int> addOneFunc = (number) => number + 1;

            var result = addOneFunc(2);

            Assert.AreEqual(3,result);
        }

        [TestMethod]
        public void AddOneFunc2()
        {
            Func<int, int> addOneFunc = (number) =>
                {
                    return number + 1;
                };

            var result = addOneFunc(2);

            Assert.AreEqual(3, result);
        }
        string toTest;
        [TestMethod]
        public void ActionTest()
        {
            toTest = string.Empty;

            Action<string> setString = (number) => toTest = number;
            setString("1");
            Assert.AreEqual("1",toTest);
        }

        public int AddOne(int number)
        {
            return number + 1;
        }
    }
}
