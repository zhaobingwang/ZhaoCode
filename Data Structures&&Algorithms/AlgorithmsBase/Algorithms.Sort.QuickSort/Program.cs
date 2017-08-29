using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Sort.QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            //list.Add(7);
            //list.Add(5);
            //list.Add(10);
            //list.Add(8);
            //list.Add(1);
            //list.Add(4);
            //list.Add(3);
            //list.Add(9);
            //list.Add(2);
            //list.Add(6);
            //list.Add(10);
            int count = 1000;
            int testCount = 10;
            string before = string.Empty;
            string after = string.Empty;
            QuickSortClass quick = new QuickSortClass();
            list = Seed(count);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    before += list[i].ToString() + "  ";
            //}
            //Console.WriteLine($"原始集合：{before}");

            //quick.QuickSort(list, 0, list.Count - 1);
            //int left=quick.Division(list, 0, list.Count - 1);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    after += list[i].ToString() + "  ";
            //}
            //Console.WriteLine(left);
            //Console.WriteLine($"快速排序：{after}");


            for (int i = 0; i < testCount; i++)
            {
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var result = list.OrderBy(a => a).ToList();
                watch.Stop();
                Console.WriteLine($"第{i + 1}次，框架自带快速排序 {count}个数耗时：{watch.ElapsedMilliseconds}ms");
                Console.WriteLine("输出前是十个数:" + string.Join(",", result.Take(10).ToList()));


                watch = new Stopwatch();
                watch.Start();
                quick.QuickSort(list, 0, list.Count-1);
                watch.Stop();
                Console.WriteLine($"第{i + 1}次，快速排序 {count}个数耗时：{watch.ElapsedMilliseconds}ms");
                Console.WriteLine("输出前是十个数:" + string.Join(",", list.Take(10).ToList()));

                
                

                Console.WriteLine("************************");
            }

        }
        /// <summary>
        /// 播种数据
        /// </summary>
        /// <param name="count">产生随机数的个数</param>
        /// <returns></returns>
        static List<int> Seed(int count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(1);
                list.Add(new Random((int)DateTime.Now.Ticks).Next(0, 100000));
            }
            return list;
        }
    }
    public class QuickSortClass
    {
        /// <summary>
        /// 分割函数
        /// </summary>
        /// <param name="list">待排序的集合</param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int Division(List<int> list, int left, int right)
        {
            //首先选择一个基准元素
            int baseNum = list[left];
            while (left < right)
            {
                //1. 从右向左查找，一直找到 小于base 的数为止
                while (left < right && list[right] >= baseNum)
                    right--;
                //1.1 找到了比baseNum小的元素，然后将此元素 放到base的位置
                list[left] = list[right];

                //2. 从左向右查找，找到 大于base 的数为止
                while (left < right && list[left] <= baseNum)
                    left++;
                // 2.1 找到了比baseNum大的元素，放到右边
                list[right] = list[left];
            }
            // 3. 将baseNum放到left位置
            list[left] = baseNum;
            return left;
        }

        public void QuickSort(List<int> list, int left, int right)
        {
            if (left<right)
            {
                int i = Division(list, left, right);
                QuickSort(list, left, i - 1);
                QuickSort(list, i + 1, right);
            }
        }
    }
}
