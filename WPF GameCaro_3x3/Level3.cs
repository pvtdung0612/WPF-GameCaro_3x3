using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GameCaro_3x3
{
    class Level3
    {
        List<int> xs = new List<int>();
        List<int> ys = new List<int>();
        public int x = 5, y = 5;

        public Level3(bool[,] aryPly, bool[,] aryCom)
        {
            // check ô chính giữa
            if (aryCom[1, 1] != true && aryPly[1, 1] != true) { x = 1; y = 1; }
            else
            {
                // check 2 ô thẳng hàng của Computer
                for (int k = 0; k < 3; k = k + 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (aryCom[i, 1] == true)
                        {
                            if (i == 1) // load ô chính giữa
                            {
                                if (aryCom[i - k + 1, i + k - 1] == true) { xs.Add(i + k - 1); ys.Add(i - k + 1); }
                                else if (aryCom[i - k + 1, i - k + 1] == true) { xs.Add(i + k - 1); ys.Add(i + k - 1); }
                            }
                            if (aryCom[i, k] == true) { xs.Add(i); ys.Add(2 - k); }
                        }
                        if (aryCom[1, i] == true)
                        {
                            if (aryCom[k, i] == true) { xs.Add(2 - k); ys.Add(i); }
                        }

                        // check các list x,y vừa thu được xem đã được aryPly đánh hay chưa
                        for (int final = 0; final < xs.Count; final++)
                        {
                            x = xs[final]; y = ys[final];
                            if (aryPly[x, y] != true) return;
                        }
                    }
                }
            }

            // đánh ngẫu nhiên
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