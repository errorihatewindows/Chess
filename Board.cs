using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Board
    {
        public List<Piece> Pieces;
        private int turn;   //0 means its white's move

        public Board()
        {
            InitStartingPos();
            turn = 0;
        }

        //---------------------------------------
        private void InitStartingPos()
        {
            Pieces = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                Pieces.Add(new Pawn(new Coord(i, 1).ToString(), 'W', 0));
                Pieces.Add(new Pawn(new Coord(i, 6).ToString(), 'B', 0));

                switch (i)
                {
                    case 0:
                        Pieces.Add(new Rook(new Coord(i, 0).ToString(), 'W', 0));
                        Pieces.Add(new Rook(new Coord(i, 7).ToString(), 'B', 0));
                        Pieces.Add(new Rook(new Coord(7 - i, 0).ToString(), 'W', 0));
                        Pieces.Add(new Rook(new Coord(7 - i, 7).ToString(), 'B', 0));
                        break;

                    case 1:
                        Pieces.Add(new Knight(new Coord(i, 0).ToString(), 'W', 0));
                        Pieces.Add(new Knight(new Coord(i, 7).ToString(), 'B', 0));
                        Pieces.Add(new Knight(new Coord(7 - i, 0).ToString(), 'W', 0));
                        Pieces.Add(new Knight(new Coord(7 - i, 7).ToString(), 'B', 0));
                        break;

                    case 2:
                        Pieces.Add(new Bishop(new Coord(i, 0).ToString(), 'W', 0));
                        Pieces.Add(new Bishop(new Coord(i, 7).ToString(), 'B', 0));
                        Pieces.Add(new Bishop(new Coord(7 - i, 0).ToString(), 'W', 0));
                        Pieces.Add(new Bishop(new Coord(7 - i, 7).ToString(), 'B', 0));
                        break;

                    case 3:
                        Pieces.Add(new Queen(new Coord(i, 0).ToString(), 'W', 0));
                        Pieces.Add(new Queen(new Coord(7 - i, 7).ToString(), 'B', 0));
                        break;

                    case 4:
                        Pieces.Add(new King(new Coord(i, 0).ToString(), 'W', 0));
                        Pieces.Add(new King(new Coord(7 - i, 7).ToString(), 'B', 0));
                        break;
                }
            }

        }
                         

        //returns -1 if coord not in the piece list
        private int findCoord(string coordinate)
        {
            for (int i = 0; i < Pieces.Count; i++)
                if (Pieces[i].getPos() == coordinate)
                    return i;
            return -1;
        }

        #region rules
        //checks if the given move is valid
        private bool valid(string GivenMove)
        {
            //for transforming, GivenMove is move+transform
            string move = GivenMove;
            string targetcoord = move.Substring(2, 2);
            int piece = findCoord(move.Substring(0, 2));
            int target = findCoord(targetcoord);
            //rules as conjunctive normal form
            if (piece == -1) { return false; }
            if (Pieces[piece].Color != turn) { return false; }
            if (target != -1)
                if (Pieces[target].Color == turn) { return false; }

            return true;
        }
        #endregion

    }
}
