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
    static public class util
    {
        //checks if char Input is UpperCase
        static public bool caps(char input)
        {
            if (input <= 90 && input >= 65)
                return true;
            else
                return false;
        }

        //links char of Piece to Bitmap Num
        public static Dictionary<char, int> charToNum = new Dictionary<char, int>()
        {
            {'p', 1},
            {'b', 2},
            {'n', 3},
            {'r', 4},
            {'q', 5},
            {'k', 6}
        };

    }
}
