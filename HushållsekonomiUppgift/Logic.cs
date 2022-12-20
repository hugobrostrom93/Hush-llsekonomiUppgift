using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    public class Logic
    {
        public void Run()
        {
            Writelines writelines = new Writelines();
            DatabasCrud databascrud = new DatabasCrud();
            Budget budget = new Budget();
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
                        //databascrud.PrintList(ekonomiPerson.Förnamn);
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
            person.Oanadeutgifter = (person.TotalInkomst * 25) / 100;
            if (person.Oanadeutgifter <= 0) person.Oanadeutgifter = 0;
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
            if (person.TotalInkomst - person.Spara > person.TotalUtgift)
                person.Spara = (person.TotalInkomst - person.Utgift) * 10 / 100;
            else
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
