using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    abstract class Piece
    {
        private Coord Position;
        public int MoveCount;
        public char Color;

        public Piece(string Position, char Color, int MoveCount)
        {
            this.Color = Color;
            this.Position = new Coord(Position);
            this.MoveCount = MoveCount;
        }

        #region getter
        public int x() { return Position.x; }
        public int y() { return Position.y; }
        public string getPos() { return Position.ToString(); }
        #endregion

        public void move(string target) { Position.set(target); }

        public virtual string[] blocking(string Target) //list of fields between target and current coords
        {
            Coord target = new Coord(Target);
            Coord direction = new Coord(0, 0);  //direction the target is in
            if (target.x != 0)
                direction.x = 1;
            if (target.y != 0)
                direction.y = 1;
            //distance from 1 point to the next on 1 axis
            int distance = (target.x + target.y) / (direction.x + direction.y);
            Coord current = new Coord(Position.ToString());
            string[] output = new string[distance - 1];
            for (int i = 1; i < distance; i++)
            {
                current.x += direction.x;
                current.y += direction.y;
                output[i - 1] = current.ToString();
            }
            return output;
        }
        //list of all moves (if board is empty) each Piece implements this
        public abstract string[] Moveset();

        //list of all captures, for non-Pawn this is the same as Movelist
        public virtual string[] Captureset()
        {
            return Moveset();
        }

    }
}
