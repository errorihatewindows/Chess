using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chess
{
    [Serializable]
    class Board
    {
        public List<Piece> Pieces = new List<Piece>();
        public Board()
        {
            InitStartingPos();
        }

        //returns Deep-Copy of this Board
        public Board Copy()
        {
            return util.Clone(this);
        }



        public void Add()
        {
            Pieces.Add(new Piece(new Coord("D4"), 'p'));
        }
        







        //---------------------------------------
        private void InitStartingPos()
        {
            for (int i = 0; i < 8; i++)
                Pieces.Add(new Piece(new Coord(i, 1), 'p'));
        }

    }
}
