using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeNiro
{
    public class Movie
    {
        public Movie()
        {
            test = "Emir";
        }
        public string Name { get; set; }
        public string year { get; set; }
        public string genre { get; set; }
        public string price { get; set; }

        public string image { get; set; }

        public static List<Movie> Moviez = new List<Movie>();
        public string test;
        public static string Test1 = "test1";

    }
}
