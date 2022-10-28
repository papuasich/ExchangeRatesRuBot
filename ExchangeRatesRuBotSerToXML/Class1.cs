using ExchangeRateRuBotParser;
using System.Xml;
using System.Xml.Serialization;

namespace ExchangeRatesRuBotSerToXML
{
    public class Class1
    {
        public void SerToXML(List<Valute> valList)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Valute));




            //string kek = xml.Serialize(,valList);


                
          

            //var kek = xml.Serialize();

        }


        



    }


}



//User user1 = new User();





//using (FileStream fs = new FileStream("user.xml", FileMode.OpenOrCreate))
//{
//    xml.Serialize(fs, user1);
//}





//public class User
//{

//    public int age = 12;
//    public string name = "Max";
//    public string sex = "Male";
//}
