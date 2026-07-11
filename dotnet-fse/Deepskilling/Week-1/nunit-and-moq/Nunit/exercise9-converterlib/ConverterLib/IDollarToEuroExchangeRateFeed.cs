using System;

namespace CurrencyConverterApp
{
    public interface IDollarToEuroExchangeRateFeed
    {
        double GetActualUSDollarValue();
    }
}
