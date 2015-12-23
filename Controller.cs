using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackie4Chuan
{
    class Controller
    {
        private static ReadApi _Reader;
        public static string GetVgMain()
        {
            if (_Reader == null)
            {
                _Reader = new ReadApi();
            }
            return _Reader.GetPage("vg");
        }
    }
}
