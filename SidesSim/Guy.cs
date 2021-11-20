using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidesSim
{
    public class Guy
    {
        public char Symbol { get; private set; }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public ConsoleColor Color { get; private set; }

        public Guy(char symbol, int startRow, int startColumn, ConsoleColor color = ConsoleColor.White)
        {
            this.Symbol = symbol;
            this.Row = startRow;
            this.Column = startColumn;
            this.Color = color;
        }
    }
}
