using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chess
{
    class Coord
    {
        //coordinates are stored as (0,0) (bottom left corner)
        //but can also be read/set as "A1" (same coordinate)
        public int x;
        public int y;

        public Coord(int X, int Y)
        {
            set(X, Y);
        }

        public Coord(string input)
        {
            set(input);
        }

        public void set(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public void set(string input)
        {
            y = input[0] - 'A';
            x = input[1] - '1';
        }

        public override string ToString()
        {
            string output = "";
            output += Convert.ToChar(y + 'A');
            output += Convert.ToChar(x + '1');
            return output;
        }
    }
}
