using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Util.DataFactory.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=DemoConn")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<BindAccount> BindAccount { get; set; }
    }
}
