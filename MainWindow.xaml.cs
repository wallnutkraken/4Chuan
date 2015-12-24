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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jackie4Chuan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            FullBoard anime = Controller.GetBoard("a", 1);
            boardHeader.Content = anime.BoardName;
            boardSelect.ItemsSource = Controller.GetAllBoardNames();
            boardSelect.SelectedItem = anime.BoardName;
        }

        private void boardSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            boardHeader.Content = (string)boardSelect.SelectedItem;
        }
    }
}
