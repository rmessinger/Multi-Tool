using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesSim
{
    public class Simulation
    {
        Field field;
        Graphics graphics;

        public Simulation()
        {
            this.field = new Field(50, 120);
            
            Console.CursorVisible = false;
        }

        public void Setup()
        {
            foreach (int column in Enumerable.Range(0, Console.WindowWidth - 1))
            {
                foreach (int row in Enumerable.Range(0, Console.WindowHeight - 1))
                {
                    if (column < 20)
                    {
                        field.AddGuy(new Guy('X', row, column, ConsoleColor.Red));
                    }
                    else if (column > Console.WindowWidth - 22)
                    {
                        field.AddGuy(new Guy('O', row, column, ConsoleColor.Green));
                    }
                }
            }
        }

        public void Run()
        {
            field.Draw();
        }
    }
}
