using System.Xml.Linq;

namespace ExchangeRateRuBotParser
{
    public class XMLSerializer
    {
        string? XMLString;

        public XMLSerializer(string? xMLString)
        {
            XMLString = xMLString;
        }

        public List<Valute> XMLSerializeIntoList()
        {
            if (!string.IsNullOrWhiteSpace(XMLString))
            {
                XDocument doc = XDocument.Parse(XMLString);

                return doc.Descendants("Valute").Select(val => new Valute
                (
                    val.Element("Name").Value,
                    val.Element("CharCode").Value,
                    decimal.Parse(val.Element("Value").Value),
                    decimal.Parse(val.Element("Nominal").Value)
                )).ToList();
            }
            return null;
        }

        public string XMLSerializeDate()
        {
            if (!string.IsNullOrWhiteSpace(XMLString))
            {
                XDocument doc = XDocument.Parse(XMLString);
                return doc.Root.Attribute("Date").Value;
            }
            return null;
        }
    }
}
