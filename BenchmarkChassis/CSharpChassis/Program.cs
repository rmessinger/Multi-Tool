using System;
using System.Diagnostics;

namespace BenchmarkChassis
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int upperBound = 100000;
            if (args.Length > 0)
            {
                upperBound = int.Parse(args[0]);
            }

            int counter = 0;
            stopwatch.Start();

            while (counter < upperBound)
            {
                counter++;
            }

            stopwatch.Stop();
            Console.WriteLine($"{counter} iterations took: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
