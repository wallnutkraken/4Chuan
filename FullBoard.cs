using FChan.Library;
using System.Collections.Generic;

namespace Jackie4Chuan
{
    class FullBoard : IFullBoard
    {
        private Board _Board;
        private List<FChan.Library.Thread> _Threads;
        public Board Board { get { return _Board; } }
        public List<FChan.Library.Thread> Threads { get { return _Threads; } }

        public FullBoard(Board board, List<FChan.Library.Thread> threads)
        {
            _Board = board;
            _Threads = threads;
        }
    }
}
