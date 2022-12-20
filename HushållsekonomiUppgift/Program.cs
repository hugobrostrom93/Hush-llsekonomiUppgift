using HushållsekonomiUppgift;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Logic.Run();
    }
}