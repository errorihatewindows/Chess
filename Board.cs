using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
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
            }
            for (int i = 0; i < 8; i += 7)
            {
                char Color = 'W';
                if (i == 7) { Color = 'B'; }

                Pieces.Add(new Rook(new Coord(0, i).ToString(), Color, 0));
                Pieces.Add(new Rook(new Coord(7, i).ToString(), Color, 0));
                Pieces.Add(new Knight(new Coord(1, i).ToString(), Color, 0));
                Pieces.Add(new Knight(new Coord(6, i).ToString(), Color, 0));
                Pieces.Add(new Bishop(new Coord(2, i).ToString(), Color, 0));
                Pieces.Add(new Bishop(new Coord(5, i).ToString(), Color, 0));
                Pieces.Add(new Queen(new Coord(3, i).ToString(), Color, 0));
                Pieces.Add(new King(new Coord(4, i).ToString(), Color, 0));
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
