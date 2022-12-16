using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    public class Budget
    {
        MySqlConnection cnn = null;
        public void TotalInkomst()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string connString = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";
            var cnn = new MySqlConnection(connString);
            cnn.Open();

            var sql = "SELECT Lön, Studiemedel, Bidrag FROM `EkonomiPerson` WHERE Förnamn = 'Donald';";
            var cmd = new MySqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();

            var dt = new DataTable();
            var adt = new MySqlDataAdapter(sql, cnn);
            adt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"Donald har: {row["Lön"]} i lön");
                    Console.WriteLine($"Donald har: {row["Studiemedel"]} i studiemedel");
                    Console.WriteLine($"Donald har: {row["Bidrag"]} i bidrag");
                    var sum = row["Lön"] + row["Studiemedel"] + row["Bidrag"];
                    Console.WriteLine(sum);
                }
            }

        }



        //public int AdderaInkomster()
        //{
        //    int sumInkomster = 0;
        //    foreach (var item in inkomster)
        //    {
        //        sumInkomster += item.lön;
        //        sumInkomster += item.studiemedel;
        //    }
        //    return sumInkomster;
        //}

        //public int AdderaUtgifter()
        //{
        //    int sumUtgifter = 0;
        //    foreach (var item in utgifter)
        //    {
        //        sumUtgifter += item.elräkning;
        //        sumUtgifter += item.hyra;
        //        sumUtgifter += item.mat;
        //        sumUtgifter += item.gym;
        //        sumUtgifter += item.telefon;
        //        sumUtgifter += item.internet;
        //        sumUtgifter += item.netflix;
        //        sumUtgifter += item.spotify;
        //    }
        //    return sumUtgifter;
        //}


        //public int Sparat(int pengar)
        //{
        //    int sumSpara = 0;
        //    foreach (var item in kalkyleradeUtgifter)
        //    {
        //        sumSpara = (pengar * item.spara) / 100;
        //    }
        //    return sumSpara;
        //}

        //public int OanadeUtgifter(int pengar)
        //{
        //    int sumOanade = 0;
        //    foreach (var item in kalkyleradeUtgifter)
        //    {
        //        sumOanade = (pengar * item.oanadeUtgifter) / 100;

        //    }
        //    return sumOanade;
        //}

        //public int CashKvar()
        //{
        //    int sumCashKvar = 0;
        //    sumCashKvar = AdderaInkomster() - AdderaUtgifter() - Sparat(AdderaInkomster()) - OanadeUtgifter(AdderaInkomster());
        //    return sumCashKvar;
        //}

        //public void RunMethods()
        //{
        //    AddLists();
        //    Console.WriteLine($"Summan av inkomsterna är {AdderaInkomster()}kr\n");
        //    Console.WriteLine($"Summan av utgifterna är {AdderaUtgifter()}kr\n");
        //    // Spara 10% av det vi har kvar efter våra utgifter
        //    Console.WriteLine($"Summan av det du har sparat för månaden är {Sparat(CashKvar())}kr. Alltså 10% av det du har kvar efter alla utgifter\n");
        //    Console.WriteLine($"Summan av dina oanade utgifter är {OanadeUtgifter(AdderaInkomster())}kr. Alltså 20% av din inkomst\n");
        //    Console.WriteLine($"Summan av pengarna du har kvar efter att ha betalat alla dina utgifter är {CashKvar()}kr\n");
        //}


    }
}
