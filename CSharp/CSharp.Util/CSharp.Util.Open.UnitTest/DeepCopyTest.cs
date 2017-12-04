using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Util.Open.UnitTest
{
    [TestClass]
    public class DeepCopyTest
    {
        [TestMethod]
        public void DeepCopyTest1()
        {
            User u1 = new User();
            u1.UName = "张三";
            User u2 = DeepCopy.DeepCopyByReflect(u1);
            Assert.AreNotEqual(u1, u2);
        }
    }
    public class User
    {
        public string UName { get; set; }
    }
}
