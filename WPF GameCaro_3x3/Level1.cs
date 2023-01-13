using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GameCaro_3x3
{
    public class Level1
    {
        public int x, y;

        public Level1(bool[,] aryPly,bool[,] aryCom)
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
