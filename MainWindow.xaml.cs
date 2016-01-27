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

            string content = "[" + currentBoard.Threads[0].Posts[0].Name + "] ";
            if (currentBoard.Threads[0].Posts[0].Subject != null)
            {
                content += currentBoard.Threads[0].Posts[0].Subject;
            }

            postName.Content = content;
            postContent.Text = Controller.ShortenByWord(140, Controller.UnHtml(currentBoard.Threads[0].Posts[0].Comment));
            postNumber.Content = currentBoard.Threads[0].Posts[0].PostNumber;
        }

        private void image_ShowImage(object sender, MouseButtonEventArgs args)
        {
            Image imageWindow = new Image(currentBoard);
            
        }

        private void boardSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBoard = Controller.GetFullBoard(Controller.FindBoard((string)boardSelect.SelectedItem), 1);
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
