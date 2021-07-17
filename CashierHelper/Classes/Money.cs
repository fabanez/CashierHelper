using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashierHelper.Classes
{
    public class Money
    {
        private readonly double value;
        private readonly Currency currency;

        public Money(Currency Cur, double val)
        {
            currency = Cur;
            if (!currency.Denominations().Contains(val))
            {
                throw new CurrencyDenominationNotValidException("Currency denomination value is not valid.");
            }
            value = val;
        }

        public Currency Currency()
        {
            return currency;
        }

        public double Value()
        {
            return value;
        }
    }
}
