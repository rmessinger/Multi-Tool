using System;
using System.Diagnostics;

namespace MiddleMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // OMDbComms comms = new OMDbComms("4163855c");
            // Console.WriteLine(comms.getTitleData("Knives Out"));
            WGetter wgetTool = new WGetter();
            string output = wgetTool.getURLContent("https://www.imdb.com/search/keyword/?keywords=old-man&ref_=ttkw_kw_13");
            System.IO.File.WriteAllText("results.txt", output);
            stopwatch.Stop();
            Console.WriteLine($"Execution took: {stopwatch.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }
    }
}
