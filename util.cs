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
            {typeof(Pawn), 1},
            {typeof(Bishop), 2},
            {typeof(Knight), 3},
            {typeof(Rook), 4},
            {typeof(Queen), 5},
            {typeof(King), 6}
        };

        //Deep-Clones a given Object
        public static T Clone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }


    }
}
