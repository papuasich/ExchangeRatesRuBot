using ExchangeRateRuBotParser;
using ExchangeRatesRuBotLogic;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace CurrencyConverterSuperBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string? XMLStringFromCBRF = new Parser().MakeAGETRequestToCBRF();
            new ValuteList(new XMLSerializer(XMLStringFromCBRF).XMLSerializeIntoList(), new XMLSerializer(XMLStringFromCBRF).XMLSerializeDate());

            var botClient = new TelegramBotClient("5636621643:AAFsJ84e9BN2mCRr43q7EL6kDfjb3ZkJYd4");
            using var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };

            var TelegramBotFunc = new TelegtabBotHandling(botClient, cts);

            botClient.StartReceiving(
                TelegramBotFunc.HandleUpdatesAsync,
                TelegramBotFunc.HandlerErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync();

            //CurrencyParse.CurrencyParseFromCBRF(); //парсим XML с сайта ЦБ РФ
            Console.WriteLine($"Начал прослушку @{me.FirstName}");
            Console.ReadLine();
            cts.Cancel();
        }
    }
}