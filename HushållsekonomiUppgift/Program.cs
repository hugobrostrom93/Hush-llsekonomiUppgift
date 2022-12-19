using HushållsekonomiUppgift;
using Microsoft.Extensions.Configuration;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        DatabasCrud databascrud = new DatabasCrud();
        Budget budget = new Budget();
        EkonomiPerson ekonomiPerson = new EkonomiPerson();

        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        string connString = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";        
        var databasCrud = new DatabasCrud();
        
        //var budget = new Budget();

        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine("|Välkommen till Hushållsekonomi-Spararen|");
        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine("");

        while (true)
        {
            Console.WriteLine("Välj ett av dessa två alternativ:");
            Console.WriteLine("1: Lägg till en person i listan \n2: Visa tabell \n3:Sök på persons tot inkomst: \n4:Sök på persons tot utgifter:");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:                    
                    databasCrud.AddPeopleToDB();
                    Console.WriteLine("");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    databascrud.GetTable();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.WriteLine("Vilken person vill du söka på?");
                    ekonomiPerson.förnamn = Console.ReadLine();
                    ekonomiPerson.inkomst = budget.TotalInkomst(ekonomiPerson.förnamn);
                    Console.WriteLine("");
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.WriteLine("Vilken person vill du söka på?");
                    ekonomiPerson.förnamn = Console.ReadLine();
                    ekonomiPerson.utgift = budget.TotalUtgift(ekonomiPerson.förnamn);
                    Console.WriteLine("");
                    break;
                    //case ConsoleKey.D4:
                    //    movieCrud.DeleteActor(actorId);
                    //    break;
                    //case ConsoleKey.D5:
                    //    visuals.View("Movies", movieCrud);
                    //    break;
                    //case ConsoleKey.D6:
                    //    visuals.View("Actors", movieCrud);
                    //    break;
                    //case ConsoleKey.Escape:
                    //    Environment.Exit(0);
                    //    break;
                    //default:
                    //    Console.WriteLine("try again loser");
                    //    break;
            }
        }

        //Budget budget = new Budget();
        //budget.RunMethods();
    }
}