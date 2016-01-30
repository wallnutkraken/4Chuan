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

        /// <summary>
        /// Clears the posts on screen
        /// </summary>
        private void ClearPosts()
        {
            List<object> controlsToRemove = new List<object>();
            foreach (object child in griderino.Children)
            {
                if (child is PostWithImage ||
                    child is PostWithoutImage ||
                    child is PostOnlyImage)
                {
                    controlsToRemove.Add(child);
                }
            }

            foreach (object entry in controlsToRemove)
            {
                if (entry is PostWithImage)
                {
                    griderino.Children.Remove((PostWithImage)entry);
                }
                else if (entry is PostWithoutImage)
                {
                    griderino.Children.Remove((PostWithoutImage)entry);
                }
                else if (entry is PostOnlyImage)
                {
                    griderino.Children.Remove((PostOnlyImage)entry);
                }
            }
        }

        private void Update()
        {
            ClearPosts();
            boardHeader.Content = currentBoard.Board.ToString();
            FChan.Library.Post firstPost = currentBoard.Threads[threadNumber].Posts[0];

            if (currentBoard.Threads[threadNumber].Posts[0].HasImage)
            {
                post_Image.Source = Controller.GetThumbnail(currentBoard.Board.BoardName,
                    currentBoard.Threads[threadNumber].Posts[0].FileName);
            }
            post_Name.Content = "[" + firstPost.Name + "] " + firstPost.Subject;
            post_No.Content = firstPost.PostNumber.ToString();
            if (firstPost.Comment == null)
            {
                firstPost.Comment = "";
                /* Denullify comment for OP */
            }
            post_Comment.Text = Controller.EscapeComment(firstPost.Comment);

            int num = currentBoard.Threads[threadNumber].Posts.Count;
            int count = 205;
            for (int i = 1; i < 4 && i < num; i++)
            {
                if (currentBoard.Threads[threadNumber].Posts[i].HasImage &&
                    currentBoard.Threads[threadNumber].Posts[i].Comment != null)
                {
                    PostWithImage image = new PostWithImage(currentBoard.Threads[threadNumber].Posts[i]);
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    image.Margin = new Thickness(10, count, 0, 0);
                    image.VerticalAlignment = VerticalAlignment.Top;
                    griderino.Children.Add(image);
                    count += (int)image.Height;
                }
                else if (currentBoard.Threads[threadNumber].Posts[i].HasImage)
                {
                    PostOnlyImage image = new PostOnlyImage(currentBoard.Threads[threadNumber].Posts[i]);
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    image.Margin = new Thickness(10, count, 0, 0);
                    image.VerticalAlignment = VerticalAlignment.Top;
                    griderino.Children.Add(image);
                    count += (int)image.Height;
                }
                else
                {
                    PostWithoutImage image = new PostWithoutImage(currentBoard.Threads[threadNumber].Posts[i]);
                    image.HorizontalAlignment = HorizontalAlignment.Left;
                    image.Margin = new Thickness(10, count, 0, 0);
                    image.VerticalAlignment = VerticalAlignment.Top;
                    griderino.Children.Add(image);
                    count += (int)image.Height;
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

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            currentBoard = Controller.GetBoard(currentBoard.Board.BoardName, 1);
            Update();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(new NotImplementedException().Message);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && threadNumber > 0)
            {
                threadNumber--;
                Update();
            }
            else if (e.Key == Key.Down && threadNumber < currentBoard.Threads.Count - 1)
            {
                threadNumber++;
                Update();
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadUp();
        }
        /// <summary>
        /// Handles user wanting to go up a thread
        /// </summary>
        private void ThreadUp()
        {
            if (threadNumber > 0)
            {
                threadNumber--;
                Update();
            }
        }

        /// <summary>
        /// Handles user wanting to go down a thread
        /// </summary>
        private void ThreadDown()
        {
            if (threadNumber < currentBoard.Threads.Count - 1)
            {
                threadNumber++;
                Update();
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadDown();
        }

        private void post_No_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://boards.4chan.org/" + currentBoard.Board.BoardName + "/thread/" +
                currentBoard.Threads[threadNumber].Posts[0].PostNumber + "/" + 
                currentBoard.Threads[threadNumber].Posts[0].ThreadUrlSlug);
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                ThreadUp();
            }
            else if (e.Delta < 0)
            {
                ThreadDown();
            }
        }
    }
}
