using Npgsql;
using System.Reflection.Metadata;
using System.Text.Json.Nodes;

namespace ExchangeRatesRuBotDataBase
{
    public class DataBaseLogic
    {
        private string ConnectionString = "Host=localhost;Username=postgres;Password=Qwerty12345;Database=telegramusersinfo";
        public NpgsqlConnection CreateConnectionString()
        {
            var connection = new NpgsqlConnection(ConnectionString);

            return connection;
        }

        public void CreateUser(int UserId, JsonArray UserSettings)
        {
            var sql = @"INSERT INTO users VALUES({UserId}, {UserSettings})";
        }

        public void CheckUserInDb(int UserId)
        {
            var ConnectionString = CreateConnectionString();
            ConnectionString.Open();
            
            var command = new NpgsqlCommand("SELECT EXISTS(SELECT * FROM users WHERE user_id = @user_id)", ConnectionString);

            command.Parameters.AddWithValue(1223);

            command.Prepare();
            var res = command.GetType();
            using NpgsqlDataReader rdr = command.ExecuteReader();
            ConnectionString.Close();

            Console.WriteLine(res); 
        }
    }
}


//var sql = "SELECT * FROM users";

//using var cmd = new NpgsqlCommand(sql, con);
//var rdr = cmd.ExecuteReader();

//while (rdr.Read())
//{
//    Console.WriteLine("{0} {1}", rdr.GetInt32(0), rdr.GetDataTypeName(1).ToString());
//}