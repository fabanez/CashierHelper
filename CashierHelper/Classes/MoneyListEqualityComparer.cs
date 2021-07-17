using System;
using System.Collections.Generic;
using System.Text;

namespace CashierHelper.Classes
{
    public class MoneyListEqualityComparer : EqualityComparer<List<Money>>
    {
        public override bool Equals(List<Money> L1, List<Money> L2)
        {
            bool Result = false;
            if (L1 == null && L2 == null)
                return true;
            else if (L1 == null || L2 == null)
                return false;

            if(L1.Count != L2.Count){
                return false;
            }

            Result = true;
            for (int I = 0; I < L1.Count; I++)
            {
                if(L1[I].Value() != L2[I].Value())
                {
                    Result = false;
                    break;
                }
            }
           
            return Result;
        }

        public override int GetHashCode(List<Money> Ls)
        {
            return Ls.ToString().GetHashCode();
        }
    }
}
