using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Piece
    {
        public Coord Position;
        public char Identity;
        public int MoveCount;

        public Piece(Coord Position, char Identity)
        {
            this.Position = Position;
            this.Identity = Identity;
            MoveCount = 0;
        }
    }
}
