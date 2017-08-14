using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Context:DbContext
    {
        public Context():base("name=EFDemoConn")
        {
            //Database.SetInitializer(new Initializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Province> Provinces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Properties<string>().Configure(config => config.IsUnicode(false));
            modelBuilder.Conventions.Add<CustomConventions>();
        }
    }
}
