using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Piece
    {
        public Coord Position;
        public int MoveCount;
        public char Color;

        public Piece(Coord Position, char Color, int MoveCount)
        {
            this.Color = Color;
            this.Position = Position;
            this.MoveCount = MoveCount;
        }



    }
}
