using ExchangeRateRuBotParser;
using System.Xml.Serialization;

namespace ExchangeRatesRuBotSerToXML
{
    public class Class1
    {
        public void SerealizeToXMLString(List<Valute> valList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Valute>));
            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, valList.Select(x=> x.IsSelect == '✅').Last());
                var xmlcont = writer.ToString();
                Console.WriteLine(xmlcont);
            }
        }
    }
}