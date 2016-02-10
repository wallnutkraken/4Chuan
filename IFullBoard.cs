using FChan.Library;
using System.Collections.Generic;

namespace Jackie4Chuan
{
    interface IFullBoard
    {
        Board Board { get; }
        List<FChan.Library.Thread> Threads { get; }
    }
}
