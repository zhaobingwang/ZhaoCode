using System;
using System.Collections.Generic;
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
            list = Seed(10);
            //原始数据
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            //排序后的数据
            Console.WriteLine("**************************");
            list = BubbleSort(list);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
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
