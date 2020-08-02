using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(string Position, int owner, int MoveCount) : base(Position, owner, MoveCount)
        {

        }

        //knights dont get blocked
        public override string[] blocking(string Target)
        {
            return new string[0];
        }

        public override string[] Moveset()
        {
            List<string> Possible = new List<string>();
            for (int j = -2; j <= 2; j += 4)
                for (int i = - 1; i <= 1; i += 2)
                {
                    if (!new Coord(x() + i, y() + j).OutSideBoard())
                        Possible.Add(new Coord(x() + i, y() + j).ToString());
                    if (!new Coord(x() + j, y() + i).OutSideBoard()) 
                        Possible.Add(new Coord(x() + j, y() + i).ToString());
                }
            return Possible.ToArray();
        }
    }
}
