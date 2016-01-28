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
    /// Interaction logic for PostWithImage.xaml
    /// </summary>
    public partial class PostWithImage : UserControl
    {
        FChan.Library.Post ImagePost;
        public PostWithImage()
        {
            InitializeComponent();
        }

        public PostWithImage(FChan.Library.Post post, string namesp) : this()
        {
            //this.Name = namesp;
            ImagePost = post;
            image.Source = Controller.GetThumbnail(post.Board, post.FileName);
            name.Content = "[" + post.Name + "] " + post.Subject;
            number.Content = post.PostNumber;
            comment.Text = Controller.ShortenByWord(80, Controller.EscapeComment(post.Comment));
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image imageWindow = new Image(ImagePost);
        }
    }
}
