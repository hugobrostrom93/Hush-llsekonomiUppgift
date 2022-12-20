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
        Writelines writeline = new Writelines();
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

        public void PrintList()
        {
            var connString = Read("connString.txt");
            var cnn = new MySqlConnection(connString);

            cnn.Open();
            dt = new DataTable();
            sql = $"SELECT Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Mat, Hyra, Gym, Telefon, Internet, Spotify FROM EkonomiPerson";
            adt = new MySqlDataAdapter(sql, cnn);
            adt.Fill(dt);

            Console.WriteLine("");

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
            //else
            //{
            //    writeline.TABELLEN FINNS INTE
            //}
            cnn.Close();
        }

        public void PersonSök(string förnamn)
        {
            var connString = Read("connString.txt");
            var cnn = new MySqlConnection(connString);

            cnn.Open();
            dt = new DataTable();
            sql = $"SELECT Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Hyra, Mat, Gym, Telefon, Internet, Spotify FROM EkonomiPerson WHERE Förnamn = '{förnamn}';";
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
                        print.PrintRow("Förnamn", "Efternamn", "Månad", "Lön", "Studiemedel", "Bidrag", "El", "Hyra", "Mat", "Gym", "Telefon", "Internet", "Spotify");
                        print.PrintLine();
                        print.PrintRow(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString());
                        print.PrintLine();
                    }
                }
            }
            else
            {
                writeline.FINNSINTE(förnamn);
            }
        }

        public void AddPeopleToDB()
        {
            var connString = Read("connString.txt");
            var cnn = new MySqlConnection(connString);
            cnn.Open();

            var sql = "INSERT INTO EkonomiPerson (Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Hyra, Mat, Gym, Telefon, Internet, Spotify) VALUES (@Förnamn, @Efternamn, @Månad, @Lön, @Studiemedel, @Bidrag, @El, @Hyra, @Mat, @Gym, @Telefon, @Internet, @Spotify)";
            var cmd = new MySqlCommand(sql, cnn);


            AddWithValue(cmd, "@Förnamn");

            cmd.ExecuteNonQuery();
            writeline.AddToDBWlSpara();

            cnn.Close();
        }
        public void AddWithValue(MySqlCommand cmd, string value)
        {
            //writeline.AddToDbWlName();
            //cmd.Parameters.AddWithValue("{value}", Console.ReadLine());

            writeline.AddToDbWlName();
            cmd.Parameters.AddWithValue("@Förnamn", Console.ReadLine());

            writeline.AddToDbWlLastName();
            cmd.Parameters.AddWithValue("@Efternamn", Console.ReadLine());

            writeline.AddToDbWlPlaneraEkonomi();

            writeline.AddToDbWlMånad();
            var svar = cmd.Parameters.AddWithValue("@Månad", Console.ReadLine());

            writeline.AddToDbWlLön();
            cmd.Parameters.AddWithValue("@Lön", Console.ReadLine());

            writeline.AddToDbWlStudiemedel();
            cmd.Parameters.AddWithValue("@Studiemedel", Console.ReadLine());

            writeline.AddToDbWlBidrag();
            cmd.Parameters.AddWithValue("@Bidrag", Console.ReadLine());

            writeline.AddToDbWlBeräknaUtgifter();

            writeline.AddToDbWlEl();
            cmd.Parameters.AddWithValue("@El", Console.ReadLine());

            writeline.AddToDbWlHyra();
            cmd.Parameters.AddWithValue("@Hyra", Console.ReadLine());

            writeline.AddToDbWlMat();
            cmd.Parameters.AddWithValue("@Mat", Console.ReadLine());

            writeline.AddToDbWlGym();
            cmd.Parameters.AddWithValue("@Gym", Console.ReadLine());

            writeline.AddToDbWlTel();
            cmd.Parameters.AddWithValue("@Telefon", Console.ReadLine());

            writeline.AddToDbWlInternet();
            cmd.Parameters.AddWithValue("@Internet", Console.ReadLine());

            writeline.AddToDbWlspotify();
            cmd.Parameters.AddWithValue("@Spotify", Console.ReadLine());
        }
    }
}