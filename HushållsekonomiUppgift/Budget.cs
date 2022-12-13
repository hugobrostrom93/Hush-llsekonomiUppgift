using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    internal class Budget
    {
        List<Inkomster> inkomster = new List<Inkomster>();
        List<Utgifter> utgifter = new List<Utgifter>();
        List<KalkyleradeUtgifter> kalkyleradeUtgifter = new List<KalkyleradeUtgifter>();
        Budget budget;

        public void AddLists()
        {
            inkomster.Add(new Inkomster(12000, 14000));
            utgifter.Add(new Utgifter(899, 7500, 6000, 499, 499, 350, 99, 99));
            kalkyleradeUtgifter.Add(new KalkyleradeUtgifter(15, 20));
        }

        public int AdderaInkomster()
        {
            int sumInkomster = 0;
            foreach (var item in inkomster)
            {
                sumInkomster += item.lön;
                sumInkomster += item.studiemedel;                
            }
            Console.WriteLine($"Summan av inkomsterna är {sumInkomster}kr");
            return sumInkomster;
        }

        public int Test()
        {
            int fill = 0;
            fill = budget.AdderaInkomster();
            Console.WriteLine(fill);
            return fill;
        }

        public int AdderaUtgifter()
        {
            int sumUtgifter = 0;
            foreach (var item in utgifter)
            {
                sumUtgifter += item.elräkning;
                sumUtgifter += item.hyra;
                sumUtgifter += item.mat;
                sumUtgifter += item.gym;
                sumUtgifter += item.telefon;
                sumUtgifter += item.internet;
                sumUtgifter += item.netflix;
                sumUtgifter += item.spotify;
            }
            Console.WriteLine($"Summan av utgifterna är {sumUtgifter}kr");
            return sumUtgifter;
        }
        

        public int AdderaSpara()
        {
            int sumSpara = 0;
            foreach (var item in kalkyleradeUtgifter)
            {
                sumSpara = (budget.AdderaInkomster() * item.spara) / 100;
                
            }
            Console.WriteLine($"Summan av det du har sparat för månaden är {sumSpara}kr");
            return sumSpara;
        }

        public int AdderaOanade()
        {
            int sumOanade = 0;
            foreach (var item in kalkyleradeUtgifter)
            {
                sumOanade = (budget.AdderaInkomster() * item.oanadeUtgifter) / 100;

            }
            Console.WriteLine($"Summan av dina oanade utgifter är {sumOanade}kr");
            return sumOanade;
        }

        public void RunMethods()
        {
            AddLists();
            AdderaInkomster();
            AdderaUtgifter();
            AdderaSpara();
            AdderaOanade();
        }
        

        //public void AddInkomster() 
        //{            
        //    inkomster.Add(new Inkomster(12000, 14000));
        //}

        //public void AddUtgifter()
        //{
        //    utgifter.Add(new Utgifter(899, 7500, 6000, 499, 499, 350, 99, 99));
        //}

        //public void AddOanadaUtgifter()
        //{
        //    kalkyleradeUtgifter.Add(new KalkyleradeUtgifter(15, 20));
        //}
    }
}
