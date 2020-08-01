using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(string Position, char Color, int MoveCount) : base(Position, Color, MoveCount)
        {

        }

        public override string[] Moveset()
        {
            string[] Possible = new string[14];
            int n = 0;
            for (int i = 0; i < 8; i++)
            {
                if (i == x()) { continue; }
                Possible[n] = new Coord(i, y()).ToString();
                n++;
            }
            for (int i = 0; i < 8; i++)
            {
                if (i == y()) { continue; }
                Possible[n] = new Coord(x(), i).ToString();
                n++;
            }

            return Possible;
        }
    }
}
