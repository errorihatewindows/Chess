using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Board = System.Collections.Generic.Dictionary<Chess.Coordinate, char>;
using Piece = System.Collections.Generic.KeyValuePair<Chess.Coordinate, char>;

namespace Chess
{
    public partial class Form1 : Form
    {
        private List<Bitmap> Pieces = new List<Bitmap>();
        private const int Size = 60;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //load Piece-Images
            loadImages("Assets/");
        }

        #region Drawing
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
            DrawPieces(new Board(), e.Graphics);
        }

        private void DrawBoard(Graphics e)
        {
            e.FillRectangle(Brushes.Wheat, 0, 0, Size * 8, Size * 8);
        }

        private void DrawPieces(Board Board, Graphics e)
        {
            foreach(Piece Piece in Board)
                DrawPiece(Piece, e);
        }

        private void DrawPiece(Piece Piece, Graphics e)
        {

        }
        #endregion






        //---------------------------------------------------------
        private void loadImages(string path)
        {
            for (int i = 1; i < 13; i++)
                Pieces.Add(new Bitmap(path + i.ToString() + ".png"));
        }
    }
}
