using System;
using MarkovChainTextGenerator;

namespace TextTools
{
    class Program
    {
        static void Main(string[] args)
        {
            // C:\Users\reidm\OneDrive\Documents\TextGen\ASoIaF
            var testObject = new WordGenerator();
            testObject.Run();
            // Console.WriteLine(MarkovChainTextGenerator.Markov.Generate("C:\\Users\\reidm\\OneDrive\\Documents\\TextGen\\Station11\\Input.txt", 1, 500));
            // System.IO.File.WriteAllText(@"C:\Users\reidm\\OneDrive\Documents\TextGen\Station11\Output.txt", MarkovChainTextGenerator.Generator.Markov(@"C:\Users\reidm\\OneDrive\Documents\TextGen\Station11\Input.txt", 2, 500));
        }
    }
}
