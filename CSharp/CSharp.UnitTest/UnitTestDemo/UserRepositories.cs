using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Domain;

namespace UnitTestDemo
{
    public class UserRepositories : IUserRepositories
    {
        DemoContext db = null;
        public UserRepositories()
        {
            db = new DemoContext();
        }
        public void Add(User model)
        {
            try
            {
                db.Set<User>().Add(model);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var aa = ex.InnerException.Message;
            }
        }

        public void Delete(Guid id)
        {
            var model = Users.Where(u => u.Id == id).Single();
            db.Set<User>().Attach(model);
            db.Set<User>().Remove(model);
            db.SaveChanges();
        }

        public IQueryable<User> Users
        {
            get
            {
                return db.Users;
            }
        }
    }
}
