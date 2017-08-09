using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoredProcedure
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("name=EFDemoConn")
        {
            Database.SetInitializer<UsersContext>(new Initializer());
        }
        public virtual DbSet<UserView> UserViews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Province> Provinces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserViewMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
