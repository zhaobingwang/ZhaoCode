using System;
using System.Collections.Generic;
using System.Linq;

namespace Equality_and_sort_example
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.对基础类型的排序
            List<int> listBase = new List<int>() { 128, 25, 81 };
            Console.WriteLine("基础类型排序前（List<int>）:");
            foreach (var item in listBase)
            {
                Console.Write($"{item} \t");    // result: 128 25 81
            }
            Console.WriteLine("\n基础类型排序后（List<int>）:");
            // 排序方法一：Sort()
            listBase.Sort();    // 升序排序 result: 25 81 128
            //listBase.Reverse();    //反转 result: 81 25 128
            //排序方法二：使用lambda表达式，前面加个负号：
            //listBase.Sort((x, y) => x.CompareTo(y));    //升序
            //listBase.Sort((x, y) => -x.CompareTo(y));    //降序序
            foreach (var item in listBase)
            {
                Console.Write($"{item} \t");
            }
            Console.WriteLine("\n==========分割线==========");
            #endregion

            #region 2.非基本类型排序
            List<Part> parts = new List<Part>();
            parts.Add(new Part() { PartId = 10001, PartName = "A" });
            parts.Add(new Part() { PartId = 12904, PartName = "x" });
            parts.Add(new Part() { PartId = 10895, PartName = "b" });
            parts.Add(new Part() { PartId = 18003, PartName = "M" });
            parts.Add(new Part() { PartId = 13002, PartName = "C" });
            parts.Add(new Part() { PartId = 13002, PartName = "H" });
            parts.Add(new Part() { PartId = 13002, PartName = "B" });

            Console.WriteLine("Before sort:");
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }

            Console.WriteLine("\nAfter sort by part number:");

            // 方法一：Part实现IComparable<Part>
            //parts.Sort();

            // 方法二：
            //parts.Sort(delegate (Part x, Part y)
            //{
            //    return x.PartId.CompareTo(y.PartId);    //升序
            //});
            //或者
            //parts.Sort((x, y) =>
            //{
            //    return x.PartId.CompareTo(y.PartId);    //升序
            //});

            // 方法三：using System.Linq;
            parts = parts.OrderBy(p => p.PartId).ToList();  //升序
            //parts = parts.OrderByDescending(p => p.PartId).ToList();  //降序


            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }

            // 多权重排序1：Part实现IComparable<Part>
            //parts.Sort();

            // 多权重排序2：
            //parts.Sort((x, y) =>
            //{
            //    int re = x.PartId.CompareTo(y.PartId);
            //    if (re == 0)
            //    {
            //        return x.PartName.CompareTo(y.PartName);
            //    }
            //    return re;
            //});

            // 多权重排序3：using System.Linq;
            parts = parts.OrderBy(p => p.PartId).ThenBy(p => p.PartName).ToList();

            Console.WriteLine("\n多权重排序:");
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }
            #endregion
        }
    }
    public class Part //: IComparable<Part>
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
        public override string ToString()
        {
            return $"ID: {PartId}\t{PartName}";
        }

        // 方法一：Part实现IComparable<Part>
        //public int CompareTo(Part comparePart)
        //{
        //    if (comparePart == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return PartId.CompareTo(comparePart.PartId);
        //    }
        //}


        // 多权重排序
        //public int CompareTo(Part comparePart)
        //{
        //    if (comparePart == null)
        //    {
        //        return 1;
        //    }
        //    int ret = this.PartId.CompareTo(comparePart.PartId);
        //    if (ret == 0)
        //    {
        //        return this.PartName.CompareTo(comparePart.PartName);
        //    }
        //    return ret;
        //}
    }
}
