using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : Piece
    {
        public King(string Position, char Color, int MoveCount) : base(Position, Color, MoveCount)
        {

        }

        public override string[] Moveset()
        {
            List<string> Possible = new List<string>();
            for (int i = - 1; i <= + 1; i++)
                for(int j = - 1; j <= + 1; j++)
                {
                    if ((i == 0 && j == 0) || new Coord(x() + i, y() + j).OutSideBoard()) { continue; }
                    Possible.Add(new Coord(x() + i ,y() + j).ToString());
                }
            return Possible.ToArray();
        }


    }
}
