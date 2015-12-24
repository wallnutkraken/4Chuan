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

        FullBoard currentBoard;

        public void Start()
        {
            currentBoard = Controller.GetBoard("a", 1);
            Controller.FillBoards();
            boardSelect.ItemsSource = Controller.GetBoardNames();
            Update();
        }
        
        private void Update()
        {
            boardHeader.Content = Controller.BoardToString(currentBoard.TheBoard);
            boardSelect.SelectedItem = currentBoard.BoardName;

            ImageSource source = Controller.GetThumbnail(currentBoard.TheBoard.BoardName,
                currentBoard.Threads[0].Posts[0].FileName);
            postImage.Source = source;
        }

        private void boardSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBoard = Controller.GetFullBoard(Controller.FindBoard((string)boardSelect.SelectedItem), 1);
            Update();
        }
    }
}
