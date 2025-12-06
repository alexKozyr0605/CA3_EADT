namespace Currency
{
    public enum CurrencyTypes
    {
        CAD,
        CHF,
        USD,
        GBP,
        AUD,
        JPY,
    }
    public class Exchange
    {
        public CurrencyTypes Quote { get; set; }
        public double Rate { get; set; }
        public Exchange(CurrencyTypes quote, double rate)
        {
            this.Quote = quote;
            this.Rate = rate;
        }
    }
    public class Conversion
    {
        private static List<Exchange> cur = new List<Exchange>()
        {
            new Exchange(CurrencyTypes.CAD, 1.6205),
            new Exchange(CurrencyTypes.CHF, 0.932),
            new Exchange(CurrencyTypes.USD, 1.1597),
            new Exchange(CurrencyTypes.GBP, 0.876),
            new Exchange(CurrencyTypes.AUD, 1.7704),
            new Exchange(CurrencyTypes.JPY, 181.10),
        };
        public double Amount { get; set; }
        public CurrencyTypes Quote { get; set; }
        public double QuoteAmount
        {
            get
            {
                var cncy = cur.FirstOrDefault(c => (c.Quote == Quote));
                return Amount * cncy.Rate;
            }
        }
    }

}