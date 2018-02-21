using System;
using System.Threading;

namespace Csharp.Basic.Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            Account acc = new Account(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
            foreach (var t in threads)
            {
                t.Join();
            }
        }
    }
    class Account
    {
        private object thisLock = new object();
        int balance;
        Random r = new Random();
        public Account(int initial)
        {
            balance = initial;
        }
        int Withdraw(int amount)
        {
            if (balance<0)
            {
                throw new Exception("Negative Banlance");
            }
            lock (thisLock)
            {
                if (balance > amount)
                {
                    Console.WriteLine($"Balance before Withdrawal: {balance}");
                    Console.WriteLine($"Amount to Withdraw: -{amount}");
                    balance = balance - amount;
                    Console.WriteLine($"Balance after Withdrawal: {balance}");
                    return amount;
                }
                else
                {
                    return 0;
                }
            }
        }
        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(r.Next(1, 100));
            }
        }
    }
}
