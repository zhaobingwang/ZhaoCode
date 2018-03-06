using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Framework.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlContext : DbContext
    {
        public MySqlContext() : base("MySqlContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TempClass> TempClass { get; set; }
    }
}
