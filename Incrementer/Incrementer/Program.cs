using System;
using System.Timers;

namespace Incrementer
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.start();
        }
    }
}
