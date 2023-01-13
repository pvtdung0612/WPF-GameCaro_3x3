using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GameCaro_3x3
{
    class Level2
    {
        public int x = 0, y = 0;

        public Level2(bool[,] aryPly, bool[,] aryCom)
        {
            if (aryCom[1, 1] != true && aryPly[1, 1] != true) { x = 1; y = 1; }
            else
            {
                Random rd = new Random();
                do
                {
                    x = rd.Next(0, 3);
                    y = rd.Next(0, 3);
                }
                while (aryPly[x, y] == true || aryCom[x, y] == true);
            }
        }
    }
}
