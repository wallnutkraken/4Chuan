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

        public PostWithImage(FChan.Library.Post post) : this()
        {
            ImagePost = post;
            image.Source = Controller.GetThumbnail(post.Board, post.FileName);
            name.Content = "[" + post.Name + "] " + post.Subject;
            number.Content = post.PostNumber;
            List<Run> commentInlines = Controller.FormatTextInline(Controller.EscapeComment(ImagePost.Comment));
            comment.Text = "";
            foreach (Run entry in commentInlines)
            {
                comment.Inlines.Add(entry);
            }
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image imageWindow = new Image(ImagePost);
        }
    }
}
