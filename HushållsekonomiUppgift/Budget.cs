using Microsoft.Extensions.Configuration;
using MySqlConnector;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HushållsekonomiUppgift
{
    internal class Budget
    {
        public decimal SummeraBudget(string förnamn)
        {
            EkonomiPerson person = new EkonomiPerson();
            DatabasCrud databasCrud = new DatabasCrud();

            var connString = databasCrud.Read("connString.txt");
            var cnn = new MySqlConnection(connString);
            cnn.Open();

            // Summera inkomster
            var sql = $"SELECT SUM(Lön + Studiemedel + Bidrag) FROM `EkonomiPerson` WHERE Förnamn = '{förnamn}';";
            var cmd = new MySqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            
            person.Inkomst = (decimal)cmd.ExecuteScalar();

            // Summera utgifter
            var sql2 = $"SELECT SUM(El + Mat + Hyra + Gym + Telefon + Internet + Spotify) FROM `EkonomiPerson` WHERE Förnamn = '{förnamn}';";
            var cmd2 = new MySqlCommand(sql2, cnn);
            cmd2.ExecuteNonQuery();
            person.Utgift = (decimal)cmd2.ExecuteScalar();

            cnn.Close();

            Console.WriteLine("");
            Console.WriteLine($"{förnamn}s totala inkomster är {person.Inkomst}kr");
            Console.WriteLine($"{förnamn}s totala utgifter är {person.Utgift}kr");
            person.Oanadeutgifter = (person.Inkomst * 25) / 100;
            Console.WriteLine($"{förnamn}s oanade utgifter är {person.Oanadeutgifter}kr (alltså 25% av lönen)");
            person.Spara = (person.Inkomst * 10) / 100;
            Console.WriteLine($"Det {förnamn} ska spara när hen har fått lönen är {person.Spara}kr (alltså 10% av lönen)");
            var kvar = person.Inkomst - person.Utgift - person.Oanadeutgifter - person.Spara;
            Console.WriteLine($"Det {förnamn} har kvar att spendera efter alla hens utgifter + sparande är {person.Kvar}kr");           //VASADU
            Console.WriteLine("");
            return person.TotalInkomst;

        }
    }
}