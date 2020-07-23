using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Board = System.Collections.Generic.Dictionary<Chess.Coord, char>;

namespace Chess
{
    static class util
    {
        static bool caps(char input)
        {
            if (input <= 90 && input >= 65)
                return true;
            else
                return false;
        }

    }
}
