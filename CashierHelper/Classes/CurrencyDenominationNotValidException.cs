using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    //This exception class indicates that the value of the currency does not fit any of the registered denominations
    public class CurrencyDenominationNotValidException: Exception
    {
        public CurrencyDenominationNotValidException()
        {
        }

        public CurrencyDenominationNotValidException(string message) : base(message)
        {
        }

        public CurrencyDenominationNotValidException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
