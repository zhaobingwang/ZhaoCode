using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestDemo.Tests
{
    public class Notiy_Tests
    {
        [Fact]
        public void Info_Ok()
        {
            Notiy notiy = new Notiy();
            var isNotiyOk = notiy.Info("消息发送成功");
            Assert.True(isNotiyOk);
        }
    }
}
