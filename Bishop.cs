using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(string Position, char Color, int MoveCount) : base(Position, Color, MoveCount)
        {

        }

        public override string[] Moveset()
        {
            List<string> Possible = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                int y = (this.y() - this.x()) + i;
                if (y == this.y() && i == this.x()) { continue; } 
                if (!new Coord(i, y).OutSideBoard())
                    Possible.Add(new Coord(i, y).ToString());
                y = (this.x() + this.y()) - i;
                if (!new Coord(i, y).OutSideBoard())
                    Possible.Add(new Coord(i, y).ToString());
            }
            return Possible.ToArray();
        }

    }
}
