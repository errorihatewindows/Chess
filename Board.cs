﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        public List<Piece> Pieces = new List<Piece>();
        public Board()
        {
            InitStartingPos();
        }
        public Board(Board Testboard)
        {
            this.Pieces = Testboard.Pieces;
        }




        public void Add()
        {
            Pieces.Add(new Piece(new Coord("D4"), 'p'));
        }
        









        //---------------------------------------
        private void InitStartingPos()
        {
            for (int i = 0; i < 8; i++)
                Pieces.Add(new Piece(new Coord(i, 1), 'p'));
        }

    }
}
