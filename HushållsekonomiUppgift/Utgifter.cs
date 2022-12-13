using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    internal class Utgifter
    {
        public int elräkning { get; set; }
        public int hyra { get; set; }
        public int mat { get; set; }
        public int gym { get; set; }
        public int telefon { get; set; }
        public int internet { get; set; }
        public int netflix { get; set; }
        public int spotify { get; set; }

        public Utgifter(int elräkning, int hyra, int mat, int gym, int telefon, int internet, int netflix, int spotify)
        {
            this.elräkning = elräkning;
            this.hyra = hyra;
            this.mat = mat;
            this.gym = gym;
            this.telefon = telefon;
            this.internet = internet;
            this.netflix = netflix;
            this.spotify = spotify;
        }
    }
}
