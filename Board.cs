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

                switch (i)
                {
                    case 0:
                        Pieces.Add(new Rook(new Coord(i, 0), 'W', 0));
                        Pieces.Add(new Rook(new Coord(i, 7), 'B', 0));
                        Pieces.Add(new Rook(new Coord(7 - i, 0), 'W', 0));
                        Pieces.Add(new Rook(new Coord(7 - i, 7), 'B', 0));
                        break;

                    case 1:
                        Pieces.Add(new Knight(new Coord(i, 0), 'W', 0));
                        Pieces.Add(new Knight(new Coord(i, 7), 'B', 0));
                        Pieces.Add(new Knight(new Coord(7 - i, 0), 'W', 0));
                        Pieces.Add(new Knight(new Coord(7 - i, 7), 'B', 0));
                        break;

                    case 2:
                        Pieces.Add(new Bishop(new Coord(i, 0), 'W', 0));
                        Pieces.Add(new Bishop(new Coord(i, 7), 'B', 0));
                        Pieces.Add(new Bishop(new Coord(7 - i, 0), 'W', 0));
                        Pieces.Add(new Bishop(new Coord(7 - i, 7), 'B', 0));
                        break;

                    case 3:
                        Pieces.Add(new Queen(new Coord(i, 0), 'W', 0));
                        Pieces.Add(new Queen(new Coord(7 - i, 7), 'B', 0));
                        break;

                    case 4:
                        Pieces.Add(new King(new Coord(i, 0), 'W', 0));
                        Pieces.Add(new King(new Coord(7 - i, 7), 'B', 0));
                        break;
                }
            }

            
                           
        }

    }
}
