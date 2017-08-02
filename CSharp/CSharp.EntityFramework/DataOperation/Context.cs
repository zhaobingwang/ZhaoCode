using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public class Context:DbContext
    {
        public Context():base("name=EFDemoConn")
        {
            Database.SetInitializer<Context>(new SeedingTestDataInitialzer());
        }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
