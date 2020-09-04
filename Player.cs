using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    interface Player
    {
       string takeTurn(Board currentBoard);

       void init(Form1 UI);
    }
}
