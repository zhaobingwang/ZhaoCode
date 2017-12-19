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

        public IQueryable<User> Users
        {
            get
            {
                return db.Users;
            }
        }
    }
}
