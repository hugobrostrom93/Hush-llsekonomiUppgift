using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    internal class EkonomiPerson
    {
        // Används inte i koden än men tänker att vi lär behöva det senare
        public string förnamn { get; set; }

        public string efternamn { get; set; }

        public string månad { get; set; }

        public int lön { get; set; }

        public int studiemedel { get; set; }

        public int bidrag { get; set; }

        public int el { get; set; }

        public int hyra { get; set; }

        public int mat { get; set; }

        public int gym { get; set; }

        public int telefon { get; set; }

        public int internet { get; set; }

        public int netflix { get; set; }

        public int spotify { get; set; }       

        public decimal inkomst { get; set; }

        public decimal utgift { get; set; }

        public int spara { get; set; }
        public int oanadeutgifter { get; set; }
    }
}
