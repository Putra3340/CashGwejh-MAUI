using System;
using System.Collections.Generic;
using System.Text;

namespace CashGwejh.Utils
{
    public static class CurrencyHelper
    {
        public static string FormatCurrency(decimal amount, string currencyCode)
        {
            return currencyCode switch
            {
                "USD" => amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-US")),
                "EUR" => amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("fr-FR")),
                "GBP" => amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-GB")),
                "JPY" => amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("ja-JP")),
                "IDR" => amount.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("id-ID")),
                _ => amount.ToString("C")
            };
        }
    }
}
