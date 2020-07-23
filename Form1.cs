using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Board = System.Collections.Generic.Dictionary<Chess.Coord, char>;
using Piece = System.Collections.Generic.KeyValuePair<Chess.Coord, char>;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Coord test1 = new Coord(0, 0);
            Coord test2 = new Coord("C8");
            Console.WriteLine("test1: {0} \ntest2: {1} , {2}", test1.ToString(), test2.x, test2.y);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(new Board(), e.Graphics);
        }

        private void DrawBoard(Board Board, Graphics e)
        {
            foreach(Piece Piece in Board)
                DrawPiece(Piece, e);
        }

        private void DrawPiece(Piece Piece, Graphics e)
        {

        }
    }
}
