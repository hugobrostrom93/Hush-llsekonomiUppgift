using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    public class Budget
    {
        List<Inkomster> inkomster = new List<Inkomster>();
        List<Utgifter> utgifter = new List<Utgifter>();
        List<KalkyleradeUtgifter> kalkyleradeUtgifter = new List<KalkyleradeUtgifter>();

        public void AddLists()
        {
            // Inkomster i form av lön + studiemedel
            inkomster.Add(new Inkomster(12000, 14000));
            // Utgifter
            utgifter.Add(new Utgifter(899, 7500, 6000, 499, 499, 350, 99, 99));
            // Kalkylerade utgifter i from av sparande och oanade utfigter i % som räknas ner längre ner
            kalkyleradeUtgifter.Add(new KalkyleradeUtgifter(10, 20));
        }

        public int AdderaInkomster()
        {
            int sumInkomster = 0;
            foreach (var item in inkomster)
            {
                sumInkomster += item.lön;
                sumInkomster += item.studiemedel;                
            }
            return sumInkomster;
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
            return sumUtgifter;
        }
        
        
        public int Sparat(int pengar)
        {
            int sumSpara = 0;
            foreach (var item in kalkyleradeUtgifter)
            {
                sumSpara = (pengar * item.spara) / 100;               
            }
            return sumSpara;
        }

        public int OanadeUtgifter(int pengar)
        {
            int sumOanade = 0;
            foreach (var item in kalkyleradeUtgifter)
            {
                sumOanade = (pengar * item.oanadeUtgifter) / 100;

            }
            return sumOanade;
        }

        public int CashKvar()
        {
            int sumCashKvar = 0;
            sumCashKvar = AdderaInkomster() - AdderaUtgifter() - Sparat(AdderaInkomster()) - OanadeUtgifter(AdderaInkomster());
            return sumCashKvar;
        }

        public void RunMethods()
        {
            AddLists();
            Console.WriteLine($"Summan av inkomsterna är {AdderaInkomster()}kr\n");
            Console.WriteLine($"Summan av utgifterna är {AdderaUtgifter()}kr\n");
            Console.WriteLine($"Summan av det du har sparat för månaden är {Sparat(AdderaInkomster())}kr. Alltså 10% av din inkomst\n");
            Console.WriteLine($"Summan av dina oanade utgifter är {OanadeUtgifter(AdderaInkomster())}kr. Alltså 20% av din inkomst\n");
            Console.WriteLine($"Summan av pengarna du har kvar efter att ha betalat alla dina utgifter är {CashKvar()}kr\n");
        }


    }
}
