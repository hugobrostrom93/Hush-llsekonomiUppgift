using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Org.BouncyCastle.Asn1.Crmf;

namespace HushållsekonomiUppgift
{
    internal class DatabasCrud
    {

        PrintMetod print = new PrintMetod();
        DataTable dt = new DataTable();
        MySqlDataAdapter adt = new MySqlDataAdapter();
        string sql = "";

        public string Read(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string connString = File.ReadAllText(path + "\\" + filename);

            return connString;
        }
        public DatabasCrud()
        {
            var connString = Read("connString.txt");
            var cnn = new MySqlConnection(connString);
            cnn.Open();
        }

        public void PrintList()
        {
            var connString = Read("connString.txt");
            var cnn = new MySqlConnection(connString);

            cnn.Open();
            dt = new DataTable();
            sql = "SELECT Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Hyra, Mat, Gym, Telefon, Internet, Spotify FROM EkonomiPerson;";
            adt = new MySqlDataAdapter(sql, cnn);
            adt.Fill(dt);

            Console.WriteLine("");
            //Console.Clear();
            if (dt.Columns.Count > 0)
            {
                print.PrintLine();
                print.PrintRow("Förnamn", "Efternamn", "Månad", "Lön", "Studiemedel", "Bidrag", "El", "Mat", "Hyra", "Gym", "Telefon", "Internet", "Spotify");
                print.PrintLine();

                foreach (DataRow row in dt.Rows)
                {
                    print.PrintRow(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString());
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Ingen person hittades.");
            }
            cnn.Close();
        }

        public void PersonSök(string name)
        {
            var connString = Read("connString.txt");
            var cnn = new MySqlConnection(connString);

            cnn.Open();
            dt = new DataTable();
            sql = $"SELECT Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Hyra, Mat, Gym, Telefon, Internet, Spotify FROM EkonomiPerson WHERE Förnamn = '{name}';";
            adt = new MySqlDataAdapter(sql, cnn);
            adt.Fill(dt);

            if (dt.Columns.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Console.Write(row[column] + " ");

                        Console.Clear();
                        print.PrintLine();
                        print.PrintRow("Förnamn", "Efternamn", "Månad", "Lön", "Studiemedel", "Bidrag", "El", "Mat", "Hyra", "Gym", "Telefon", "Internet", "Spotify");
                        print.PrintLine();
                        print.PrintRow(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString());
                        print.PrintLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Ingen person hittades.");
            }
        }

        public void AddPeopleToDB()
        {
            var connString = Read("connString.txt");
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
            Console.WriteLine("");

            Console.ReadLine();
            cnn.Close();
        }
    }
}