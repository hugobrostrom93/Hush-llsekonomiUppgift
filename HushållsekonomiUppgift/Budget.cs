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
            DatabasCrud databasCrud= new DatabasCrud();

            var connString = databasCrud.Read("connString.txt");
            var cnn = new MySqlConnection(connString);
            cnn.Open();
          
            // Summera inkomster
            var sql = $"SELECT SUM(Lön + Studiemedel + Bidrag) FROM `EkonomiPerson` WHERE Förnamn = '{förnamn}';";
            var cmd = new MySqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            person.inkomst = (decimal)cmd.ExecuteScalar();

            // Summera utgifter
            var sql2 = $"SELECT SUM(El + Mat + Hyra + Gym + Telefon + Internet + Spotify) FROM `EkonomiPerson` WHERE Förnamn = '{förnamn}';";
            var cmd2 = new MySqlCommand(sql2, cnn);
            cmd2.ExecuteNonQuery();
            person.utgift = (decimal)cmd2.ExecuteScalar();

            cnn.Close();

            Console.WriteLine("");
            Console.WriteLine($"{person.förnamn}s totala inkomster är {person.inkomst}kr");
            Console.WriteLine($"{person.förnamn}s totala utgifter är {person.utgift}kr");
            person.oanadeutgifter = (person.inkomst * 25) / 100;
            Console.WriteLine($"{person.förnamn}s oanade utgifter är {person.oanadeutgifter}kr (alltså 25% av lönen)");
            person.spara = (person.inkomst * 10) / 100;
            Console.WriteLine($"Det {person.förnamn} ska spara när hen har fått lönen är {person.spara}kr (alltså 10% av lönen)");
            var kvar = person.inkomst - person.utgift - person.oanadeutgifter - person.spara;
            Console.WriteLine($"Det {person.förnamn} har kvar att spendera efter alla hens utgifter + sparande är {kvar}kr");           //VASADU
            Console.WriteLine("");
            return person.inkomst;
        }
    }
}