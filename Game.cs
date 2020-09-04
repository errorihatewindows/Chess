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
        private Form1 Form;
        public Game(Form1 Form)
        {
            this.Form = Form;
            Board = new Board();
        }

        public Board getBoard() { return Board; }


        public void initPlayer(string p, string g)
        {       
            Player1 = new HumanPlayer();
            Player2 = new HumanPlayer();
            Player1.init(Form);
            Player2.init(Form);
        }
        public void run()
        {
            bool running = true;

            while(running)
            {
                Board.Move_unchecked(Player1.takeTurn(Board));
                Board.Move_unchecked(Player2.takeTurn(Board));
            }
        }


    }
}
