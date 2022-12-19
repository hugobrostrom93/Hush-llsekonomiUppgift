using HushållsekonomiUppgift;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Writelines writelines = new Writelines();
        DatabasCrud databascrud = new DatabasCrud();
        Budget budget = new Budget();
        EkonomiPerson ekonomiPerson = new EkonomiPerson();

        var connString = databascrud.Read("connString.txt");
        var cnn = new MySqlConnection(connString);

        List<EkonomiPerson> ekonomiPersoner = new List<EkonomiPerson>();
        //ekonomiPersoner = databascrud.GetPerson();
        //var budget = new Budget();

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
                    databascrud.PrintList(ekonomiPerson.Förnamn);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    writelines.sökaNamn();
                    ekonomiPerson.Förnamn = Console.ReadLine();
                    databascrud.PrintList(ekonomiPerson.Förnamn);
                    ekonomiPerson.TotalInkomst = budget.SummeraBudget(ekonomiPerson.Förnamn);
              
                    break;

            }
        }

    }
}