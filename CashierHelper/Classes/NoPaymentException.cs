using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    public class NoPaymentException: Exception
    {
        public NoPaymentException()
        {
        }

        public NoPaymentException(string message) : base(message)
        {
        }

        public NoPaymentException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
