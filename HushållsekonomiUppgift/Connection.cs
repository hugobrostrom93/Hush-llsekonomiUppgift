using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift
{
    internal class Connection
    {
        protected static string Path { get; set; } = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ConnectionString.txt");
        protected static string ConnString { get; set; } = File.ReadAllText(Path);
        protected DataTable dt = new DataTable();
        protected MySqlDataAdapter adt = new MySqlDataAdapter();
        protected MySqlConnection cnn = new MySqlConnection(ConnString);
    }
}
