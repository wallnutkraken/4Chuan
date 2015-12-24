using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using FChan.Library;

namespace Jackie4Chuan
{
    class ReadApi
    {
        private static string UseApi(string get)
        {
            WebRequest request = WebRequest.Create(get);
            Stream responseStream = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            string currentLine = "";
            string responseJson = "";

            while (currentLine != null)
            {
                currentLine = reader.ReadLine();
                if (currentLine != null)
                {
                    responseJson += currentLine;
                }
            }

            return responseJson;
        }

        public List<Board> GetAllBoards()
        {
            return Chan.GetBoard().Boards;
        }

        /// <summary>
        /// Gets a list of threads for a page of a board
        /// </summary>
        /// <param name="board">board short name (a, g, vg)</param>
        /// <param name="page">page number (1 is the main index)</param>
        public List<FChan.Library.Thread> GetPage(string board, int page)
        {
            ThreadRootObject threads = Chan.GetThreadPage(board, page);
            return threads.Threads;
        }

        public FChan.Library.Thread GetThread(string board, int threadNumber)
        {
            return Chan.GetThread(board, threadNumber);
        }

        public Board GetBoard(string board)
        {
            Board thisBoard = new Board();
            BoardRootObject allBoards = Chan.GetBoard();
            foreach (Board entry in allBoards.Boards)
            {
                if (entry.BoardName == board)
                {
                    thisBoard = entry;
                }
            }

            return thisBoard;
        }
    }
}
