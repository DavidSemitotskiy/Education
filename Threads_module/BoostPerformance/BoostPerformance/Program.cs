using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostPerformance
{
    public class Program
    {
        public static void Main()
        {
            Random r = new Random();

            decimal[] arr = Enumerable.Range(0, 1000000).Select(_ => (decimal)r.NextDouble()).ToArray();
            decimal sum = 0;

            var sw = Stopwatch.StartNew();

            foreach (var item in arr)
            {
                sum += item;
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
