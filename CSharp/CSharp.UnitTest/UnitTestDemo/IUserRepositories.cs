using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Domain;

namespace UnitTestDemo
{
    public interface IUserRepositories
    {
        void Add(User model);
    }
}
