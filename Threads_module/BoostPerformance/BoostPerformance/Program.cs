using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class Program
    {
        public static void Main()
        {
            //without performance: 76 - 92ms
            //after boost 35 - 42ms
            Random r = new Random();

            decimal[] arr = Enumerable.Range(0, 1000000).Select(_ => (decimal)r.NextDouble()).ToArray();
            decimal sum = 0;
            List<Thread> listThreads = new List<Thread>();
            List<decimal> sumsThreads = new List<decimal>();
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 4; i++)
            {
                int index = i;
                listThreads.Add(new Thread(() =>
                {
                    decimal sumThread = 0;
                    int start = index * 250000;
                    int end = start + 250000;
                    for (int j = start; j < end; j++)
                    {
                        sumThread += arr[j];
                    }

                    lock (sumsThreads)
                    {
                        sumsThreads.Add(sumThread);
                    }
                }));

                listThreads[i].Start();
            }

            for (int i = 0; i < listThreads.Count; i++)
            {
                listThreads[i].Join();
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(sumsThreads.Sum());
        }
    }
}