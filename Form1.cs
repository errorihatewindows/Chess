using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Board = System.Collections.Generic.Dictionary<System.Tuple<int, int>, char>;
using Coord = System.Tuple<int, int>;
using Piece = System.Collections.Generic.KeyValuePair<System.Tuple<int, int>, char>;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
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
