using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(string Position, char Color, int MoveCount) : base(Position, Color, MoveCount)
        {

        }

        public override string[] Moveset()
        {
            //straight
            List<string> Possible = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                if (i == this.x()) { continue; }
                Possible.Add(new Coord(i, this.y()).ToString());
            }
            for (int i = 0; i < 8; i++)
            {
                if (i == this.y()) { continue; }
                Possible.Add(new Coord(this.x(), i).ToString());
            }

            //diagonal
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
