using HushållsekonomiUppgift.DTO;
using HushållsekonomiUppgift.Visuals;

namespace HushållsekonomiUppgift
{
    public class Logic
    {
        public void Run()
        {
            Writelines writelines = new Writelines();
            DatabasCrud databascrud = new DatabasCrud();
            Beräkningar budget = new Beräkningar();
            EkonomiPerson ekonomiPerson = new EkonomiPerson();

            writelines.välkomsttext();

            while (true)
            {
                writelines.switchMeny();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        databascrud.AddPeopleToDB();
                        Console.WriteLine("");
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        databascrud.PrintList();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        writelines.sökaNamn();
                        ekonomiPerson.Förnamn = Console.ReadLine();
                        //databascrud.XYZ();
                        databascrud.PersonSök(ekonomiPerson.Förnamn);
                        ekonomiPerson.TotalInkomst = budget.SummeraBudgetInkomst(ekonomiPerson.Förnamn);
                        ekonomiPerson.Utgift = budget.SummeraBudgetUtgift(ekonomiPerson.Förnamn);
                        writelines.SummeraUtgifterWl(ekonomiPerson.Förnamn, ekonomiPerson);
                        break;
                }
            }
        }

        public decimal BeräkningOanade(EkonomiPerson person)
        {
            person.Oanadeutgifter = person.TotalInkomst * 0.25m;
            if (person.Oanadeutgifter < 0) person.Oanadeutgifter = 0;
            return person.Oanadeutgifter;
        }

        public decimal OanadeOchTotUtgift(EkonomiPerson person)
        {
            person.TotalUtgift = person.Oanadeutgifter + person.Utgift;
            if (person.TotalUtgift <= 0) person.TotalUtgift = 0;
            return person.TotalUtgift;
        }

        public decimal BeräkningSpara(EkonomiPerson person)
        {
            // person.Spara = person.Krav * 0.10m hade gått om inte
            // metoderna använder varandra isåfall
            person.Spara = (person.TotalInkomst - person.TotalUtgift) * 0.10m; 
            if (person.TotalInkomst - person.Spara < person.TotalUtgift)
                person.Spara = 0;
            return person.Spara;
        }

        public decimal BeräkningKvar(EkonomiPerson person)
        {
            person.Kvar = person.TotalInkomst - person.Utgift - person.Oanadeutgifter - person.Spara;
            return person.Kvar;
        }
    }
}