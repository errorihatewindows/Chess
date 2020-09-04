using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace Chess
{
    static public class util
    {
        //links char of Piece to Bitmap Num
        public static Dictionary<Type, int> charToNum = new Dictionary<Type, int>()
        {
            {typeof(Pawn), 0},
            {typeof(Rook), 1},
            {typeof(Knight), 2},
            {typeof(Bishop), 3},
            {typeof(Queen), 4},
            {typeof(King), 5}
        };

        public static void wait(int milliseconds)
        {
            Timer timer1 = new Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

    }
}
