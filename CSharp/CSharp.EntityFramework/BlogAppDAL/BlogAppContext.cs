using BlogAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppDAL
{
    public class BlogAppContext : DbContext
    {
        public BlogAppContext() : base("name=BlogAppConn")
        {

        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Category和Blog之间的一对多关系
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Blogs)
                .WithRequired(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .WillCascadeOnDelete(false);

            //Blog和Comments之间的一对多关系
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Comments)
                .WithRequired(c => c.Blog)
                .HasForeignKey(c => c.BlogId)
                .WillCascadeOnDelete(false);

            //User和Blog之间的一对多关系
            modelBuilder.Entity<User>()
                .HasMany(b => b.Blogs)
                .WithRequired(u => u.User)
                .HasForeignKey(b => b.AuthorId)
                .WillCascadeOnDelete(false);

            //User和Comment之间的一对多关系
            modelBuilder.Entity<User>()
                .HasMany(c => c.Comments)
                .WithOptional(c => c.User)
                .HasForeignKey(c => c.PosterId);

            //User和Role之间的多对多关系
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(act => act.ToTable("UserRoles").MapLeftKey("UserId").MapRightKey("RoleId"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
