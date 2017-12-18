using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestDemo.Tests
{
    public class Atithmetic_Tests
    {
        [Fact]
        public void Add_Ok()
        {
            Arithmetic arithmetic = new Arithmetic();
            var sum = arithmetic.Add(1, 2);
            Assert.True(sum == 3);  //断言验证
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 4)]
        [InlineData(2, 3, 5)]
        public void Add_Ok_Two(int num1, int num2, int result)
        {
            Arithmetic arithmetic = new Arithmetic();
            var sum = arithmetic.Add(num1, num2);
            Assert.True(sum == result);
        }

        [Theory]
        [InlineData(1, 2, 0)]
        [InlineData(1, 3, 0)]
        [InlineData(2, 3, 0)]
        public void Add_No(int num1, int num2, int result)
        {
            Arithmetic arithmetic = new Arithmetic();
            var sum = arithmetic.Add(num1, num2);
            Assert.False(sum == result);
        }

        [Fact]
        public void Divide_Error()
        {
            Arithmetic arithmetic = new Arithmetic();
            Assert.Throws<Exception>(() => { arithmetic.Divide(4, 0); });   //断言 验证异常
        }
    }
}
