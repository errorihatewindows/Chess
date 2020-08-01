using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(string Position, char Color, int MoveCount) : base(Position, Color, MoveCount)
        {

        }

        public override string[] Moveset()
        {
            List<string> Possible = new List<string>();
            if (MoveCount == 0)
            {
                Possible.Add(new Coord(x(), y() + 1).ToString());
                Possible.Add(new Coord(x(), y() + 2).ToString());
            }
            else
            {
                Possible.Add(new Coord(x(), y() + 1).ToString());
            }
            return Possible.ToArray();
        }

        public override string[] Captureset()
        {
            List<string> Possible = new List<string>();
            if (!(x() - 1 < 0))
                Possible.Add(new Coord(x() - 1, y() + 1).ToString());
            if (!(x() + 1 > 7))
                Possible.Add(new Coord(x() + 1, y() + 1).ToString());

            return Possible.ToArray();
        }


    }
}
