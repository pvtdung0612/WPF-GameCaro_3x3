using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPF_GameCaro_3x3
{
    /// <summary>
    /// Interaction logic for Option.xaml
    /// </summary>
    public partial class Option : Window
    {
        public Option()
        {
            InitializeComponent();

            cbxLevel.ItemsSource = new int[] { 1, 2, 3, 4 };
            cbxLevel.SelectedIndex = 0;
        }
    }
}
