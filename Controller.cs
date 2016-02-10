using System;
using System.Collections.Generic;
using System.Net;
using FChan.Library;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Documents;

namespace Jackie4Chuan
{
    static class Controller
    {

        public static IFullBoard GetBoard(string boardName, int pageNumber)
        {
            foreach (Board board in FInfo.AllBoards)
            {
                if (board.BoardName == boardName)
                {
                    return new FullBoard(board, Chan.GetThreadPage(boardName, pageNumber).Threads);
                }
            }

            throw new KeyNotFoundException("Board not found. What the fuck happened?!");
            /* Hopefully the line above never runs */
        }
        public static void FillBoards()
        { 
            FInfo.AllBoards = Chan.GetBoard().Boards;
        }

        public static FullBoard GetFullBoard(Board board, int page)
        {
            return new FullBoard(board, Chan.GetThreadPage(board.BoardName, page).Threads);
        }

        public static List<Board> GetBoardNames()
        {
            return FInfo.AllBoards;
            /* Woo! Not jumping layers! */
        }

        public static string ShortenByWord(int maxCharacters, string original)
        {
            string[] words = original.Split(' ');

            bool done = false;
            string returnStr = "";
            for (int i = 0; done == false && i < words.Length; i++)
            {
                if ((returnStr + words[i] + 1).Length <= maxCharacters)
                {
                    returnStr += words[i] + " ";
                }
                else
                {
                    done = true;
                }
            }

            return returnStr;
        }

        public static List<int> CountUpTo(int count)
        {
            List<int> list = new List<int>();
            int id = 1;
            while (id <= count)
            {
                list.Add(id);
                id++;
            }
            return list;
        }

        private static void EscapeComment(ref string comment)
        {
            comment = WebUtility.HtmlDecode(comment);
            comment = comment.Replace("<br>", "\n").Replace("<wbr>", "");
            /* Note to self: make <span class = "quote"> >green */
        }
        
        /// <summary>
        /// Takes a string (the comment of a post) and turns it into a list of inline runs to add to a textblock
        /// </summary>
        public static List<Run> FormatTextInline(string comment)
        {
            if (comment == null)
            {
                List<Run> empty = new List<Run>();
                empty.Add(new Run(""));
                return empty;
            }
            EscapeComment(ref comment);
            string[] lines = comment.Split('\n');
            List<Run> inlines = new List<Run>();
            string quoteTag = "<span class=\"quote\">";

            foreach (string line in lines)
            {
                if (line.StartsWith(quoteTag))
                {
                    string in_line = line.Replace(quoteTag, "").Replace("</span>", "");
                    inlines.Add(new Run(in_line + "\n") { Foreground = System.Windows.Media.Brushes.DarkGreen });
                    continue;
                }
                else
                {
                    inlines.Add(new Run(line + '\n'));
                }

                /* I'll do this later */

                //else if (line.Contains("<a href=\"#p")) /* this means it's a reply */
                //{
                //    for (int i = 0; i < line.Length; i++)
                //    {
                //        int beginInd = new int();
                //        if (i != line.Length - 1) /* Checks if it's not the last char */
                //        {
                //            if (line[i] == '<' && line[i + 1] == 'a')
                //            {
                //                beginInd = i;
                //                /* The link begins */
                //                string tag = "<a";
                //                bool read = true;
                //                i += 2; /* because we already read <a */
                //                while (i < line.Length && read)
                //                {
                //                    if (line[i] == '>')
                //                    {
                //                        read = false;
                //                    }
                //                    tag += line[i];
                //                    i++;
                //                }
                //                inlines.Add(new Run(line.Replace(tag, "").Remove(beginInd) + " "));
                //                read = true;
                //                string reply = "";
                //                while (i != line.Length && read)
                //                {
                //                    if (line[i] == '<')
                //                    {
                //                        read = false;
                //                        i--;
                //                        /* handling text/strings kills me */
                //                    }
                //                    else
                //                    {
                //                        reply += line[i];
                //                    }
                //                    i++;
                //                }
                //            }
                //        }
                //    }
                //}
            }

            return inlines;
        }

        public static string UnHtml(string original)
        {
            if (original.StartsWith("<"))
            {
                return Regex.Replace(original, "<.*?>", String.Empty);
            }
            else
            {
                return original;
            }
        }

        public static Board FindBoard(string name)
        {
            foreach (Board board in FInfo.AllBoards)
            {
                if (board.ToString() == name)
                {
                    return board;
                }
            }
            throw new KeyNotFoundException("Board not found. What the fuck happened?!");
            /* Hopefully the line above never runs */
        }

        public static BitmapImage GetThumbnail(string boardName, long imageId)
        {
            string imageUrl = "https://i.4cdn.org/" + boardName + "/" + imageId + "s.jpg";
            return new BitmapImage(new Uri(imageUrl));
        }

        public static BitmapImage GetFullImage(string boardName, string imageName)
        {
            string imageUrl = "https://i.4cdn.org/" + boardName + "/" + imageName;
            return new BitmapImage(new Uri(imageUrl));
        }


    }
}
