using FChan.Library;
using System.Collections.Generic;

namespace Jackie4Chuan
{
    class FullBoard
    {
        private Board _TheBoard;
        private List<FChan.Library.Thread> _Threads;
        public Board TheBoard { get { return _TheBoard; } }
        public List<FChan.Library.Thread> Threads { get { return _Threads; } }

        public FullBoard(Board board, List<FChan.Library.Thread> threads)
        {
            _TheBoard = board;
            _Threads = threads;
        }
    }
}
