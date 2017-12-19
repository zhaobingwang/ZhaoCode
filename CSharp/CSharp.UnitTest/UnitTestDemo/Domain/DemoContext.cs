using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo.Domain
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("name=DemoDBConn")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
