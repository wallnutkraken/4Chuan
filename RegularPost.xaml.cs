using FChan.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for RegularPost.xaml
    /// </summary>
    public partial class RegularPost : UserControl
    {
        public RegularPost()
        {
            InitializeComponent();
        }
        private Post post;

        public RegularPost(Post post) : this()
        {
            this.post = post;
            if (post.HasImage == false)
            {
                image.Height = 0;
                image.Width = 0;
                name.Margin = new Thickness(0, 0, 0, 0);
                comment.Margin = new Thickness(0, 26, 0, 0);
            }
            else
            {
                image.Source = Controller.GetThumbnail(post.Board, post.FileName);
            }
            name.Content = WebUtility.HtmlDecode($"[{post.Name}] {post.Subject}");
            number.Content = $"[{post.PostNumber}]";
            List<Run> inlines = Controller.FormatTextInline(post.Comment);
            foreach(Run inline in inlines)
            {
                comment.Inlines.Add(inline);
            }
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image image = new Image(post);
            image.Show();
        }
    }
}
