using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Util.Open;

namespace UnitTestProjectTemp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime now = DateTime.Now;
            DateTime birthday = new DateTime(1999, 8, 8, 12, 12, 12);
            int expected = 18;
            int age = Unclassified.GetAge(birthday, now);
            Assert.AreEqual(expected, age);
        }
    }
}
