using HushållsekonomiUppgift.DTO;
using HushållsekonomiUppgift.Visuals;
using MySqlConnector;

namespace HushållsekonomiUppgift
{
    public class Beräkningar
    {
        public decimal SummeraBudgetInkomst(string förnamn)
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
            }
            cnn.Close();
            return person.TotalInkomst;

        }
        public decimal SummeraBudgetUtgift(string förnamn)
        {
            Writelines writeline = new Writelines();
            EkonomiPerson person = new EkonomiPerson();
            DatabasCrud databasCrud = new DatabasCrud();

            var connString = databasCrud.Read("connString.txt");
            var cnn = new MySqlConnection(connString);
            cnn.Open();

            // Summera utgifter
            var sql = $"SELECT SUM(El + Mat + Hyra + Gym + Telefon + Internet + Spotify) FROM `EkonomiPerson` WHERE Förnamn = '{förnamn}';";
            var cmd = new MySqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            person.Utgift = (decimal)cmd.ExecuteScalar();

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