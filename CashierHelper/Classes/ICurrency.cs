using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    public interface ICurrency
    {
        string Name();
        double[] Denominations();
    }
}
