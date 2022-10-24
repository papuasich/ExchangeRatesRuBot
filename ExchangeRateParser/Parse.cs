using System.Net;
using System.Text;

namespace ExchangeRateRuBotParser
{
    public class Parser
    {
        public string MakeAGETRequestToCBRF()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string sURL = "http://www.cbr.ru/scripts/XML_daily.asp";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new(objStream, Encoding.GetEncoding(1251));
            string? sLine;
            sLine = objReader.ReadLine();

            return sLine;
        }
    }
}