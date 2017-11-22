using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSite.Domain;

namespace WepApiSite.Core
{
    public class UserService
    {
        public List<User> GetAllUsers()
        {
            var db = new Context();
            var users = db.User.Where(u => true).ToList();
            return users;
        }
    }
}
