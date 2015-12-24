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
    }
}
