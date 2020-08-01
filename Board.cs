using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Board
    {
        private List<Piece> Pieces = new List<Piece>();
        private List<string> Moves = new List<string>();

        public Board()
        {
            InitStartingPos();
        }

        #region getter
        public List<Piece> getPieces() { return Pieces; }
        #endregion

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

        private void revert(int count = 1)
        {
            if (Moves.Count < count) { return; }
            for (int i = 1; i < count+1; i++)
            {
                string origmove = Moves[Moves.Count - i];
                string move = origmove.Substring(2, 2) + origmove.Substring(2, 2);
                //missing transform implementation
                Move_unchecked(move);
            }
        }
        #region rules
        //checks if the given move is valid, ignoring check
        private bool valid_noncheck(string GivenMove)
        {
            //for transforming, GivenMove is move+transform
            string move = GivenMove;
            string targetcoord = move.Substring(2, 2);
            int piece = findCoord(move.Substring(0, 2));
            int target = findCoord(targetcoord);
            //rules as conjunctive normal form
            if (piece == -1) { return false; }
            if (Pieces[piece].Color != Moves.Count%2) { return false; }
            if (target != -1) //target is not empty field
            { 
                if (Pieces[target].Color == Moves.Count%2) { return false; }
                if (!Pieces[target].Captureset().Contains(targetcoord)) { return false; }  //for pawns capture moveset != normal moveset
            } else
                if (!Pieces[target].Moveset().Contains(targetcoord)) { return false; }
            //no piece blocks 
            string[] blocking = Pieces[piece].blocking(targetcoord);
            foreach (string block in blocking)
                foreach (Piece possible in Pieces)
                    if (possible.getPos() == block) { return false; }
            return true;
        }

        //checks if a given move is valid, includes check
        private bool valid (string GivenMove)
        {
            //move is valid except for check
            if (!valid_noncheck(GivenMove)) { return false; }
            //check check
            Move_unchecked(GivenMove);
            bool isCheck = check(true);
            revert();
            return isCheck;
        }

        private bool check(bool enemy = false)
        {
            //if enemy is set, check if the enemy king is check instead of own 
            int turn = Moves.Count % 2;
            if (enemy) { turn = (turn+1)% 2; }
            int eturn = (turn + 1) % 2;
            King king = null;

            //find King of the player to be checked
            foreach (Piece piece in Pieces)
                if (piece.GetType() == typeof(King) && piece.Color == turn)
                {
                    king = (King)piece;
                }

            //can any enemy Piece reach the king
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == turn) { continue; }
                string move = piece.getPos() + king.getPos();
                if (valid_noncheck(move)) { return false; }
            }
            return true;
        }
        #endregion

        #region moves
        public void Move_unchecked(string move)
        {
            //if target is a piece capture it
            int target = findCoord(move.Substring(2, 2));
            if (target != -1) { Pieces.RemoveAt(target); }
            int piece = findCoord(move.Substring(0, 2));
            Pieces[piece].move(move.Substring(2, 2));
        }
        #endregion

    }
}
