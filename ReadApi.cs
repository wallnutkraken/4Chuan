using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Jackie4Chuan
{
    class ReadApi
    {
        /// <summary>
        /// Gets the main page of a specified board from 4chan
        /// </summary>
        /// <param name="board">the board you wish to get it from (e.g. a, vg, lit)</param>
        /// <returns>the JSON response</returns>
        public string GetPage(string board)
        {
            return GetPage(board, 1);
        }

        /// <summary>
        /// Gets a page from 4chan
        /// </summary>
        /// <param name="board">the board you wish to get it from (e.g. a, vg, lit)</param>
        /// <param name="pageNumber">the page number which you want (1 is the main page)</param>
        /// <returns>the JSON response</returns>
        public string GetPage(string board, int pageNumber)
        {
            string requestUrl = "http://a.4cdn.org/" + board + "/" + pageNumber + ".json";
            string responseJson = "";
            WebRequest request = WebRequest.Create(requestUrl);

            Stream responseStream = request.GetResponse().GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            string currentLine = "";
            while (currentLine != null)
            {
                currentLine = reader.ReadLine();
                if (currentLine != null)
                {
                    responseJson += currentLine + "\n";
                }
            }

            return responseJson;
        }
    }
}
