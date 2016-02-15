using FChan.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackie4Chuan
{
    static class LinkController
    {
        public static void OpenThread(Post post)
        {
            System.Diagnostics.Process.Start($"http://boards.4chan.org/{post.Board}/thread/{post.PostNumber}/{post.ThreadUrlSlug}");
        }
    }
}
