using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesSim
{
    public class Field
    {
        private List<Guy> guys = new List<Guy>();

        public Field(int rows, int columns)
        {
            Console.SetWindowSize(columns, rows);
        }

        public void Draw()
        {
            foreach (var guy in guys)
            {
                DrawGuy(guy);
            }

            Console.SetCursorPosition(0, 0);
        }

        public void AddGuy(Guy guy)
        {
            this.guys.Add(guy);
        }

        private void DrawGuy(Guy guy)
        {
            int originalColumn = Console.CursorLeft;
            int originalRow = Console.CursorTop;
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.SetCursorPosition(guy.Column, guy.Row);
            Console.ForegroundColor = guy.Color;
            Console.Write(guy.Symbol);
            Console.ForegroundColor = originalColor;
            Console.SetCursorPosition(originalColumn, originalRow);
        }
    }
}
