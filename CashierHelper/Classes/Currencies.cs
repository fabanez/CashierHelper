using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    public class Currency : ICurrency
    {
        private readonly string name;
        private readonly double[] denominations;

        public Currency(string Name, double[] Denominations)
        {
            name = Name;
            denominations = Denominations;
            Array.Sort<double>(denominations);
        }

        public string Name()
        {
            return name;
        }

        public double[] Denominations()
        {
            return denominations;
        }

        public Boolean IsValidDenomination(double Amount)
        {
            Boolean result = false;
            foreach (double Item in denominations)
            {
                if (Item == Amount)
                {
                    result = true;
                }
            }
            return result;
        }

        public double GetLargestDenominationFromAmount(double Amount)
        {
            double value = 0;
            foreach(double Item in denominations)
            {
                if(Item <= Amount)
                {
                    value = Item;
                }
                else
                {
                    break;
                }
            }
            return value;
        }
    }

    //class USD : Currency
    //{
    //    private string name;
        
    //    public USD()
    //    {
    //        name = "USD";
    //    }

    //    public string Name()
    //    {
    //        return name;
    //    }

    //    public double[] Denominations()
    //    {
    //        return new double[] { 0.01, 0.1, 0.25, 0.5, 1, 2, 10, 20, 50, 100};
    //    }
    //}

    //class MXP : Currency
    //{
    //    private string name;
        
    //    public MXP()
    //    {
    //        name = "MXP";
    //    }

    //    public string Name()
    //    {
    //        return name;
    //    }

    //    public double[] Denominations()
    //    {
    //        return new double[] { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100 };
    //    }
    //}
}
