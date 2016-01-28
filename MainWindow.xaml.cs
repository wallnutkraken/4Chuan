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
            Controller.FillBoards();
            currentBoard = Controller.GetBoard("a", 1);
            boardSelect.ItemsSource = Controller.GetBoardNames();
            boardSelect.SelectedItem = currentBoard;
            Update();
        }

        private void Update()
        {
            boardHeader.Content = currentBoard.Board.ToString();
            FChan.Library.Post firstPost = currentBoard.Threads[0].Posts[0];

            if (currentBoard.Threads[0].Posts[0].HasImage)
            {
                post_Image.Source = Controller.GetThumbnail(currentBoard.Board.BoardName,
                    currentBoard.Threads[0].Posts[0].FileName);
            }
            post_Name.Content = "[" + firstPost.Name + "] " + firstPost.Subject;
            post_No.Content = firstPost.PostNumber.ToString();
            post_Comment.Text = Controller.ShortenByWord(140, Controller.EscapeComment(firstPost.Comment));
        }

        private void image_ShowImage(object sender, MouseButtonEventArgs args)
        {
            Image imageWindow = new Image(currentBoard);
        }

        private void boardSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBoard = Controller.GetFullBoard((FChan.Library.Board)boardSelect.SelectedItem, 1);
            Update();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
