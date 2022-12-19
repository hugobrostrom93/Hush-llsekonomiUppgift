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

        public decimal lön { get; set; }

        public decimal studiemedel { get; set; }

        public decimal bidrag { get; set; }

        public decimal el { get; set; }

        public decimal hyra { get; set; }

        public decimal mat { get; set; }

        public decimal gym { get; set; }

        public decimal telefon { get; set; }

        public decimal internet { get; set; }

        public decimal netflix { get; set; }

        public decimal spotify { get; set; }       

        public decimal inkomst { get; set; }

        public decimal utgift { get; set; }

        public decimal spara { get; set; }

        public decimal oanadeutgifter { get; set; }
    }
}
