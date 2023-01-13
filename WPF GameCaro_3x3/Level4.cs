using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GameCaro_3x3
{
    class Level4
    {
        List<int> xs = new List<int>();
        List<int> ys = new List<int>();
        int[] listcountCell = new int[5];// có tác dụng theo từng ô: |số ô không nên đánh|x|y|x0|y0| (x,y là ô nên đánh; không nên đánh!= đã đánh)
        bool[,] ary1;
        bool[,] ary2;
        bool[,] ary3_1;
        bool[,] ary4;
        public int x = 0, y = 0;
        Random rd = new Random();

        public Level4(bool[,] aryPly, bool[,] aryCom)
        {
            if (aryCom[1, 1] != true && aryPly[1, 1] != true) { x = 1; y = 1; } // level2 (ô chính giữa)
            else
            {
                #region level3 (ô phải đánh để win hoặc chặn win)
                for (int count = 0; count < 2; count++)
                {
                    // ary1 = aryCom trước vì có xu hướng thắng trước
                    if (count == 0) { ary1 = aryCom; ary2 = aryPly; }
                    else { ary1 = aryPly; ary2 = aryCom; }

                    #region check 2 ô kề cùng dấu
                    for (int k = 0; k < 3; k = k + 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (ary1[i, 1] == true)
                            {
                                if (i == 1) // load ô chính giữa
                                {
                                    if (ary1[i - k + 1, i + k - 1] == true) { xs.Add(i + k - 1); ys.Add(i - k + 1); }
                                    if (ary1[i - k + 1, i - k + 1] == true) { xs.Add(i + k - 1); ys.Add(i + k - 1); }
                                }
                                if (ary1[i, k] == true) { xs.Add(i); ys.Add(2 - k); } // load dọc
                            }
                            if (ary1[1, i] == true)
                            {
                                if (ary1[k, i] == true) { xs.Add(2 - k); ys.Add(i); } // load ngang
                            }
                        }
                    }
                    #endregion

                    #region check 2 ô cùng dấu đối xứng qua 1 ô
                    // chắc chắn bỏ trường hợp ary2 chưa đánh ô giữa => chỉ check 4 trường hợp
                    for (int k = 0; k < 3; k = k + 2)
                    {
                        if (ary1[k, k] == true)
                        {
                            if (ary1[k, 2 - k] == true) { xs.Add(k); ys.Add(1); }
                            if (ary1[2 - k, k] == true) { xs.Add(1); ys.Add(k); }
                        }
                    }
                    #endregion

                    #region check các list x,y vừa thu được xem đã được ary2 đánh hay chưa
                    for (int final = 0; final < xs.Count; final++)
                    {
                        x = xs[final]; y = ys[final];
                        if (ary2[x, y] != true) return;
                    }
                    xs.Clear(); ys.Clear();
                    #endregion
                }
                #endregion

                #region leve4 (check ô nên và không nên đánh)
                // check các ô không nên đánh để được các ô nên đánh
                ary4 = new bool[3, 3];// array dùng để check các ô không nên đánh của cả Com và Ply
                listcountCell[1] = 5;// x
                listcountCell[2] = 5;// y
                listcountCell[3] = 5;// x0
                listcountCell[4] = 5;// y0

                for (int count = 0; count < 2; count++)
                {
                    if (count == 0) { ary1 = aryCom; ary2 = aryPly; }
                    else { ary1 = aryPly; ary2 = aryCom; }

                    ary3_1 = new bool[3, 3];// array dùng để check các ô không nên đánh của ary1

                    // check TH không nên đánh khi bắt đầu game (có thể cải tiến thêm)
                    if (ary1[1, 1] == true)
                    {
                        for (int i = 0; i < 3; i = i + 2)
                        {
                            for (int j = 0; j < 3; j = j + 2)
                            {
                                if (ary2[i, j] == true) { ary3_1[2 - i, 2 - j] = true; }
                            }
                        }
                    }

                    // check số ô có thể đánh xem đã được đánh chưa
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (ary2[i, j] == true || ary1[i, j] == true || ary3_1[i, j] == true)
                            {
                                ary3_1[i, j] = true;
                                ary4[i, j] = true;
                            }
                            else if (listcountCell[1] == 5)
                            {
                                // chọn ô nên đánh
                                listcountCell[0]++;
                                listcountCell[1] = i;
                                listcountCell[2] = j;
                            }
                        }
                    }
                }

                // check các ô góc xem đã đánh chưa
                for (int i = 0; i < 3; i = i + 2)
                {
                    for (int j = 0; j < 3; j = j + 2)
                    {
                        if (!aryCom[i, j] && !aryPly[i, j])
                        {
                            listcountCell[0]++;
                            listcountCell[3] = i;
                            listcountCell[4] = j;
                            return;
                        }
                    }
                }

                // check những ô nên đánh (ưu tiên ô góc)
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (!ary4[i, j])
                        {
                            if (listcountCell[3] == i && listcountCell[4] == j)
                            {
                                x = i; y = j;
                                return;
                            }
                            else
                            {
                                listcountCell[1] = i;
                                listcountCell[2] = j;
                                // không return luôn vì ưu tiên đánh ô góc
                            }
                        }
                    }
                }

                // sau khi thu được ô nên đánh (không thu được thì phải random)
                if (listcountCell[0] != 0)
                {
                    x = listcountCell[1];
                    y = listcountCell[2];
                    return;
                }
                #endregion

                #region level1 (random)
                do
                {
                    x = rd.Next(0, 3);
                    y = rd.Next(0, 3);
                }
                while (aryPly[x, y] == true || aryCom[x, y] == true);
                #endregion
            }
        }
    }
}