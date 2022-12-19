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
            Writelines writeline = new Writelines();
            EkonomiPerson person = new EkonomiPerson();
            DatabasCrud databasCrud = new DatabasCrud();

            var connString = databasCrud.Read("connString.txt");
            var cnn = new MySqlConnection(connString);
            cnn.Open();

            // Summera inkomster
            var sql = $"SELECT SUM(Lön + Studiemedel + Bidrag) FROM `EkonomiPerson` WHERE Förnamn = '{förnamn}';";
            var cmd = new MySqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            if (cmd.ExecuteScalar() != DBNull.Value)
            {
                person.TotalInkomst = (decimal)cmd.ExecuteScalar();
            }
            else
            {
                writeline.FINNSINTE(förnamn);
                return person.TotalInkomst;
            }

            // Summera utgifter
            var sql2 = $"SELECT SUM(El + Mat + Hyra + Gym + Telefon + Internet + Spotify) FROM `EkonomiPerson` WHERE Förnamn = '{förnamn}';";
            var cmd2 = new MySqlCommand(sql2, cnn);
            cmd2.ExecuteNonQuery();
            person.Utgift = (decimal)cmd2.ExecuteScalar();

            writeline.SummeraUtgifterWR(förnamn, person);

            if (person.TotalUtgift != null)
            {
                person.TotalUtgift = (decimal)cmd.ExecuteScalar();
            }
            else
            {
                writeline.FINNSINTE(förnamn);
                return person.TotalUtgift;
            }
            cnn.Close();
            return person.TotalUtgift;

        }
    }
}