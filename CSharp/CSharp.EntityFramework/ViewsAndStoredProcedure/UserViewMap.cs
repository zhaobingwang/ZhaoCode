using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoredProcedure
{
    public class UserViewMap:EntityTypeConfiguration<UserView>
    {
        public UserViewMap()
        {
            HasKey(u => u.UserId).ToTable("UserViews");
        }
    }
}
