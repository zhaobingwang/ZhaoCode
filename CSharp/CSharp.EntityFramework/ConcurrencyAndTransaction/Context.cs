using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public Context(DbConnection conn,bool contextOwnsConnection):base(conn,contextOwnsConnection)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<InputAccount> InputAccount { get; set; }
        public DbSet<OutputAccount> OutputAccount { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.RowVersion).IsRowVersion();
            base.OnModelCreating(modelBuilder);
        }
    }
}
