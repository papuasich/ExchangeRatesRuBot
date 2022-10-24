namespace ExchangeRateRuBotParser
{
    public class Valute
    {
        public char? IsSelect { get; set; } = '⬜';
        public string? Name { get; }
        public string? CharCode { get; }
        public decimal Value { get; }
        public decimal Nominal { get; }

        public Valute()
        {

        }

        public Valute(string? name, string? charCode, decimal value, decimal nominal)
        {
            Name = name;
            CharCode = charCode;
            Value = value;
            Nominal = nominal;
        }
    }

    public class ValuteList
    {
        public static List<Valute> valuteList { get; private set; }
        public static string? ValuteRequestDate;

        public ValuteList() { }

        public ValuteList(List<Valute> _valuteList, string Date)
        {
            valuteList = _valuteList;
            ValuteRequestDate = Date;
        }
    }
}