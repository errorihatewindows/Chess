using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Game
    {
        private Player Player1, Player2;
        private Board Board;
        public Game()
        {
           
        }

        public Board getBoard() { return Board; }


        public void initPlayer(string Player1, string Player2)
        {
            throw new NotImplementedException("not yet implemented");
        }
        public void run()
        {
            Board = new Board();
            bool running = true;

            while(running)
            {
                Board.move(Player1.takeTurn(Board));
                Board.move(Player2.takeTurn(Board));
            }
        }


    }
}
