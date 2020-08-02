using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(string Position, int owner, int MoveCount) : base(Position, owner, MoveCount)
        {

        }

        public override string[] Moveset()
        {
            string[] Possible = new string[14];
            int n = 0;
            for (int i = 0; i < 8; i++)
            {
                if (!(i == x()))
                {
                    Possible[n] = new Coord(i, y()).ToString();
                    n++;
                }
                if (!(i == y()))
                {
                    Possible[n] = new Coord(x(), i).ToString();
                    n++;
                }
            }
            return Possible;
        }
    }
}
