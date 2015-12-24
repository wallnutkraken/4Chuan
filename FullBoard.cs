using FChan.Library;
using System.Collections.Generic;

namespace Jackie4Chuan
{
    class FullBoard
    {
        private Board _TheBoard;
        private List<FChan.Library.Thread> _Threads;
        private string _BoardName;
        public Board TheBoard { get { return _TheBoard; } }
        public List<FChan.Library.Thread> Threads { get { return _Threads; } }
        public string BoardName { get { return _BoardName; } }

        public FullBoard(Board board, List<FChan.Library.Thread> threads)
        {
            _TheBoard = board;
            _Threads = threads;
            _BoardName = "/" + board.BoardName + "/ - " + board.Title;
        }
    }
}
