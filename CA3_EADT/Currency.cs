//Currency.cs
using CA3_EADT;
using Shared;

namespace CA3_EADT
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
    public class ConvertCurrency
    {
        public List<Exchange> cur = new List<Exchange>();
        public async Task LoadRateAsync(FrankResponse frank)
        {
            cur = frank
                .Rates.Where(r => Enum.TryParse<CurrencyTypes>(r.Key, true, out var currency))
                .Select(r => new Exchange(
                        Enum.Parse<CurrencyTypes>(r.Key),
                        (double)r.Value
                ))
                .ToList();
            foreach (var c in cur)
            {
                Console.WriteLine($"Loaded currency: {c.Quote}, Rate: {c.Rate}");
            }
        }
        public double Amount { get; set; }
        public CurrencyTypes Quote { get; set; }
        public double QuoteAmount
        {
            get
            {
                var cncy = cur.FirstOrDefault(c => (c.Quote == Quote));
                if (cncy == null) return 0;
                return Amount * cncy.Rate;
            }
        }
    }
}