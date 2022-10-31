using ExchangeRateRuBotParser;
using System.Text;
using System.Xml.Serialization;

namespace ExchangeRatesRuBotSerToXML
{
    //не к xml, a к строке с ччаркодами
    public class SerValuteToXML
    {
        public string SerToXML(List<Valute> valList)
        {
            XmlSerializer xmlSerializ = new XmlSerializer(typeof(List<Valute>));

            var j = valList.Where(selectValute => selectValute.IsSelect == '✅').Select(x => x.CharCode).ToList();
            string kek = "";

            for (int i = 0; i < j.Count; i++)
            {
                kek += j[i] + " ";
            }

            



            return kek;
            
        }
    }
}




//public class SerValuteToXML
//{
//    public string SerToXML(List<Valute> valList)
//    {
//        XmlSerializer xmlSerializ = new XmlSerializer(typeof(List<Valute>));

//        var j = valList.Where(selectValute => selectValute.IsSelect == '✅').Select(x => x.CharCode).ToList();

//        using (var sw = new Utf8StringWriter())
//        {
//            xmlSerializ.Serialize(sw, valList.Where(selectValute => selectValute.IsSelect == '✅').ToList());
//            return sw.ToString();
//        }
//    }
//}

//public class Utf8StringWriter : StringWriter
//{
//    // Use UTF8 encoding but write no BOM to the wire
//    public override Encoding Encoding
//    {
//        get { return new UTF8Encoding(false); } // in real code I'll cache this encoding.
//    }
//}