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
        private string Move;
        private bool Move_Finish;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ClientSize = new Size(TileSize * 8, TileSize * 8);

            //load Piece-Images
            LoadImages("Assets/");
        }

        #region Input

        private string TakeTurn()
        {
            Move_Finish = false;
            Move = string.Empty;
            PlayersTurn = true;

            while(!Move_Finish || Move.Length < 4)
            {
                Application.DoEvents();
            }

            Console.WriteLine(Move);
            PlayersTurn = false;
            HighlightedTiles.Clear();
            Refresh();
            return Move;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (PlayersTurn && GetTile(e.X, e.Y) != null)
            {
                //override Move
                if (Move.Length == 4) 
                { 
                    Move = string.Empty; 
                    HighlightedTiles.Clear(); 
                }

                //Add Position
                Move += GetTile(e.X, e.Y);
                HighlightedTiles.Add(Tuple.Create(new Coord(GetTile(e.X, e.Y)), Color.Blue));
                Refresh();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (PlayersTurn)
            {
                //Delet current Input
                if (e.KeyCode == Keys.Escape)
                {
                    Move = string.Empty;
                    HighlightedTiles.Clear();
                    Refresh();
                }
                //Move Completed
                if (e.KeyCode == Keys.Enter && Move.Length > 3)
                    Move_Finish = true;
            }

            if(e.KeyCode == Keys.Down)
                TakeTurn();
        }



        #endregion

        #region Drawing
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Board TestBoard = new Board();

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
            int n = 0;
            //Picture offset if White
            if (Piece.Color == 'W') { n = 6; }
            e.DrawImage(new Bitmap(Pieces[util.charToNum[Piece.GetType()] + n - 1], TileSize, TileSize), Piece.x() * TileSize, (7 - Piece.y()) * TileSize);
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





        //util functions
        //---------------------------------------------------------
        private void LoadImages(string path)
        {
            for (int i = 1; i < 13; i++)
                Pieces.Add(new Bitmap(path + i.ToString() + ".png"));
        }

        private string GetTile(int x, int y)
        {
            Coord coord = new Coord(x / TileSize, 7 - (y / TileSize));
            if (!coord.OutSideBoard())
                return coord.ToString();
            return null;
        }


    }
}
