using Npgsql;
using System.Text.Json.Nodes;

namespace ExchangeRatesRuBotDataBase
{
    public class DataBaseLogic
    {
        private static NpgsqlConnection ConnectionString = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Qwerty12345;Database=telegramusersinfo");
        
        public bool CheckUserInDb(int UserId)
        {
            ConnectionString.Open();
            
            var command = new NpgsqlCommand($"SELECT EXISTS(SELECT * FROM users WHERE user_id = {UserId})", ConnectionString);

            command.Prepare();

            return (bool)command.ExecuteScalar();
        }
    }
}