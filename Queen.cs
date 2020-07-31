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
            int x = this.x();
            int y = this.y();
            while (x > 0 && y > 0)
            {
                x--; y--;
                Possible.Add((new Coord(x, y)).ToString());
            }
            x = this.x();
            y = this.y();
            while (x < 7 && y > 0)
            {
                x++; y--;
                Possible.Add((new Coord(x, y)).ToString());
            }
            x = this.x();
            y = this.y();
            while (x < 7 && y < 7)
            {
                x++; y++;
                Possible.Add((new Coord(x, y)).ToString());
            }
            x = this.x();
            y = this.y();
            while (x > 0 && y < 7)
            {
                x--; y++;
                Possible.Add((new Coord(x, y)).ToString());
            }
            return Possible.ToArray();

        }

    }
}
