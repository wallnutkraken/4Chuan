using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using FChan.Library;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Jackie4Chuan
{
    class Controller
    {
        public static string BoardToString(Board board)
        {
            return "/" + board.BoardName + "/ - " + board.Title;
        }

        private static ReadApi _Reader = new ReadApi();
        public static FullBoard GetBoard(string boardName, int pageNumber)
        {
            return new FullBoard(
                _Reader.GetBoard(boardName), _Reader.GetPage(boardName, pageNumber));
        }
        public static void FillBoards()
        {
            List<Board> allBoards = _Reader.GetAllBoards();
            foreach (Board entry in allBoards)
            {
                string header = BoardToString(entry);
                FInfo.AllBoards.Add(header, entry);
            }
        }

        public static FullBoard GetFullBoard(Board board, int page)
        {
            return new FullBoard(board, Chan.GetThreadPage(board.BoardName, page).Threads);
        }

        public static List<string> GetBoardNames()
        {
            return new List<string>(FInfo.AllBoards.Keys);
        }

        public static Board FindBoard(string name)
        {
            return FInfo.AllBoards[name];
        }

        public static BitmapImage GetThumbnail(string boardName, long imageId)
        {
            string imageUrl = "https://i.4cdn.org/" + boardName + "/" + imageId + "s.jpg";
            return new BitmapImage(new Uri(imageUrl));
        }


    }
}
