using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Chess
{
    static public class util
    {
        //links char of Piece to Bitmap Num
        public static Dictionary<Type, int> charToNum = new Dictionary<Type, int>()
        {
            {typeof(Pawn), 0},
            {typeof(Bishop), 1},
            {typeof(Knight), 2},
            {typeof(Rook), 3},
            {typeof(Queen), 4},
            {typeof(King), 5}
        };
    }
}
