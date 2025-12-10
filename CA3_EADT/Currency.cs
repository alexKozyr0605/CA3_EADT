namespace CA3_EADT
{
    public enum CurrencyTypes
    {
        AUD,
        BGN,
        BRL,
        CAD,
        CHF,
        CNY,
        CZK,
        DKK,
        GBP,
        HKD,
        HUF,
        IDR,
        ILS,
        INR,
        ISK,
        JPY,
        KRW,
        MXN,
        MYR,
        NOK,
        NZD,
        PHP,
        PLN,
        RON,
        SEK,
        SGD,
        THB,
        TRY,
        USD,
        ZAR,
    }
    public class Exchange
    {
        public CurrencyTypes Quote { get; set; }
        public decimal Rate { get; set; }
        public Exchange(CurrencyTypes quote, decimal rate)
        {
            this.Quote = quote;
            this.Rate = rate;
        }
    }
    public class ConvertCurrency
    {
        public List<Exchange> cur = new List<Exchange>();
        public async Task LoadRateAsync(FrankResponse frank)
        {
            cur = frank
                .Rates.Where(r => Enum.TryParse<CurrencyTypes>(r.Key, true, out var currency))
                .Select(r => new Exchange(
                        Enum.Parse<CurrencyTypes>(r.Key),
                        (decimal)r.Value
                ))
                .ToList();
        }
        public decimal Amount { get; set; }
        public CurrencyTypes Quote { get; set; }
        public decimal QuoteAmount
        {
            get
            {
                var cncy = cur.FirstOrDefault(c => (c.Quote == Quote));
                if (cncy == null) return 0;
                decimal result =  Amount * cncy.Rate;
                return Math.Round(result, 2);
            }
        }
    }
}