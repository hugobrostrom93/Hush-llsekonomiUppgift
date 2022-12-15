using HushållsekonomiUppgift;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        string connString = @"Server=ns8.inleed.net;Database=s60127_MolnstersInc;Uid=[Insert Username];Pwd=[Insert Password];";
        var databasCrud = new DatabasCrud(connString);

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
                    databasCrud.AddPeopleToDB();
                    Console.WriteLine("");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Environment.Exit(1);
                    break;
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