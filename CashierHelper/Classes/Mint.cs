using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    //this class is a factory that defines the different currencies handled by the system.
    //To expland the functionality of the program, is needed to add other definitions of currencies and their denominations.
    public class Mint
    {
        //Return the name of the official currency for the country name given.
        public static string GetOfficialCurrencyFromCountry(string Country)
        {
            Country = Country.ToUpper();
            switch (Country)
            {
                case "USA":
                    return "USD";

                case "MEXICO":
                    return "MXP";

                default:
                    //empty for not implemented
                    return string.Empty;
            }
        }

        //Return a currency depending on the name given.
        public static Currency GetCurrency(string Name)
        {
            Name = Name.ToUpper();
            switch (Name)
            {
                case "USD":
                    return new Currency("USD", new double[] {0.01, 0.05, 0.1, 0.25, 0.5, 1, 2, 5, 10, 20, 50, 100});

                case "MXP":
                    return new Currency("MXP", new double[] {0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100});

                default:
                    //null for not implemented
                    return null;
            }
        }
    }
}
