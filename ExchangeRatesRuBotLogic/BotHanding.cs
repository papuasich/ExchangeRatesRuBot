using ExchangeRateRuBotParser;
using ExchangeRatesRuBotDataBase;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExchangeRatesRuBotLogic
{
    public class TelegtabBotHandling
    {
        private TelegramBotClient botClient;
        private CancellationTokenSource cts;
        private char[] CharToTrim = { '⬜', '✅', ' ' };

        private BotMenu Menu = new();
        private List<Valute> valuteList = ValuteList.valuteList;


        public TelegtabBotHandling(TelegramBotClient botClient, CancellationTokenSource cts)
        {
            this.botClient = botClient;
            this.cts = cts;
        }

        public async Task HandleUpdatesAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await HandleMessage(botClient, update.Message);
                return;
            }
            if (update.Type == UpdateType.CallbackQuery)
            {

                await HandleCallBackQuery(botClient, update.CallbackQuery);
                return;
            }
        }

        public async Task HandleMessage(ITelegramBotClient botClient, Message message) //обработчик сообщений
        {
            if (message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Этот бот отправляет курсы валют ЦБ РФ" +
                " ежедневно или по запросу." + " Бот работает бесплатно. Давайте его настроим чтобы вам было удобно." +
                "Как вы хотите получать курсы?", replyMarkup: (InlineKeyboardMarkup)Menu.CreateKeyBoard("StartKeyboard", valuteList));
                return;
            }
            if (message.Text == "Запросить курс")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"{new CourseReport().MakeCourseReport(valuteList)}");
                return;
            }
            if (message.Text == "Настройки")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Настройки бота:", replyMarkup: (InlineKeyboardMarkup)Menu.CreateKeyBoard("StartKeyboard", valuteList));
                return;
            }
        }

        public async Task HandleCallBackQuery(ITelegramBotClient botClient, CallbackQuery callbackquery)
        {
            if (callbackquery.Data == "По запросу" || callbackquery.Data == "Ежедневно")
            {
                if(new DataBaseLogic().CheckUserInDb(callbackquery.Message.Chat.Username))
                {
                    //меняем на галочку в соответсвии с настройками пользователя в бД
                    var settings = new DataBaseLogic().GetUserSettings(callbackquery.Message.Chat.Username).Split(' ').ToList();

                    for (int i = 0; i < valuteList.Count; i++)
                    {
                        for (int j = 0; j < settings.Count; j++)
                        {
                            if (settings[j] == valuteList[i].CharCode)
                            {
                                valuteList[i].IsSelect = '✅';
                            }
                        }
                    }
                }


                await botClient.EditMessageTextAsync(callbackquery.Message.Chat.Id, callbackquery.Message.MessageId, "Выберите валюты для запроса," +
                " что бы не делать это каждый раз:", replyMarkup: (InlineKeyboardMarkup)Menu.CreateKeyBoard("СurrencyKeyboard", valuteList));
                return;
            }
            if (callbackquery.Data == "Назад")
            {
                await botClient.EditMessageTextAsync(callbackquery.Message.Chat.Id, callbackquery.Message.MessageId, "Этот бот отправляет курсы валют ЦБ РФ" +
                " ежедневно или по запросу." + " Бот работает бесплатно. Давайте его настроим чтобы вам было удобно." +
                "Как вы хотите получать курсы?", replyMarkup: (InlineKeyboardMarkup)Menu.CreateKeyBoard("StartKeyboard", valuteList));
                return;
            }
            if (callbackquery.Data == "Далее")
            {
                await botClient.EditMessageTextAsync(callbackquery.Message.Chat.Id, callbackquery.Message.MessageId, "Настройка завершена!");
                await botClient.SendTextMessageAsync(callbackquery.Message.Chat.Id, "Ожидаем команду.", replyMarkup: (ReplyKeyboardMarkup)Menu.CreateKeyBoard("ReplyKeyboard", valuteList));
                
                if(new DataBaseLogic().CheckUserInDb(callbackquery.Message.Chat.Username))
                {
                    new DataBaseLogic().UpdateUser(callbackquery.Message.Chat.Username, valuteList);
                }
                else
                {
                    new DataBaseLogic().CreateUser(callbackquery.Message.Chat.Username, valuteList);
                }
                return;
            }
            if (valuteList.Exists(x => x.CharCode == callbackquery.Data.Trim(CharToTrim)))
            {
                int Index = valuteList.FindIndex(x => x.CharCode == callbackquery.Data.Trim(CharToTrim));
                if (valuteList[Index].IsSelect == '⬜')
                {
                    valuteList[Index].IsSelect = '✅';
                }
                else
                {
                    valuteList[Index].IsSelect = '⬜';
                }

                await botClient.EditMessageTextAsync(callbackquery.Message.Chat.Id, callbackquery.Message.MessageId, "Выберите валюты для запроса," +
                " что бы не делать это каждый раз:", replyMarkup: (InlineKeyboardMarkup)Menu.CreateKeyBoard("СurrencyKeyboard", valuteList));
                return;
            }
        }

        public Task HandlerErrorAsync(Telegram.Bot.ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException piRequestException
                    => $"Ошибка API телеграма\n{piRequestException.ErrorCode}\n{piRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
