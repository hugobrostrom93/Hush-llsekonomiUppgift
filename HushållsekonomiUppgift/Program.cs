using HushållsekonomiUppgift;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Budget budget = new Budget();
        
        budget.AddLists();
        budget.AdderaInkomster();
        budget.AdderaInkomster.AdderaSparaa();
        //budget.();
        //budget.AdderaInkomster();
        //budget.AdderaUtgifter();
        //budget.AdderaSpara();
        ////budget.AdderaOanade();

        ////budget.RunMethods();  
    }
}