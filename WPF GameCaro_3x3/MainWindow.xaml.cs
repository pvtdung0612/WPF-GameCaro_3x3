using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_GameCaro_3x3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Property, Var

        string CheckWin;
        bool comFirst;
        bool[,] aryPly;
        bool[,] aryCom;
        int level;
        Option op;

        Button[,] listBtn;

        #endregion

        #region Method

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load list button

            listBtn = new Button[3, 3];

            for (int x = 0; x < 3; x++)
            {
                //grd.ColumnDefinitions.Add(new ColumnDefinition());
                //grd.RowDefinitions.Add(new RowDefinition());

                for (int y = 0; y < 3; y++)
                {
                    Button btn = new Button() { Margin = new Thickness(5), FontSize = 50 };
                    btn.Tag=x.ToString()+y.ToString();
                    btn.Content = null;

                    btn.Click += Btn_Click;

                    Grid.SetColumn(btn, x);
                    Grid.SetRow(btn, y);
                    grd.Children.Add(btn);

                    listBtn[x, y] = btn;
                }
            }

            // Load Property

            CheckWin = "chưa win";
            aryPly = new bool[3, 3];
            aryCom = new bool[3, 3];
            level = 1;
            comFirst = false;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Content==null)
            {
                btn.Content = 'X';
                aryPly[Convert.ToInt32(btn.Tag.ToString().Substring(0, 1)), Convert.ToInt32(btn.Tag.ToString().Substring(1, 1))] = true;
                if (HandleWin(aryPly, "Player") == false) AI();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void btnOp_Click(object sender, RoutedEventArgs e)
        {
            op = new Option();
            op.ShowDialog();

            if (op.ckbFirst.IsChecked == true) comFirst = true;
            else comFirst = false;

            level = (int)op.cbxLevel.SelectedItem;
        }

        void NewGame()
        {
            aryPly = new bool[3, 3];
            aryCom = new bool[3, 3];
            CheckWin = "chưa win";

            foreach (Button item in listBtn)
            {
                item.IsEnabled = true;
                item.Content = null;
            }

            if (comFirst == true) AI();
        }

        void EndGame()
        {
            foreach (Button item in listBtn)
            {
                item.IsEnabled = false;
            }
        }

        bool HandleWin(bool[,] ary, string winner)
        {
            // kiểm tra win
            for (int i = 0; i < 3; i++)
            {
                if (ary[2, i] == true && ary[1, i] == true && ary[0, i] == true) CheckWin = "win"; // các hàng
                if (ary[i, 2] == true && ary[i, 1] == true && ary[i, 0] == true) CheckWin = "win"; // các cột
            }
            if (ary[0, 0] == true && ary[1, 1] == true && ary[2, 2] == true) CheckWin = "win"; // 1 đường chéo lên
            if (ary[0, 2] == true && ary[1, 1] == true && ary[2, 0] == true) CheckWin = "win"; // 1 đường chéo xuống

            // kiểm tra draw
            int count = 0;
            foreach (Button item in listBtn)
            {
                if (item.Content != null) count++;
            }
            if (count == 9 && CheckWin!="win") CheckWin = "draw";

            // kết luận CheckWin
            if (CheckWin == "chưa win") return false;

            MessageBox.Show(winner + " " + CheckWin);
            EndGame();
            return true;
        }

        void AI()
        {
            int x = 0, y = 0;

            if (level == 1)
            {
                Level1 AICaro = new Level1(aryPly, aryCom);
                x = AICaro.x;
                y = AICaro.y;
            }
            else if (level == 2)
            {
                Level2 AICaro = new Level2(aryPly, aryCom);
                x = AICaro.x;
                y = AICaro.y;
            }
            else if (level == 3)
            {
                Level3 AICaro = new Level3(aryPly, aryCom);
                x = AICaro.x;
                y = AICaro.y;
            }
            else if (level == 4)
            {
                Level4 AICaro = new Level4(aryPly, aryCom);
                x = AICaro.x;
                y = AICaro.y;
            }

            aryCom[x, y] = true;
            listBtn[x, y].Content = "O";

            HandleWin(aryCom, "Computer");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
