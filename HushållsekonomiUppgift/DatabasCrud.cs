using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySqlConnector;


namespace HushållsekonomiUppgift
{
    internal class DatabasCrud
    {
        // Läsa in en secret connection string
        // Koppla sig till en databas
        // Koppla ner från databasen
        MySqlConnection cnn = null;

        public DatabasCrud(string connString)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string secret = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";
            cnn = new MySqlConnection(secret);
            cnn.Open();
        }

        public void AddPeopleToDB()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string connString = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";

            // Eventuellt lägga till så den söker igenom om person redan finns i listan

            var cnn = new MySqlConnection(connString);
            cnn.Open();
            var sql = "INSERT INTO EkonomiPerson (Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Hyra, Mat, Gym, Telefon, Internet, Spotify) VALUES (@Förnamn, @Efternamn, @Månad, @Lön, @Studiemedel, @Bidrag, @El, @Hyra, @Mat, @Gym, @Telefon, @Internet, @Spotify)";
            var cmd = new MySqlCommand(sql, cnn);


            Console.WriteLine("");
            Console.WriteLine("Ange ditt förnamn: ");
            cmd.Parameters.AddWithValue("@Förnamn", Console.ReadLine());

            Console.WriteLine("Ange ditt efternamn: ");
            cmd.Parameters.AddWithValue("@Efternamn", Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Grymt! Nu är det dags att planera din ekonomi");
            Console.WriteLine("Vi börjar med att beräkna dina inkomster!");
            Console.WriteLine("");

            Console.WriteLine("Ange vilken månad du vill planera för: ");
            var svar = cmd.Parameters.AddWithValue("@Månad", Console.ReadLine());
            
            Console.WriteLine("Ange hur mycket lön du kommer att få in denna månad:");
            cmd.Parameters.AddWithValue("@Lön", Console.ReadLine());

            Console.WriteLine("Ange hur mycket studiemedel du kommer att få in denna månad:");
            cmd.Parameters.AddWithValue("@Studiemedel", Console.ReadLine());

            Console.WriteLine("Ange hur mycket bidrag du kommer att få in denna månad:");
            cmd.Parameters.AddWithValue("@Bidrag", Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Tack. Nu är det dags för att beräkna dina utgifter!");
            Console.WriteLine("");

            Console.WriteLine("Ange hur mycket el du betalar per månad:");
            cmd.Parameters.AddWithValue("@El", Console.ReadLine());

            Console.WriteLine("Ange hyra du betalar per månad:");
            cmd.Parameters.AddWithValue("@Hyra", Console.ReadLine());

            Console.WriteLine("Ange hur mycket mat du planerar att handla för under denna månad:");
            cmd.Parameters.AddWithValue("@Mat", Console.ReadLine());

            Console.WriteLine("Ange hur mycket du betalar för gym per månad:");
            cmd.Parameters.AddWithValue("@Gym", Console.ReadLine());

            Console.WriteLine("Ange hur mycket du betalar för din telefon per månad:");
            cmd.Parameters.AddWithValue("@Telefon", Console.ReadLine());

            Console.WriteLine("Ange hur mycket du betalar för internet per månad:");
            cmd.Parameters.AddWithValue("@Internet", Console.ReadLine());

            Console.WriteLine("Ange hur mycket du betalar för spotify per månad:");
            cmd.Parameters.AddWithValue("@Spotify", Console.ReadLine());


            cmd.ExecuteNonQuery();
            Console.WriteLine("Fantastiskt! Nu har vi lagt till all denna infon i vår Databas!");

            // Skriv ut beräkningar, alltså vad den har kvar att spendera + oanade utgifter + spara

            Console.ReadLine();
            cnn.Close();
        }



        // Koden nedan är ifall vi vill ha olika listor för person och ekonomi vilket känns VÄLDIGT ONÖDIGT 



        //public void AddEconomyToDB()
        //{
        //    var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        //    string connString = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";

        //    Console.WriteLine("Här kan du lägga till ny ekonomi i listan!");

        //    var cnn = new MySqlConnection(connString);
        //    cnn.Open();
        //    Console.WriteLine($"Using Database: {cnn.Database}");
        //    var sql = "INSERT INTO Hushållsekonomi (Månad, El, Hyra, Mat, Gym, Telefon, Internet, Netflix, Spotify, Lön, Bidrag, Studiemedel) VALUES (@Månad, @El, @Hyra, @Mat, @Gym, @Telefon, @Internet, @Netflix, @Spotify, @Lön, @Bidrag, @Studiemedel)";
        //    var cmd = new MySqlCommand(sql, cnn);

        //    Console.WriteLine("Lägg till Månad: ");
        //    cmd.Parameters.AddWithValue("@Månad", Console.ReadLine());

        //    Console.WriteLine("Lägg till El: ");
        //    cmd.Parameters.AddWithValue("@El", Console.ReadLine());

        //    Console.WriteLine("Lägg till Hyra: ");
        //    cmd.Parameters.AddWithValue("@Hyra", Console.ReadLine());

        //    Console.WriteLine("Lägg till Mat: ");
        //    cmd.Parameters.AddWithValue("@Mat", Console.ReadLine());

        //    Console.WriteLine("Lägg till Gym: ");
        //    cmd.Parameters.AddWithValue("@Gym", Console.ReadLine());

        //    Console.WriteLine("Lägg till Telefon: ");
        //    cmd.Parameters.AddWithValue("@Telefon", Console.ReadLine());

        //    Console.WriteLine("Lägg till Internet: ");
        //    cmd.Parameters.AddWithValue("@Internet", Console.ReadLine());

        //    Console.WriteLine("Lägg till Netflix: ");
        //    cmd.Parameters.AddWithValue("@Netflix", Console.ReadLine());

        //    Console.WriteLine("Lägg till Spotify: ");
        //    cmd.Parameters.AddWithValue("@Spotify", Console.ReadLine());

        //    Console.WriteLine("Lägg till Lön: ");
        //    cmd.Parameters.AddWithValue("@Lön", Console.ReadLine());

        //    Console.WriteLine("Lägg till Bidrag: ");
        //    cmd.Parameters.AddWithValue("@Bidrag", Console.ReadLine());

        //    Console.WriteLine("Lägg till Studiemedel: ");
        //    cmd.Parameters.AddWithValue("@Studiemedel", Console.ReadLine());

        //    cmd.ExecuteNonQuery();
        //    Console.WriteLine($"All ekonomi har nu lagts till!");
        //    Console.ReadLine();
        //    cnn.Close();
        //}

        //public void AddPersonToEconomy(Hushållsekonomi hushållsekonomi, HushållsekonomiPerson hushållsekonomiPerson, string name)
        //{
        //    var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        //    string connString = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";

        //    string personId = "";
        //    Console.WriteLine("Vad är namnet på den personen som du vill lägga till?");
        //    string personName = Console.ReadLine().ToUpper();
        //    var persons = GetPerson();
        //    int x = 0;
        //    var cnn = new MySqlConnection(connString);
        //    cnn.Open();
        //    do
        //    {
        //        if (persons[x].förNamn.ToUpper() == personName)
        //        {
        //            personId = persons[x].Id.ToString();
        //            break;
        //        }
        //        else
        //        {
        //            x++;
        //        }
        //    } while (true);
        //    // Kolla om relationen finns i databasen, i så fall är du klar
        //    var ekonomi = GetEconomy();
        //    int i = 0;
        //    int y = 0;
        //    string act = ekonomi[y].lön.ToString();
        //    for (y = 0; y < ekonomi.Count; y++)
        //    {
        //        if (act == name)
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            act = ekonomi[y].lön.ToString();
        //        }
        //    }
        //    do
        //    {
        //        if (act == name && personId == persons[x].Id.ToString())
        //        {
        //            Console.WriteLine("Denna personen finns redan");
        //            i++;
        //            break;
        //        }
        //        else
        //        {

        //            i++;
        //        }
        //        var sql = "INSERT INTO EkonomiOchPersoner (PersonId, EkonomiId) VALUES (@PersonId, @EkonomiId)";
        //        var cmd = new MySqlCommand(sql, cnn);
        //        var PersonId = persons[y - 1].Id.ToString();
        //        cmd.Parameters.AddWithValue("@PersonId", PersonId);
        //        cmd.Parameters.AddWithValue("@EkonomiId", ekonomi);
        //        cmd.ExecuteNonQuery();
        //        cnn.Close();

        //    } while (true);
        //}

        //public List<Hushållsekonomi> GetEconomy()
        //{
        //    var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        //    string connString = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";
        //    var cnn = new MySqlConnection(connString);
        //    cnn.Open();
        //    List<Hushållsekonomi> listOfEconomy = new();
        //    var dt = new DataTable();

        //    var sql = "SELECT * "
        //    + "FROM Actor";                                 //SQL kod, som skickas in (sen)
        //    var adt = new MySqlDataAdapter(sql, cnn);           //tar med parameter från sql koden och skickar till databasen. 
        //    adt.Fill(dt);                                   //hämtar data från databasen som gör så att vi ska kunna se den. 

        //    int i = 0;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Hushållsekonomi hushållsekonomi = new Hushållsekonomi();

        //        hushållsekonomi.månad = row["Månad"].ToString();
        //        hushållsekonomi.el = int.Parse(row["El"].ToString());
        //        hushållsekonomi.hyra = int.Parse(row["Hyra"].ToString());
        //        hushållsekonomi.mat = int.Parse(row["Mat"].ToString());
        //        hushållsekonomi.gym = int.Parse(row["Gym"].ToString());
        //        hushållsekonomi.telefon = int.Parse(row["Telefon"].ToString());
        //        hushållsekonomi.internet = int.Parse(row["Internet"].ToString());
        //        hushållsekonomi.netflix = int.Parse(row["Netflix"].ToString());
        //        hushållsekonomi.spotify = int.Parse(row["Spotify"].ToString());
        //        hushållsekonomi.lön = int.Parse(row["Lön"].ToString());
        //        hushållsekonomi.bidrag = int.Parse(row["Bidrag"].ToString());
        //        hushållsekonomi.studiemedel = int.Parse(row["Studiemedel"].ToString());

        //        listOfEconomy.Add(hushållsekonomi);
        //        i++;
        //    };

        //    return listOfEconomy;
        //    cnn.Close();
        //}

        //public List<HushållsekonomiPerson> GetPerson()
        //{
        //    var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        //    string connString = @$"Server={config["Server"]};Database={config["Database"]};Uid={config["Uid"]};Pwd={config["Pwd"]};";
        //    var cnn = new MySqlConnection(connString);
        //    cnn.Open();
        //    List<HushållsekonomiPerson> personList = new();
        //    var dt = new DataTable();
        //    var sql = "SELECT * "
        //    + "FROM Movies";//SQL kod, som skickas in (sen)
        //    var adt = new MySqlDataAdapter(sql, cnn);//tar med parameter från sql koden och skickar till databasen. 
        //    adt.Fill(dt);//hämtar data från databasen som gör så att vi ska kunna se den. 

        //    int i = 0;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        HushållsekonomiPerson hushållsekonomiPerson = new HushållsekonomiPerson();
        //        hushållsekonomiPerson.förNamn = row["Förnamn"].ToString();
        //        hushållsekonomiPerson.efterNamn = row["Efternamn"].ToString();
        //        personList.Add(hushållsekonomiPerson);
        //        i++;
        //    };
        //    return personList;
        //    cnn.Close();

        //    // Koppla ihop personer med deras ekonomi
        //}
        //public void LinkPersonToEconomy()
        //{

        //}
    }
}