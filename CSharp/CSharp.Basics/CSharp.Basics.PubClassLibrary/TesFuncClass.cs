using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Basics.PubClassLibrary
{
    public class TesFuncClass
    {
        public static string SayHi(string name, int age, string location)
        {
            return $"I'm {name}, {age} years old,from {location}";
        }
    }
}
