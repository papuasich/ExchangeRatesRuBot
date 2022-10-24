using Npgsql;
using System.Reflection.Metadata;
using System.Text.Json.Nodes;

namespace ExchangeRatesRuBotDataBase
{
    public class DataBaseLogic
    {
    //    private string ConnectionString = "Host=localhost;Username=postgres;Password=Qwerty12345;Database=telegramusersinfo";
    //    public void ConnectionOpen()
    //    {
    //        var connection = new NpgsqlConnection(ConnectionString);
    //        connection.Open();
    //    }

    //    public void ConnectionClose()
    //    {
    //        var connection = new NpgsqlConnection(ConnectionString);
    //        connection.Close();
    //    }

    //    public void CreateUser(int UserId, JsonArray UserSettings)
    //    {
    //        var sql = @"INSERT INTO users VALUES({UserId}, {UserSettings})";
    //    }

    }
}


//var sql = "SELECT * FROM users";

//using var cmd = new NpgsqlCommand(sql, con);
//var rdr = cmd.ExecuteReader();

//while (rdr.Read())
//{
//    Console.WriteLine("{0} {1}", rdr.GetInt32(0), rdr.GetDataTypeName(1).ToString());
//}