using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Sort.BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int count = 1000;
            int testCount = 10;
            list = Seed(count);
            //原始数据
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            //排序后的数据
            Console.WriteLine("**************************");
            for (int i = 0; i < testCount; i++)
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                list = BubbleSort(list);
                watch.Stop();
                Console.WriteLine($"第{i+1}次，冒泡排序{count}个数耗时：{watch.ElapsedMilliseconds}ms");
            }

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
        }
        /// <summary>
        /// 冒泡排序算法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static List<int> BubbleSort(List<int> list)
        {
            int temp;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = list.Count - 1; j > i; j--)
                {
                    if (list[j - 1] > list[j])
                    {
                        temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
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
}
