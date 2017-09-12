using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace DailyCode.DotNet._201709
{
    public class CSharp6
    {
        /// <summary>
        /// nameof表达式
        /// </summary>
        /// <param name="param"></param>
        public void ThrowArgumentNullExceptionUsingNameOf(string param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
        }
    }
}
