using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetConsoleApp.Demo
{
    public class DemoBase : IDemoBase
    {
        public string ReturnValue { get; set; }
        public Demo2 Demo2 { get; set; }
        public string EasyReturn()
        {
            return $"This is the test method to return data:{ReturnValue} - {Demo2.Demo2Property}";
        }
    }
}
