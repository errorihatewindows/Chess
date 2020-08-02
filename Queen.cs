using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(string Position, int owner, int MoveCount) : base(Position, owner, MoveCount)
        {

        }

        public override string[] Moveset()
        {
            //straight
            List<string> Possible = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                if (!(i == this.x()))
                    Possible.Add(new Coord(i, this.y()).ToString());
                if (!(i == this.y()))
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
