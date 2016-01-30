using System;
using System.Collections.Generic;
using System.Net;
using FChan.Library;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace Jackie4Chuan
{
    static class Controller
    {

        public static FullBoard GetBoard(string boardName, int pageNumber)
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

        public static string EscapeComment(string comment)
        {
            string newstr = WebUtility.HtmlDecode(comment);
            newstr = newstr.Replace("<br>", "\n");
            /* Note to self: make <span class = "quote"> >green */
            return newstr;
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
