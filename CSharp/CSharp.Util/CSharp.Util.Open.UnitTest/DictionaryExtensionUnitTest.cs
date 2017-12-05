using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CSharp.Util.Open.UnitTest
{
    [TestClass]
    public class DictionaryExtensionUnitTest
    {
        [TestMethod]
        public void DictionaryExtensionTryAddTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", "张三");
            dict.TryAdd("Name", "李四");
            Assert.AreNotEqual(dict["Name"], "李四");
        }

        [TestMethod]
        public void DictionaryExtensionAddOrReplaceTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", "张三");
            dict.AddOrReplace("Name", "李四");
            Assert.AreEqual(dict["Name"], "李四");
        }
    }
}
