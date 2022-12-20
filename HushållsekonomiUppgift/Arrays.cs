using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    internal class Arrays
    {
        public string[] GetArray()
        {
            string[] Array = new string[] { "Förnamn", "Efternamn", "Månad",
            "Lön", "Studiemedel", "Bidrag", "El", "Mat", "Hyra", "Gym",
            "Telefon", "Internet", "Spotify"};
            return Array;
        }
    }
}

