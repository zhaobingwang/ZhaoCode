using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCode.DotNet.ClassLibrary.Modifiers
{
    /*
     * 参考：https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/const
     * 使用 const 关键字来声明某个常量字段或常量局部变量。 常量字段和常量局部变量不是变量并且不能修改。 常量可以为数字、布尔值、字符串或 null 引用。 不要创建常量来表示你需要随时更改的信息。 例如，不要使用常量字段来存储服务的价格、产品版本号或公司的品牌名称。 这些值会随着时间发生变化；因为编译器会传播常量，所以必须重新编译通过库编译的其他代码以查看更改。 另请参阅 readonly 关键字
     */
    public class ConstSample
    {
        public int x;
        public int y;
        public const int a = 5;
        public const int b = a + 5;

        public ConstSample()
        {
            x = 1;
        }
        public ConstSample(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
}
