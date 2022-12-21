namespace HushållsekonomiUppgift.DTO
{
    public class EkonomiPerson
    {
        public string Förnamn { get; set; }

        public string Efternamn { get; set; }

        public decimal TotalInkomst { get; set; }

        public decimal Utgift { get; set; }

        public decimal TotalUtgift { get; set; }

        public decimal Spara { get; set; }

        public decimal Oanadeutgifter { get; set; }

        public decimal Kvar { get; set; }

        // Används inte i koden än men tänker att vi lär behöva det senare

        //public string Månad { get; set; }

        //public decimal Lön { get; set; }

        //public decimal Studiemedel { get; set; }

        //public decimal Bidrag { get; set; }

        //public decimal El { get; set; }

        //public decimal Hyra { get; set; }

        //public decimal Mat { get; set; }

        //public decimal Gym { get; set; }

        //public decimal Telefon { get; set; }

        //public decimal Internet { get; set; }

        //public decimal Netflix { get; set; }

        //public decimal Spotify { get; set; }

        //public decimal Inkomst { get; set; }
    }
}