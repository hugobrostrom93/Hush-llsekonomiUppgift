using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    internal class KalkyleradeUtgifter
    {
        public int spara { get; set; }
        public int oanadeUtgifter { get; set; }

        public KalkyleradeUtgifter(int spara, int oanadeUtgifter)
        {
            this.spara = spara;
            this.oanadeUtgifter = oanadeUtgifter;
        }
    }
}
