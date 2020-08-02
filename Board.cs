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
                Pieces.Add(new Pawn(new Coord(i, 1).ToString(), 0, 0));
                Pieces.Add(new Pawn(new Coord(i, 6).ToString(), 1, 0));
            }
            for (int i = 0; i < 8; i += 7)
            {
                int owner = i % 6;

                Pieces.Add(new Rook(new Coord(0, i).ToString(), owner, 0));
                Pieces.Add(new Rook(new Coord(7, i).ToString(), owner, 0));
                Pieces.Add(new Knight(new Coord(1, i).ToString(), owner, 0));
                Pieces.Add(new Knight(new Coord(6, i).ToString(), owner, 0));
                Pieces.Add(new Bishop(new Coord(2, i).ToString(), owner, 0));
                Pieces.Add(new Bishop(new Coord(5, i).ToString(), owner, 0));
                Pieces.Add(new Queen(new Coord(3, i).ToString(), owner, 0));
                Pieces.Add(new King(new Coord(4, i).ToString(), owner, 0));
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
                string move = origmove.Substring(2, 2) + origmove.Substring(0, 2);
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
            //rules
            if (piece == -1) { return false; }
            if (Pieces[piece].Owner() != Moves.Count%2) { return false; }
            if (target != -1) //target is not empty field
            { 
                if (Pieces[target].Owner() == Moves.Count%2) { return false; }
                if (!Pieces[piece].Captureset().Contains(targetcoord)) { return false; }  //for pawns capture moveset != normal moveset
            } else
                if (!Pieces[piece].Moveset().Contains(targetcoord)) { return false; }
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
                if (piece.GetType() == typeof(King) && piece.Owner() == turn)
                {
                    king = (King)piece;
                }

            //can any enemy Piece reach the king
            foreach (Piece piece in Pieces)
            {
                if (piece.Owner() == turn) { continue; }
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
            Moves.Add(move);
        }

        //returns false if the move was invalid
        public bool move(string move)
        {
            if (!valid(move)) { return false; }
            Move_unchecked(move);
            return true;
        }
        #endregion

    }
}
