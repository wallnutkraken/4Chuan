﻿using System;
using System.Collections.Generic;
using System.Net;
using FChan.Library;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Linq;

namespace Jackie4Chuan
{
    static class Controller
    {
        public static List<T> EnumToList<T>()
        {
            List<T> allEnums = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            return allEnums;
        }
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
