using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndTransaction
{
    public class Initializer:DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            for (int i = 0; i < 5; i++)
            {
                var user = new User { NickName = "用户" + (i + 1), RegTime = new DateTime(2017, 08, 10), IsDelete = 0, Bio = "我的简介-" + (i + 1) };
                context.Users.Add(user);
            }
            var inputaccount = new InputAccount { Name = "张三", Balance = 0m };
            var outputaccount = new OutputAccount { Name = "李四", Balance = 100000m };
            context.InputAccount.Add(inputaccount);
            context.OutputAccount.Add(outputaccount);
            base.Seed(context);
        }
    }
}
