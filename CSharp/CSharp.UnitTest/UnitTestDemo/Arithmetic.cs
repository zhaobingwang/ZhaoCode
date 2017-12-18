using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public class Arithmetic
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public decimal Divide(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new Exception("除数不能为零");
            }
            return num1 / num2;
        }
    }
}
