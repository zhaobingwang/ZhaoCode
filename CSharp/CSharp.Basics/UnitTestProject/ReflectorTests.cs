using CSharp.Basics.PubClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject
{
    public class TestReflector
    {

        [Fact]
        public void Direct_Test()
        {
            var success = true;
            for (int i = 0; i < 1000000; i++)
            {
                var instance = new TesFuncClass();
                if (instance == null)
                {
                    success = false;
                }
            }

            Assert.True(success);
        }
        [Fact]
        public void Reflector_Test()
        {
            var success = true;
            for (int i = 0; i < 1000000; i++)
            {
                var instance = Assembly.Load("CSharp.Basics.PubClassLibrary").CreateInstance("CSharp.Basics.PubClassLibrary.TesFuncClass");
                if (instance==null)
                {
                    success = false;
                }
            }

            Assert.True(success);
        }
    }
}
