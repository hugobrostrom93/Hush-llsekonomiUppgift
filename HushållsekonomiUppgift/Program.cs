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

        //var budget = new Budget();

        writelines.välkomsttext();
    
        while (true)
        {
            Console.WriteLine("Välj ett av dessa alternativ:");
            Console.WriteLine("1: Lägg till en person i listan \n2: Visa tabell \n3:Sök på persons tot inkomst: \n4:Sök på persons tot utgifter:");
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
                    Console.WriteLine("Vilken person vill du söka på?");
                    ekonomiPerson.förnamn = Console.ReadLine();
                    Console.WriteLine(ekonomiPerson.totalInkomst);
                    //ekonomiPerson.inkomst = budget.totalInkomst(ekonomiPerson.förnamn);
                    //Console.WriteLine("");
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.WriteLine("Vilken person vill du söka på?");
                    Console.WriteLine(ekonomiPerson.utgift);
                    //ekonomiPerson.förnamn = Console.ReadLine();
                    //ekonomiPerson.utgift = budget.TotalUtgift(ekonomiPerson.förnamn);
                    Console.WriteLine("");
                    break;
            }
        }

    }
}