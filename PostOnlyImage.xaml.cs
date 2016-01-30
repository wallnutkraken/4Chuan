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
    /// Interaction logic for PostOnlyImage.xaml
    /// </summary>
    public partial class PostOnlyImage : UserControl 
    {
        FChan.Library.Post ImagePost;
        public PostOnlyImage()
        {
            InitializeComponent();
        }

        public PostOnlyImage(FChan.Library.Post post) : this()
        {
            ImagePost = post;
            image.Source = Controller.GetThumbnail(post.Board, post.FileName);
            name.Content = "[" + post.Name + "] " + post.Subject;
            number.Content = post.PostNumber;
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image imageWindow = new Image(ImagePost);
        }
    }
}
