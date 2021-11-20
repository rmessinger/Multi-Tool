using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplications.Decider
{
    public class Decider
    {
        public void Run()
        {
            List<string?> options = new List<string?>();

            Console.WriteLine("Enter choices");

            string? lastEntry = String.Empty;
            Console.CursorTop += 1;
            Console.WriteLine("-------Current Options-------");
            Console.CursorTop -= 2;
            while (true)
            {
                lastEntry = Console.ReadLine();
                Console.CursorTop--;
                if (string.IsNullOrEmpty(lastEntry))
                {
                    break;
                }
                options.Add(lastEntry);
                Console.Write(new string(' ', lastEntry.Length));
                Console.CursorLeft -= lastEntry.Length;
                Console.CursorTop += options.Count + 1;
                Console.WriteLine("  " + lastEntry);
                Console.CursorTop -= options.Count + 2;
            }

            Random rand = new Random();
            var endTime = DateTime.Now.AddSeconds(7);
            int startLine = Console.CursorTop + 2;
            int endLine = startLine + options.Count - 1;
            int currentLine = startLine;
            int optionIndex = 0;
            int currentRotation = 0;
            int maxRotations = rand.Next(2, 5);
            int decisionIndex = rand.Next(options.Count - 1);
            int dwellTime = 20;
            int maxDwellTime = 250;
            int dwellStep = (maxDwellTime - dwellTime) / (maxRotations * options.Count);
            bool stop = false;

            Console.CursorVisible = false;

            while (currentRotation <= maxRotations)
            {
                if (currentLine > endLine)
                {
                    currentRotation++;
                    currentLine = startLine;
                    optionIndex = 0;
                }

                if (currentRotation == maxRotations)
                {
                    stop = true;
                }

                Console.CursorTop = currentLine;
                Console.Write(new string(' ', options[optionIndex].Length + 2));
                Console.CursorLeft = 0;
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("> ");
                Console.ForegroundColor = originalColor;
                Console.Write(options[optionIndex]);
                if (stop && optionIndex == decisionIndex)
                {
                    System.Threading.Thread.Sleep(500);
                    break;
                }

                System.Threading.Thread.Sleep(dwellTime);
                dwellTime += dwellStep;
                Console.CursorLeft = 0;
                Console.Write(new string(' ', options[optionIndex].Length + 2));
                Console.CursorLeft = 0;
                Console.Write("  " + options[optionIndex]);
                optionIndex++;
                currentLine++;
                Console.CursorTop++;
            }

            Console.CursorTop = 1;
            Console.Beep();
            Console.WriteLine($"Your choice is {options[decisionIndex]}. I have spoken");
            Console.ReadLine();
        }
    }
}
