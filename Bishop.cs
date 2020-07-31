using System;
using System.Collections.Generic;
using System.Linq;
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
