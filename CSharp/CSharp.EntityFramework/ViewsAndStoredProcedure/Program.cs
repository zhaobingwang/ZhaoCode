using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 视图
            Database.SetInitializer(new Initializer());
            using (var db=new UsersContext())
            {
                var users = db.UserViews;
                //var users = db.Users;
                foreach (var user in users)
                {
                    //Console.WriteLine(user.NickName);
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", user.UserId, user.UserNickName, user.RegTime, user.IsDelete, user.ProvinceName);
                }
            }
            #endregion
        }
    }
}
