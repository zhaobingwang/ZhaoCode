using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Domain;

namespace UnitTestDemo
{
    public class UserService
    {
        IUserRepositories userRepositories;
        Notiy notiy;
        public UserService()
        {

        }
        public UserService(IUserRepositories _userRepositories)
        {
            this.userRepositories = _userRepositories;
        }
        public UserService(IUserRepositories _userRepositories, Notiy notiy)
        {
            this.userRepositories = _userRepositories;
            this.notiy = notiy;
        }

        public bool Create(User user)
        {
            userRepositories.Add(user);
            return true;
        }

        public bool CreateAndNotiy(User user)
        {
            userRepositories.Add(user);
            bool isNotiyOk = false;
            try
            {
                isNotiyOk = notiy.Info(user.Name);
            }
            catch (Exception)
            {
                //记录日志等
                //.......
            }
            return isNotiyOk;
        }
    }
}
