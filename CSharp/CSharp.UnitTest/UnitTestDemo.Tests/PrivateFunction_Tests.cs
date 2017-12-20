using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestDemo.Tests
{
    public class PrivateFunction_Tests
    {
        [Fact]
        public void XXX_Ok()
        {
            var private_function = new PrivateFunction();
            var obj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(private_function);
            Assert.True((bool)obj.Invoke("XXX"));
        }
    }
}
