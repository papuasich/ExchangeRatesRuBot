using ExchangeRateRuBotParser;
using ExchangeRatesRuBotSerToXML;
using Npgsql;

namespace ExchangeRatesRuBotDataBase
{
    public class DataBaseLogic
    {
        private static NpgsqlConnection ConnectionString = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Qwerty12345+;Database=telegramusersinfo");
        
        public bool CheckUserInDb(string UserName)
        {
            ConnectionString.Open();
            
            var command = new NpgsqlCommand($"SELECT EXISTS(SELECT user_name FROM users WHERE user_name = '{UserName}')", ConnectionString);

            command.Prepare();

            var unswer = (bool)command.ExecuteScalar();

            ConnectionString.Close();

            return unswer;
        }

        public void CreateUser(string UserName, List<Valute> valList)
        {
            ConnectionString.Open();

            var command = new NpgsqlCommand($"INSERT INTO users(user_name, user_settings) VALUES('{UserName}', '1')", ConnectionString);

            command.ExecuteNonQuery();

            ConnectionString.Close();
        }

        public void UpdateUser(string UserName, List<Valute> valList)
        {
            ConnectionString.Open();

            var command = new NpgsqlCommand($"UPDATE users SET user_settings = '{new SerValuteToXML().SerToXML(valList)}' WHERE user_name = '{UserName}'", ConnectionString);

            command.ExecuteNonQuery();

            ConnectionString.Close();
        }

        public string GetUserSettings(string UserName)
        {
            ConnectionString.Open();

            var command = new NpgsqlCommand($"SELECT user_settings FROM users WHERE user_name = '{UserName}'", ConnectionString);

            if (command.ExecuteScalar() is string unswer)
            {
                ConnectionString.Close();
                return unswer;
            }

            ConnectionString.Close();

            return null;
        }
    }
}

//UPDATE users SET user_settings = '2' WHERE user_name = 'glyukanatnatriya'