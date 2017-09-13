using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCode.DotNet.ClassLibrary.Modifiers
{
    /* 参考：https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/readonly
     * readonly 关键字是一个可在字段上使用的修饰符。 当字段声明包括 readonly 修饰符时，该声明引入的字段赋值只能作为声明的一部分出现，或者出现在同一类的构造函数中。
     * 
     * readonly 关键字不同于 const 关键字。 const 字段只能在该字段的声明中初始化。
     */
    public class ReadonlySample
    {
        public int x;
        //Initialize a readonly field
        public readonly int y = 20;
        public readonly int z;
        public ReadonlySample()
        {
            //Initialize a readonly instance field
            z = 30;
        }
        public ReadonlySample(int p1, int p2, int p3)
        {
            x = p1;
            y = p2;
            z = p3;
        }
    }
}
