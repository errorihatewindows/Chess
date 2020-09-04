using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class HumanPlayer : Player
    {
        private Form1 UI;

        public void init(Form1 UI) { this.UI = UI; }

        public string takeTurn(Board currentBoard)
        {
            return UI.takeTurn();
            //TODO: implement advanced behaviour of the player (i dunno what specificly)
        }
    }
}
