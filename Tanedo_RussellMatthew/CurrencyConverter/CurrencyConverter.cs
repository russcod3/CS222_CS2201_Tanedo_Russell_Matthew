using System;

class CurrencyConverter
{
    static void Main()
    {
        Console.Write("Enter amount in USD: ");
        double usd = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter exchange rate from USD to EUR: ");
        double ExchangeRate = Convert.ToDouble(Console.ReadLine());

        double EurAmount = usd * ExchangeRate;

        Console.WriteLine("Amount in EUR: " + EurAmount.ToString("0.00"));
    }
}