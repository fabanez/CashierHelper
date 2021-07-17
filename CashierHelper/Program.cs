using CashierHelper.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace CashierHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VirtualCashier Cashier = new VirtualCashier();
                List<Money> Payment = new List<Money>();
                List<Money> ChangeBack = new List<Money>();
                Currency SystemCurrency;
                double Price, Amount, PaymentSum;
                string Capture;

                // A global currency is configured in App.config file
                string globalCurrency = ConfigurationManager.AppSettings["GlobalCurrency"];

                //Defines a currency to use depending on system configuration
                SystemCurrency = Mint.GetCurrency(globalCurrency);

                //Prompt for the item price
                while (true)
                {
                    Console.Write($"Please enter item price in {globalCurrency}: ");
                    Capture = Console.ReadLine();
                    if (double.TryParse(Capture, out Price))
                    {
                        if (Price > 0) break;
                    }
                }

                PaymentSum = 0;
                //Prompt for the payment
                while (true)
                {
                    Console.Write($"Please enter bills or coins in {globalCurrency} for the payment (0 to end capture): ");
                    Capture = Console.ReadLine();
                    if (double.TryParse(Capture, out Amount))
                    {
                        if(Amount == 0)
                        {
                            if(PaymentSum >= Price)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Not enough money to cover the payment.");
                                continue;
                            }
                        }

                        if(SystemCurrency.IsValidDenomination(Amount))
                        {
                            Payment.Add(new Money(SystemCurrency, Amount));
                            PaymentSum += Amount;
                        }
                        else
                        {
                            Console.WriteLine($"Enter a valid denomination for {globalCurrency}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid number.");
                    }
                }

                ChangeBack = Cashier.Change(Price, Payment);

                Console.WriteLine("====================");
                Console.WriteLine("Return change");
                Console.WriteLine("====================");
                foreach(Money Item in ChangeBack)
                {
                    Console.WriteLine($"{globalCurrency} {Item.Value()}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error has ocurred: {ex.ToString()}");
            }
        }
    }
}
