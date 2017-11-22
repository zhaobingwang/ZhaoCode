using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSite.Domain
{
    /// <summary>
    /// 播种数据
    /// </summary>
    public class SeedingDataInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            int baseAge = 10;
            for (int i = 0; i < 5; i++)
            {
                var user = new User
                {
                    Id=Guid.NewGuid(),
                    Name = $"测试用户{i + 1}",
                    NickName= $"测试用户昵称{i + 1}",
                    Age = baseAge + i,
                    Birthday=new DateTime(2000,i+1,10+i),
                    RegDate= new DateTime(2010, i + 1, 10 + i),
                    ModifyDate= new DateTime(2010, i + 1, 10 + i)
                };
                context.User.Add(user);
            }
            base.Seed(context);
        }
    }
}
