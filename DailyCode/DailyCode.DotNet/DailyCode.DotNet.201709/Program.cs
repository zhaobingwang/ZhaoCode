using DailyCode.DotNet.ClassLibrary.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCode.DotNet._201709
{
    class Program
    {
        static void Main(string[] args)
        {
            #region nameof
            //CSharp6 csharp6 = new CSharp6();
            //csharp6.ThrowArgumentNullExceptionUsingNameOf(""); 
            #endregion

            #region const关键字
            Console.WriteLine("**********const关键字 start **********");
            ConstSample sampleConst = new ConstSample();
            Console.WriteLine($"x={sampleConst.x},y={sampleConst.y}");  //output:x=1,y=2
            Console.WriteLine($"a={ConstSample.a},b={ConstSample.b}");  //output:a=5,b=10
            Console.WriteLine("**********const关键字 end **********\n");
            #endregion

            #region readonly关键字
            Console.WriteLine("***********readonly关键字 start***********");

            ReadonlySample sampleReadonly1 = new ReadonlySample(11, 21, 32);
            Console.WriteLine($"sampleReadonly1: x={sampleReadonly1.x},x={sampleReadonly1.y},z={sampleReadonly1.z}");
            //output: sampleReadonly1: x=11,x=21,z=32
            ReadonlySample sampleReadonly2 = new ReadonlySample();
            sampleReadonly2.x = 12;
            //sampleReadonly2.y = 13; //ERROR:A readonly field cannot be assigned to (except in a constructor or a variable initializer)
            Console.WriteLine($"sampleReadonly2: x={sampleReadonly2.x},x={sampleReadonly2.y},z={sampleReadonly2.z}");
            //outout: sampleReadonly2: x=12,x=20,z=30

            Console.WriteLine("***********readonly关键字 end***********\n");
            #endregion
        }
    }
}
