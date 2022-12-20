using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{

    internal class Writelines
    {
        Budget budget = new Budget();


        public void välkomsttext()
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("|Välkommen till Hushållsekonomi-Spararen|");
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("");

        }
        public void switchMeny()
        {
            Console.WriteLine("\nVälj ett av dessa alternativ:");
            Console.WriteLine
                ("1: Lägg till en person i listan " +
                "\n2: Visa tabell " +
                "\n3: Sök på persons tot inkomster och utgifter:\n");
        }
        public void sökaNamn()
        {
            Console.WriteLine("\nVilken person vill du söka på?");
        }
        public void SummeraUtgifterWl(string förnamn, EkonomiPerson person)
        {
            Logic logic = new Logic();
            person.Oanadeutgifter = (decimal)logic.BeräkningOanade(person);
            person.Spara = logic.BeräkningSpara(person);
            person.Kvar = logic.BeräkningKvar(person);
            person.TotalUtgift = logic.OanadeOchTotUtgift(person);
            Console.WriteLine("");
            Console.WriteLine($"{förnamn}s totala inkomster är {person.TotalInkomst}kr");
            Console.WriteLine($"{förnamn}s fasta utgifter är {person.Utgift}kr");
            Console.WriteLine($"{förnamn}s oanade utgifter är {person.Oanadeutgifter}kr (alltså 25% av totala inkomsten)");
            Console.WriteLine($"{förnamn}s totala utgifter är {person.TotalUtgift}kr");
            Console.WriteLine($"Det {förnamn} ska spara när hen har fått lönen är {person.Spara}kr");
            Console.WriteLine($"Det {förnamn} har kvar att spendera efter alla hens utgifter + sparande är {person.Kvar}kr");           //VASADU
            Console.WriteLine("");
        }
        public void FINNSINTE(string förnamn)
        {
            Console.WriteLine($"\nTvär finns inte {förnamn} i  DB\n");
        }
        public void AddToDbWlName()
        {
            Console.WriteLine("\nAnge ditt förnamn: ");
        }
        public void AddToDbWlLastName()
        {
            Console.WriteLine("\nAnge ditt efternamn: ");
        }
        public void AddToDbWlPlaneraEkonomi()
        {
            Console.WriteLine("\nGrymt! Nu är det dags att planera din ekonomi");
            Console.WriteLine("Vi börjar med att beräkna dina inkomster!\n");
        }
        public void AddToDbWlMånad()
        {
            Console.WriteLine("Ange vilken månad du vill planera för: ");
        }
        public void AddToDbWlLön()
        {
            Console.WriteLine("Ange hur mycket lön du kommer att få in denna månad:");
        }
        public void AddToDbWlStudiemedel()
        {
            Console.WriteLine("Ange hur mycket studiemedel du kommer att få in denna månad:");
        }
        public void AddToDbWlBidrag()
        {
            Console.WriteLine("Ange hur mycket bidrag du kommer att få in denna månad:");
        }
        public void AddToDbWlBeräknaUtgifter()
        {
            Console.WriteLine("Tack. Nu är det dags för att beräkna dina utgifter!");
        }
        public void AddToDbWlEl()
        {
            Console.WriteLine("Ange hur mycket el du betalar per månad:");
        }
        public void AddToDbWlHyra()
        {
            Console.WriteLine("Ange hyra du betalar per månad:");
        }
        public void AddToDbWlMat()
        {
            Console.WriteLine("Ange hur mycket mat du planerar att handla för under denna månad:");
        }
        public void AddToDbWlGym()
        {
            Console.WriteLine("Ange hur mycket du betalar för gym per månad:");
        }
        public void AddToDbWlTel()
        {
            Console.WriteLine("Ange hur mycket du betalar för din telefon per månad:");
        }
        public void AddToDbWlInternet()
        {
            Console.WriteLine("Ange hur mycket du betalar för internet per månad:");
        }
        public void AddToDbWlspotify()
        {
            Console.WriteLine("Ange hur mycket du betalar för spotify per månad:");
        }
        public void AddToDBWlSpara()
        {
            Console.WriteLine("Fantastiskt! Nu har vi lagt till all denna infon i vår Databas!");
            Console.WriteLine("");
        }

    }
}
