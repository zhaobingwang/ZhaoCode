using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Domain;
using Xunit;

namespace UnitTestDemo.Tests
{
    public class UserService_Tests
    {
        [Fact]
        public void Create_Ok()
        {
            IUserRepositories userRepositories = new StubUserRepositories();
            UserService service = new UserService(userRepositories);
            var isCreateOk = service.Create(null);
            Assert.True(isCreateOk);
        }

        /// <summary>
        /// 使用Stub(存根)来模拟，而不再对数据库进行实际操作。
        /// </summary>
        public class StubUserRepositories : IUserRepositories
        {
            public void Add(User model)
            {

            }
        }

        [Fact]
        public void Create_Mock_Ok()
        {
            var userRepositories = new Mock<IUserRepositories>();
            UserService service = new UserService(userRepositories.Object);
            var isCreateOk = service.Create(null);
            Assert.True(isCreateOk);
        }

        [Fact]
        public void Create_Mock_Notiy_Ok()
        {
            var userRepositories = new Mock<IUserRepositories>();
            var notiy = new Mock<Notiy>();
            notiy.Setup(n => n.Info(It.IsAny<string>())).Returns(true); //参数It.IsAny() 是任意字符串的意思
            //notiy.Setup(f => f.Info("")).Returns(false);
            //notiy.Setup(f => f.Info("消息通知")).Returns(true);
            UserService service = new UserService(userRepositories.Object, notiy.Object);
            var isCreateOk = service.CreateAndNotiy(new User());
            Assert.True(isCreateOk);
        }
    }
}
