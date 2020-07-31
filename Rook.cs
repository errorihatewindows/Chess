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
            int x = this.x();
            while(x < 7)
            {
                x++;
                Possible[Possible.Length - 1] = new Coord(x, this.y()).ToString();
            }
            x = this.x();
            while (x > 0)
            {
                x--;
                Possible[Possible.Length - 1] = new Coord(x, this.y()).ToString();
            }
            int y = this.y();
            while (y < 7)
            {
                y++;
                Possible[Possible.Length - 1] = new Coord(this.x(), y).ToString();
            }
            y = this.y();
            while (y > 0)
            {
                y--;
                Possible[Possible.Length - 1] = new Coord(this.x(), y).ToString();      
            }

            return Possible;
        }
    }
}
