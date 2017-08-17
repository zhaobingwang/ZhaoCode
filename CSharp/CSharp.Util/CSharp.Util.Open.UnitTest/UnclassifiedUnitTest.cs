using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Util.Open.UnitTest
{
    [TestClass]
    public class UnclassifiedUnitTest
    {
        [TestMethod]
        public void TestMethodGetAge()
        {
            DateTime now = DateTime.Now;
            DateTime birthday = new DateTime(2000, 8, 17, 11, 41, 59);
            int expected = 17;
            int age = Unclassified.GetAge(birthday, now);
            Assert.AreEqual(expected, age);
        }
    }
}
