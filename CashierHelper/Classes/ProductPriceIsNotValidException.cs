using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    //This exception class indicates that the product price is not valid
    public class ProductPriceIsNotValidException : Exception 
    {
        public ProductPriceIsNotValidException()
        {
        }

        public ProductPriceIsNotValidException(string message) : base(message)
        {
        }

        public ProductPriceIsNotValidException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
