using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndTransaction
{
    public class Initializer:DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            for (int i = 0; i < 5; i++)
            {
                var user = new User { NickName = "用户" + (i + 1), RegTime = new DateTime(2017, 08, 10), IsDelete = 0, Bio = "我的简介-" + (i + 1) };
                context.Users.Add(user);
            }
            base.Seed(context);
        }
    }
}
