using System;
using Xunit;
using CashierHelper.Classes;
using System.Collections.Generic;

namespace CashierHelperTests
{
    public class VirtualCashierShould
    {
        [Fact]
        public void ThrowErrorWhenPriceIsNegative()
        {
            //Arrange
            double Price = -1;
            VirtualCashier VC = new VirtualCashier();
            List<Money> Payment = new List<Money>();

            //Act

            //Assert
            Assert.Throws<ProductPriceIsNotValidException>(() => VC.Change(Price, Payment));
        }

        [Fact]
        public void ThrowErrorWhenNoPaymentIsGiven()
        {
            //Arrange
            double Price = 20;
            VirtualCashier VC = new VirtualCashier();
            List<Money> Payment = new List<Money>();

            //Act

            //Assert
            Assert.Throws<NoPaymentException>(() => VC.Change(Price, Payment));
        }

        [Fact]
        public void ThrowErrorWhenTheresInsufficientPayment()
        {
            //Arrange
            double Price = 20;
            VirtualCashier VC = new VirtualCashier();
            List<Money> Payment = new List<Money>();
            Currency Cur;

            //Act
            Cur = Mint.GetCurrency("USD");
            Payment.Add(new Money(Cur, 10));

            //Assert
            Assert.Throws<InsufficientPaymentException>(() => VC.Change(Price, Payment));
        }

        [Fact]
        public void GiveBackTheCorrectUSDBillsAndCoins()
        {
            //Arrange
            double Price = 12.7;
            VirtualCashier VC = new VirtualCashier();
            Currency Cur = Mint.GetCurrency("USD");
            List<Money> Payment = new List<Money>();
            List<Money> Change = new List<Money>();
            List<Money> Expected = new List<Money>();

            //Act
            Payment.Add(new Money(Cur, 10));
            Payment.Add(new Money(Cur, 10));

            Expected.Add(new Money(Cur, 5));
            Expected.Add(new Money (Cur, 2));
            Expected.Add(new Money (Cur, 0.25));
            Expected.Add(new Money (Cur, 0.05));

            Change = VC.Change(Price, Payment);

            //Assert
            Assert.Equal<List<Money>>(Expected, Change, new MoneyListEqualityComparer());
        }
    }

    public class MoneyClassShould
    {
        [Fact]
        public void ThrowErrorWhenInvalidCurrencyDenomination()
        {
            //Arrange
            double Value = 101;
            Currency Cur = Mint.GetCurrency("USD");
            //Act

            //Assert
            Assert.Throws<CurrencyDenominationNotValidException>(() => new Money(Cur, Value));
        }
    }
}
