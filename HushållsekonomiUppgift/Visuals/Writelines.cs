using HushållsekonomiUppgift.DTO;

namespace HushållsekonomiUppgift.Visuals
{
    internal class Writelines
    {
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
            person.Oanadeutgifter = logic.BeräkningOanade(person);
            person.TotalUtgift = logic.OanadeOchTotUtgift(person);
            person.Spara = logic.BeräkningSpara(person);
            person.Kvar = logic.BeräkningKvar(person);
            Console.WriteLine($"\n{förnamn}s totala inkomster är {person.TotalInkomst}kr\n" +
            $"{förnamn}s fasta utgifter är {person.Utgift}kr\n" +
            $"{förnamn}s oanade utgifter är {person.Oanadeutgifter}kr (alltså 25% av totala inkomsten)\n" +
            $"{förnamn}s totala utgifter är {person.TotalUtgift}kr\n" +
            $"Det {förnamn} ska spara när hen har fått lönen är {Math.Round(person.Spara)}kr");
            Kvar(person, förnamn);
            Console.WriteLine("");
        }

        public void Kvar(EkonomiPerson person, string förnamn)
        {
            if (person.Kvar < 0) Console.WriteLine($"Du har överskridit " +
                $"din budget med {Math.Abs(person.Kvar)} riksdaler");
            else
            {
                Console.WriteLine($"Det {förnamn} har kvar att " +
                    $"spendera efter alla hens utgifter + sparande är {Math.Round(person.Kvar)}kr");
            }
        }

        public void NamnFinnsInte(string förnamn)
        {
            Console.WriteLine($"\nTyvärr finns inte {förnamn} i  DB\n");
        }

        public void AddToDbWl(string value, string cost)
        {
            Console.WriteLine($"\nAnge {value} {cost}");
        }

        public void AddedToDbWl()
        {
            Console.WriteLine("\nPersonen har lagts till i DB\n");
        }
    }
}