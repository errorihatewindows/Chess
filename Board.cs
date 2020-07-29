using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    [Serializable]
    class Board
    {
        public List<Piece> Pieces;

        public Board()
        {
            InitStartingPos();
        }

        //returns Deep-Copy of this Board
        public Board Copy()
        {
            return util.Clone(this);
        }



        //---------------------------------------
        private void InitStartingPos()
        {
            Pieces = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                Pieces.Add(new Pawn(new Coord(i, 1), 'W', 0));
                Pieces.Add(new Pawn(new Coord(i, 6), 'B', 0));
            }
                           
        }

    }
}
