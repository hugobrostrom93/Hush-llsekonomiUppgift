using HushållsekonomiUppgift;
using Microsoft.Extensions.Configuration;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        DatabasCrud databascrud = new DatabasCrud();

        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        string connString = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";        
        var databasCrud = new DatabasCrud();

        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine("|Välkommen till Hushållsekonomi-Spararen|");
        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine("");

        while (true)
        {
            Console.WriteLine("Välj ett av dessa två alternativ:");
            Console.WriteLine("1: Lägg till en person i listan \n2: Avsluta programmet");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    databascrud.GetTable();
                   // databasCrud.AddPeopleToDB();
                    Console.WriteLine("");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Environment.Exit(1);
                    break;

                    // Ett case för att lista alla personer i databasen
                    
                    // 


                    //case ConsoleKey.D3:
                    //    movieCrud.AddActor(actor, movie);
                    //    break;
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