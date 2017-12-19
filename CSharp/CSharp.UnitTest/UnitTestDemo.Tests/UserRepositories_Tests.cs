using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Domain;
using Xunit;

namespace UnitTestDemo.Tests
{
    public class UserRepositories_Tests
    {
        [Fact]
        public void Add_Ok()
        {
            UserRepositories r = new UserRepositories();
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "张三"
            };
            r.Add(user);
            var model = r.Users.Where(u => u.Name == "张三").FirstOrDefault();
            Assert.True(model != null);
        }
    }
}
