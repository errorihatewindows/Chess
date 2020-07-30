using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(string Position, char Color, int MoveCount) : base(Position, Color, MoveCount)
        {

        }

        //knights dont get blocked
        public override string[] blocking(string Target)
        {
            return new string[0];
        }
    }
}
