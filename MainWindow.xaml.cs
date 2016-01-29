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
        Int32 threadNumber = 0;

        public void Start()
        {
            Controller.FillBoards();
            currentBoard = Controller.GetBoard("a", 1);
            boardSelect.ItemsSource = Controller.GetBoardNames();
            boardSelect.Text = currentBoard.Board.ToString();
            Update();
        }

        private void Update()
        {
            boardHeader.Content = currentBoard.Board.ToString();
            FChan.Library.Post firstPost = currentBoard.Threads[threadNumber].Posts[0];

            if (currentBoard.Threads[threadNumber].Posts[0].HasImage)
            {
                post_Image.Source = Controller.GetThumbnail(currentBoard.Board.BoardName,
                    currentBoard.Threads[threadNumber].Posts[0].FileName);
            }
            post_Name.Content = "[" + firstPost.Name + "] " + firstPost.Subject;
            post_No.Content = firstPost.PostNumber.ToString();
            post_Comment.Text = Controller.ShortenByWord(140, Controller.EscapeComment(firstPost.Comment));

            int num = currentBoard.Threads[threadNumber].Posts.Count;
            int count = 205;
            for (int i = 1; i < 4 && i < num; i++)
            {
                if (currentBoard.Threads[threadNumber].Posts[i].HasImage)
                {
                    PostWithImage image = new PostWithImage(currentBoard.Threads[threadNumber].Posts[i]);
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    image.Margin = new Thickness(10, count, 0, 0);
                    image.VerticalAlignment = VerticalAlignment.Top;
                    griderino.Children.Add(image);
                    count += 120;
                }
                else
                {
                    PostWithoutImage image = new PostWithoutImage(currentBoard.Threads[threadNumber].Posts[i]);
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    image.Margin = new Thickness(10, count, 0, 0);
                    image.VerticalAlignment = VerticalAlignment.Top;
                    griderino.Children.Add(image);
                    count += 120;
                }
            }
        }

        private void image_ShowImage(object sender, MouseButtonEventArgs args)
        {
            Image imageWindow = new Image(currentBoard.Threads[threadNumber].Posts[0]);
        }

        private void boardSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBoard = Controller.GetFullBoard((FChan.Library.Board)boardSelect.SelectedItem, 1);
            Update();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
    }
}
