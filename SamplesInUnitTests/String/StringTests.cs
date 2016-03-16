using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTestProyect.String
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestStringNullAndFriends()
        {
            string nullString = null;
            string emptyStringWithTilde = "";
            string emptyStringWithStringEmpty = string.Empty;
            string whiteSpace = " ";

            Assert.IsTrue(nullString == null);
            Assert.IsFalse(nullString == emptyStringWithTilde);
            Assert.IsFalse(nullString == emptyStringWithStringEmpty);

            Assert.IsTrue(emptyStringWithTilde == emptyStringWithStringEmpty);

            Assert.IsTrue(string.IsNullOrEmpty(nullString));
            Assert.IsTrue(string.IsNullOrEmpty(emptyStringWithTilde));
            Assert.IsTrue(string.IsNullOrEmpty(emptyStringWithStringEmpty));
            Assert.IsFalse(string.IsNullOrEmpty(whiteSpace));

            Assert.IsTrue(string.IsNullOrWhiteSpace(nullString));
            Assert.IsTrue(string.IsNullOrWhiteSpace(emptyStringWithTilde));
            Assert.IsTrue(string.IsNullOrWhiteSpace(emptyStringWithStringEmpty));
            Assert.IsTrue(string.IsNullOrWhiteSpace(whiteSpace));
        }


        [TestMethod]
        public void TestTrim()
        {
            const string myString = "/jose";

            var trimmed = myString.Trim('/');

            Assert.AreEqual("jose", trimmed);
        }
    }
}
