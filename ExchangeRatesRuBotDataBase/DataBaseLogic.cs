using Npgsql;

namespace ExchangeRatesRuBotDataBase
{
    public class DataBaseLogic
    {
        private static NpgsqlConnection ConnectionString = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Qwerty12345;Database=telegramusersinfo");
        
        public static void CheckUserInDb(string UserName)
        {
            ConnectionString.Open();
            
            var command = new NpgsqlCommand($"SELECT EXISTS(SELECT user_name FROM users WHERE user_name = '{UserName}')", ConnectionString);

            command.Prepare();

            
            Console.WriteLine(command.ToString());


            ConnectionString.Close();
        }
    }
}