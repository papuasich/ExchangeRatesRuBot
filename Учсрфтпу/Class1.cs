using ExchangeRateRuBotParser;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ExchangeRatesRuBotSerToXML
{
    public class Class1
    {
        public void SerToXML(List<Valute> valList)
        {
            XmlSerializer xmlSerializ = new XmlSerializer(typeof(List<Valute>));

            var j = valList.Where(selectValute => selectValute.IsSelect == '✅').Select(x => x.CharCode).ToList();

            foreach (var item in j)
            {
                Console.WriteLine(item);
            }

            using (var sw = new Utf8StringWriter())
            {
                xmlSerializ.Serialize(sw, valList.Where(selectValute => selectValute.IsSelect == '✅').ToList());
                Console.WriteLine(sw.ToString());
            }
        }
    }

    public class Utf8StringWriter : StringWriter
    {
        // Use UTF8 encoding but write no BOM to the wire
        public override Encoding Encoding
        {
            get { return new UTF8Encoding(false); } // in real code I'll cache this encoding.
        }
    }
}