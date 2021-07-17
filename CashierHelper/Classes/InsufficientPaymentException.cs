using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    //This exception class indicates that the payment amount is insufficient to cover the item value
    public class InsufficientPaymentException : Exception 
    {
        public InsufficientPaymentException()
        {
        }

        public InsufficientPaymentException(string message) : base(message)
        {
        }

        public InsufficientPaymentException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}
