using System.Data;
using HushållsekonomiUppgift.Visuals;
using MySqlConnector;

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

        //public void XYZ()
        //{
        //    while (true)
        //    {
        //        switch (Console.ReadKey().Key)
        //        {
        //            case ConsoleKey.D1:
        //            case ConsoleKey.NumPad1:
        //                var förnamn = Console.ReadLine();
        //                PersonSök(förnamn);

        //                break;
        //            case ConsoleKey.D2:
        //            case ConsoleKey.NumPad2:
        //                var efternamn = Console.ReadLine();
        //                PersonSök(efternamn);
        //                break;
        //        }
        //    }
        //}
            public void PersonSök(string namn)
            {
                var connString = Read("connString.txt");
                var cnn = new MySqlConnection(connString);

                cnn.Open();
   
                dt = new DataTable();
                sql = $"SELECT Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Hyra, Mat, Gym, Telefon, Internet, Spotify FROM EkonomiPerson WHERE Förnamn = '{förnamn}';";
                adt = new MySqlDataAdapter(sql, cnn);
                adt.Fill(dt);

            if (dt.Columns.Count == 1)
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
            else if (dt.Columns.Count > 1) 
            {
                sql = $"SELECT Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Hyra, Mat, Gym, Telefon, Internet, Spotify FROM EkonomiPerson WHERE Förnamn = '{efternamn}';";
                adt = new MySqlDataAdapter(sql, cnn);
                adt.Fill(dt);
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

                var sql = $"INSERT INTO EkonomiPerson (Förnamn, Efternamn, Månad, Lön, Studiemedel, Bidrag, El, Hyra, Mat, Gym, Telefon, Internet, Spotify) VALUES (@Förnamn, @Efternamn, @Månad, @Lön, @Studiemedel, @Bidrag, @El, @Hyra, @Mat, @Gym, @Telefon, @Internet, @Spotify)";
                var cmd = new MySqlCommand(sql, cnn);

                AddWithValue(cmd);

                cmd.ExecuteNonQuery();
                writeline.AddedToDbWl();
                cnn.Close();
            }
            public void AddWithValue(MySqlCommand cmd)
            {
                Arrays array = new Arrays();
                string[] sqlArray = array.GetArray();
                for (int i = 0; i < sqlArray.Length; i++)
                {
                    if (i < 6) writeline.AddToDbWl(sqlArray[i], "");
                    else writeline.AddToDbWl(sqlArray[i], "kostnad");
                    if (i < 3) cmd.Parameters.AddWithValue($"@{sqlArray[i]}", InputString(i));
                    else cmd.Parameters.AddWithValue($"@{sqlArray[i]}", InputNumber(i));
                }
            }
            public string InputString(int i)
            {
                string input = "";
                while (true)
                {
                    input = Console.ReadLine();
                    if (System.Text.RegularExpressions.Regex.IsMatch(input, @"\d"))
                    {
                        // input string contains a digit
                        Console.WriteLine("Du fåååår inte använda siffror\nFörsök igen!");
                    }
                    else break;
                }
                return input;
            }
            public decimal InputNumber(int i)
            {
                decimal input = 0;
                while (true)
                {
                    if (i >= 3)
                    {
                        if (decimal.TryParse(Console.ReadLine(), out input) && input >= 0)
                            return input;
                        else Console.WriteLine("Du fååår inte ha bokstäver eller negativa tal\nFörsök igen!");
                    }
                    else break;
                }
                return input;
            }
        }
    }