using ExchangeRateRuBotParser;

namespace ExchangeRatesRuBotLogic
{
    public class CourseReport
    {
        public string MakeCourseReport(List<Valute> valList)
        {
            string stringReport = $"Курс валюты на {ValuteList.ValuteRequestDate}:\n\n";

            for (int i = 0; i < valList.Count; i++)
            {
                if (valList[i].IsSelect == '✅')
                {
                    stringReport +=
                        $"Курс {valList[i].CharCode} к RUB:\n" +
                        $"{valList[i].Nominal} {valList[i].Name} = {valList[i].Value} руб.\n\n";
                }
            }
            return stringReport;
        }
    }
}