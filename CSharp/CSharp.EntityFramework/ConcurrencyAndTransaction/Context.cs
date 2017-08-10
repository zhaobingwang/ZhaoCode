using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndTransaction
{
    public class Context:DbContext
    {
        public Context():base("name=EFDemoConn")
        {
            Database.SetInitializer<Context>(new Initializer());
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.RowVersion).IsRowVersion();
            base.OnModelCreating(modelBuilder);
        }
    }
}
