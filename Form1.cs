using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Board = System.Collections.Generic.Dictionary<Chess.Coord, char>;
using Piece = System.Collections.Generic.KeyValuePair<Chess.Coord, char>;

namespace Chess
{
    public partial class Form1 : Form
    {
        private List<Bitmap> Pieces = new List<Bitmap>();
        private List<Tuple<Coord, Color>> HighlightedTiles = new List<Tuple<Coord, Color>>();
        private bool PlayersTurn = false;
        private const int Size = 80;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //load Piece-Images
            loadImages("Assets/");
        }

        #region Input

        private string TakeTurn()
        {
            string Move = string.Empty;
            PlayersTurn = true;

            //wait for completion of move

            PlayersTurn = false;
            HighlightedTiles.Clear();
            return Move;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (PlayersTurn)
            {
                //Highlight clikced Piece (if own piece)
                
                //Highlight all possible target positions
            }
        }

        #endregion





        #region Drawing
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Board testBoard = new Board();
            testBoard.Add(new Coord("B3"), 'N');
            testBoard.Add(new Coord("A8"), 'q');

            HighlightedTiles.Add(Tuple.Create(new Coord("C4"), Color.Red));

            DrawBoard(e.Graphics);
            DrawPieces(testBoard, e.Graphics);
            HighlightTiles(HighlightedTiles, e.Graphics);
        }

        private void DrawBoard(Graphics e)
        {
            e.FillRectangle(Brushes.PeachPuff, 0, 0, Size * 8, Size * 8);

            for (int i = 1; i < 8; i += 2)
                for (int j = 0; j < 8; j += 2)
                    e.FillRectangle(Brushes.Sienna, i * Size, j * Size, Size, Size);
            for (int i = 0; i < 8; i += 2)
                for (int j = 1; j < 8; j += 2)
                    e.FillRectangle(Brushes.Sienna, i * Size, j * Size, Size, Size);
        }

        private void DrawPieces(Board Board, Graphics e)
        {
            foreach(Piece Piece in Board)
                DrawPiece(Piece, e);
        }

        private void DrawPiece(Piece Piece, Graphics e)
        {
            //Piece is Black
            if (util.caps(Piece.Value))
                e.DrawImage(new Bitmap(Pieces[util.charToNum[Char.ToLower(Piece.Value)] - 1], Size, Size), Piece.Key.x * Size, (7 - Piece.Key.y) * Size);
            //Piece is White
            else
                e.DrawImage(new Bitmap(Pieces[util.charToNum[Piece.Value] + 6 - 1], Size, Size), Piece.Key.x * Size, (7 - Piece.Key.y) * Size);
        }

        private void HighlightTiles(List<Tuple<Coord, Color>> Tiles, Graphics e)
        {
            foreach(Tuple<Coord, Color> Tile in Tiles)
                HighlightTile(Tile.Item1, Tile.Item2, e);
        }

        private void HighlightTile(Coord coords, Color color, Graphics e)
        {
            e.DrawRectangle(new Pen(color, 4), coords.x * Size, (7 - coords.y) * Size, Size, Size);
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
