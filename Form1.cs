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

namespace Chess
{
    public partial class Form1 : Form
    {
        private List<Bitmap> Pieces = new List<Bitmap>();
        private List<Tuple<Coord, Color>> HighlightedTiles = new List<Tuple<Coord, Color>>();
        private bool PlayersTurn = false;
        private const int TileSize = 80;
        private Board TestBoard;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //load Piece-Images
            loadImages("Assets/");

            //only Testing
            TestBoard = new Board();
            Board TempBoard = new Board(TestBoard);
            TestBoard.Add();

            Console.WriteLine(TempBoard.Pieces.Count());
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


            HighlightedTiles.Add(Tuple.Create(new Coord("C4"), Color.Blue));
            HighlightedTiles.Add(Tuple.Create(new Coord("B1"), Color.Green));

            DrawBoard(e.Graphics);
            DrawPieces(TestBoard.Pieces, e.Graphics);
            HighlightTiles(HighlightedTiles, e.Graphics);
        }

        private void DrawBoard(Graphics e)
        {
            e.FillRectangle(Brushes.PeachPuff, 0, 0, TileSize * 8, TileSize * 8);

            for (int i = 1; i < 8; i += 2)
                for (int j = 0; j < 8; j += 2)
                    e.FillRectangle(Brushes.Sienna, i * TileSize, j * TileSize, TileSize, TileSize);
            for (int i = 0; i < 8; i += 2)
                for (int j = 1; j < 8; j += 2)
                    e.FillRectangle(Brushes.Sienna, i * TileSize, j * TileSize, TileSize, TileSize);
        }

        private void DrawPieces(List<Piece> Pieces, Graphics e)
        {
            foreach(Piece Piece in Pieces)
                DrawPiece(Piece, e);
        }

        private void DrawPiece(Piece Piece, Graphics e)
        {
            //Piece is Black
            if (util.caps(Piece.Identity))
                e.DrawImage(new Bitmap(Pieces[util.charToNum[Char.ToLower(Piece.Identity)] - 1], TileSize, TileSize), Piece.Position.x * TileSize, (7 - Piece.Position.y) * TileSize);
            //Piece is White
            else
                e.DrawImage(new Bitmap(Pieces[util.charToNum[Piece.Identity] + 6 - 1], TileSize, TileSize), Piece.Position.x * TileSize, (7 - Piece.Position.y) * TileSize);
        }

        private void HighlightTiles(List<Tuple<Coord, Color>> Tiles, Graphics e)
        {
            foreach(Tuple<Coord, Color> Tile in Tiles)
                HighlightTile(Tile.Item1, Tile.Item2, e);
        }

        private void HighlightTile(Coord coords, Color color, Graphics e)
        {
            if (!coords.OutSideBoard())
                e.DrawRectangle(new Pen(color, 5), coords.x * TileSize, (7 - coords.y) * TileSize, TileSize, TileSize);
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
