using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoredProcedure
{
    public class Initializer : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            #region  add provinces data
            var province1 = new Province
            {
                ProvinceName = "杭州",
            };
            var province2 = new Province
            {
                ProvinceName = "上海",
            };
            context.Provinces.Add(province1);
            context.Provinces.Add(province2);
            
            #endregion

            #region add users data
            for (int i = 0; i < 5; i++)
            {
                var user = new User { NickName = "用户" + (i + 1),RegTime=new DateTime(2017,08,08),IsDelete=0,Province=province1};
                context.Users.Add(user);
            }
            #endregion
            var drop = "Drop Table UserViews";
            context.Database.ExecuteSqlCommand(drop);
            var createView = @"CREATE VIEW [dbo].[UserViews]
                                AS  SELECT 
                                dbo.Users.Id as UserId,
                                dbo.Users.NickName as UserNickName,
                                dbo.Users.RegTime as RegTime,
                                dbo.Users.IsDelete as IsDelete,
                                dbo.Provinces.ProvinceName as ProvinceName
                                FROM dbo.Users
                                INNER JOIN dbo.Provinces ON dbo.Provinces.Id=dbo.Users.Province_Id";
            context.Database.ExecuteSqlCommand(createView);
            base.Seed(context);
        }
    }
}
