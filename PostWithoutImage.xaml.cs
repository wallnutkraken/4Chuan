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
    /// Interaction logic for PostWithoutImage.xaml
    /// </summary>
    public partial class PostWithoutImage : UserControl
    {
        public PostWithoutImage()
        {
            InitializeComponent();
        }

        public PostWithoutImage(FChan.Library.Post post) : this()
        {
            name.Content = "[" + post.Name + "] " + post.Subject;
            number.Content = post.PostNumber.ToString();
            List<Run> commentInlines = Controller.FormatTextInline(Controller.EscapeComment(post.Comment));
            comment.Text = "";
            foreach (Run entry in commentInlines)
            {
                comment.Inlines.Add(entry);
            }
        }
    }
}
