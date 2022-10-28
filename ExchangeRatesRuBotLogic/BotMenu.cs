using ExchangeRateRuBotParser;
using Telegram.Bot.Types.ReplyMarkups;

namespace ExchangeRatesRuBotLogic
{
    public class BotMenu
    {
        public object CreateKeyBoard(string name, List<Valute> valList)
        {
            InlineKeyboardMarkup СurrencyKeyboard = new(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"{valList[10].IsSelect}  {valList[10].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[11].IsSelect}  {valList[11].CharCode}"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"{valList[0].IsSelect}  {valList[0].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[1].IsSelect}  {valList[1].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[2].IsSelect}  {valList[2].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[3].IsSelect}  {valList[3].CharCode}"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"{valList[4].IsSelect}  {valList[4].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[5].IsSelect}  {valList[5].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[6].IsSelect}  {valList[6].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[7].IsSelect}  {valList[7].CharCode}"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"{valList[8].IsSelect}  {valList[8].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[9].IsSelect}  {valList[9].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[12].IsSelect}  {valList[12].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[13].IsSelect}  {valList[13].CharCode}"),
                },

                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"{valList[14].IsSelect}  {valList[14].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[15].IsSelect}  {valList[15].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[16].IsSelect}  {valList[16].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[17].IsSelect}  {valList[17].CharCode}"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"{valList[18].IsSelect}  {valList[18].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[19].IsSelect}  {valList[19].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[20].IsSelect}  {valList[20].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[21].IsSelect}  {valList[21].CharCode}"),
                },
                new[]
                {

                    InlineKeyboardButton.WithCallbackData($"{valList[22].IsSelect}  {valList[22].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[23].IsSelect}  {valList[23].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[24].IsSelect}  {valList[24].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[25].IsSelect}  {valList[25].CharCode}"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"{valList[26].IsSelect}  {valList[26].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[27].IsSelect}  {valList[27].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[28].IsSelect}  {valList[28].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[29].IsSelect}  {valList[29].CharCode}"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData($"{valList[30].IsSelect}  {valList[30].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[31].IsSelect}  {valList[31].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[32].IsSelect}  {valList[32].CharCode}"),
                    InlineKeyboardButton.WithCallbackData($"{valList[33].IsSelect}  {valList[33].CharCode}"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Назад"),
                    InlineKeyboardButton.WithCallbackData("Далее"),
                }
            });
            InlineKeyboardMarkup StartKeyboard = new(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Ежедневно"),
                    InlineKeyboardButton.WithCallbackData("По запросу"),
                }
            });
            ReplyKeyboardMarkup ReplyKeyboard = new(new[]
{
                new KeyboardButton[] {"Запросить курс", "Настройки"},
            })
            {
                ResizeKeyboard = true
            };
            switch (name)
            {
                case "StartKeyboard": return StartKeyboard;
                case "СurrencyKeyboard": return СurrencyKeyboard;
                case "ReplyKeyboard": return ReplyKeyboard;
                default: return ReplyKeyboard;
            }
        }
    }
}