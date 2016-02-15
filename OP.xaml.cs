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
    /// Interaction logic for OP.xaml
    /// </summary>
    public partial class OP : UserControl
    {
        public OP()
        {
            InitializeComponent();
        }
        private FChan.Library.Post post;

        public OP(FChan.Library.Post post) : this()
        {
            this.post = post;
            image.Source = Controller.GetThumbnail(post.Board, post.FileName);
            name.Content = WebUtility.HtmlDecode($"[{post.Name}] {post.Subject}");
            number.Content = $"[{post.PostNumber}]";
            comment.Text = "";
            List<Run> inlines = Controller.FormatTextInline(post.Comment);
            foreach (Run inline in inlines)
            {
                comment.Inlines.Add(inline);
            }
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image image = new Image(post);
        }

        private void number_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LinkController.OpenThread(post);
        }
    }
}
