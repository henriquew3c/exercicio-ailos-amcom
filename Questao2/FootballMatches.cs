using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class Data
    {
        public string Competition { get; set; }

        public int Year { get; set; }

        public string Round { get; set; }

        public string Ream1 { get; set; }

        public string Team2 { get; set; }

        public string Team1goals { get; set; }

        public string Team2goals { get; set; }
    }

    public class FootballMatches
    {
        public string Page { get; set; }

        public string per_page { get; set; }

        public string total { get; set; }
        
        public int total_pages { get; set; }


        public List<Data> Data { get; set; }

    }
}
