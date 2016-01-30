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

namespace Jackie4Chuan
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : Window
    {
        private FChan.Library.Post Post;
        public Image()
        {
            InitializeComponent();
        }

        internal Image(FChan.Library.Post post)
        {
            InitializeComponent();
            Post = post;

            this.Width = (double)Post.ImageWidth + 10;
            this.Height = (double)Post.ImageHeight + 10;
            if (Post.ImageWidth >= System.Windows.SystemParameters.PrimaryScreenWidth)
            {
                scr.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                WindowState = WindowState.Maximized;
            }
            this.image.Height = (double)Post.ImageHeight;
            this.image.Width = (double)Post.ImageWidth;
            string imagename = Post.FileName + Post.FileExtension;
            ImageSource source = Controller.GetFullImage(Post.Board,
                imagename);
            this.image.Source = source;
            this.Title = imagename;
            this.Show();
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void image_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.DefaultExt = Post.FileExtension;
            save.FileName = Post.OriginalFileName;

            bool? result = save.ShowDialog();
            if (result == true)
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.DownloadFile("https://i.4cdn.org/" + Post.Board + "/" +
                    Post.FileName + Post.FileExtension, save.FileName);
            }
        }
    }
}
