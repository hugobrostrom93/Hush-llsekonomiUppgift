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
            Kvar(person, förnamn);           //VASADU
            Console.WriteLine("");
        }
        public void Kvar(EkonomiPerson person, string förnamn)
        {
            if (person.Kvar < 0) Console.WriteLine($"Du har överskridit din budget" +
                $"\nDu har {person.Kvar} i skuld"); 
            else {
                Console.WriteLine($"Det {förnamn} har kvar att spendera efter alla hens utgifter + sparande är {person.Kvar}kr");
            }
        }
        public void FINNSINTE(string förnamn)
        {
            Console.WriteLine($"\nTvär finns inte {förnamn} i  DB\n");
        }
        public void AddToDbWl(string value, string cost)
        {
            Console.WriteLine($"\nAnge {value} {cost}");
        }
    }
}
