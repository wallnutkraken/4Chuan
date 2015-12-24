using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackie4Chuan
{
    class Controller
    {
        private static ReadApi _Reader = new ReadApi();
        public static FullBoard GetBoard(string boardName, int pageNumber)
        {
            return new FullBoard(
                _Reader.GetBoard(boardName), _Reader.GetPage(boardName, pageNumber));
        }
        public static List<string> GetAllBoardNames()
        {
            List<string> boards = new List<string>();
            List<FChan.Library.Board> actualBoards = _Reader.GetAllBoards();
            foreach (FChan.Library.Board entry in actualBoards)
            {
                boards.Add("/" + entry.BoardName + "/ - " + entry.Title);
            }
            return boards;
        }
    }
}
