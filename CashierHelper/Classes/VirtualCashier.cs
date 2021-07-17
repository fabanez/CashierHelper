using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    public class VirtualCashier
    {
        private Currency currency;

        //Method that draws change from the transaction
        //Receives the product price and the list of money used to do the payment
        public List<Money> Change(double ProductPrice, List<Money> Payment)
        {
            double Difference;
            double TotalPayment;
            double MoneyValue;
            List<Money> change = new List<Money>();

            //Validation of the product price
            if (ProductPrice < 0)
            {
                throw new ProductPriceIsNotValidException("The product price is not valid.");
            }

            //Gets the currency to work with
            currency = null;
            foreach (Money Item in Payment){
                currency = Item.Currency();
                break;
            }

            if (currency == null)
            {
                throw new NoPaymentException("No payment has been issued.");
            }

            //Get the total payment amount
            TotalPayment = 0;
            foreach (Money Item in Payment) {
                TotalPayment += Item.Value();
            }

            //Calculation of the difference
            Difference = TotalPayment - ProductPrice ;

            if (Difference < 0)
            {
                //throws an error indicating insufficient payment
                throw new InsufficientPaymentException($"Insufficient payment, {Difference * -1} more is needed.");
            }

            while (Difference > 0) {
                MoneyValue = currency.GetLargestDenominationFromAmount(Difference);

                if(MoneyValue == 0)
                {
                    break;
                }

                change.Add(new Money(currency, MoneyValue));
                Difference = Math.Round(Difference - MoneyValue, 2);
            }

            return change;
        }
    }
}
