using MySql.Data.Entity;
using Project.Framework.Data.Entities;
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //users相关配置
            modelBuilder.Entity<User>().Property(u => u.CreateDate).IsOptional();
            modelBuilder.Entity<User>().Property(u => u.ModifyDate).IsOptional();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
