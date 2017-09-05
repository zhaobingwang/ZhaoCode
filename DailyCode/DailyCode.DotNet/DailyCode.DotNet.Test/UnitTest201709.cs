using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyCode.DotNet._201709;

namespace DailyCode.DotNet.Test
{
    [TestClass]
    public class UnitTest201709
    {
        [TestMethod]
        public void NameOf_UsingNameofExpressionInArgumentNullException()
        {
            try
            {
                CSharp6 csharp6 = new CSharp6();
                csharp6.ThrowArgumentNullExceptionUsingNameOf(null);
                Assert.Fail("代码不应该执行到此处");
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual<string>("param", exception.ParamName);
            }
        }
    }
}
