using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class SavingsAccount : Account
    {
        public SavingsAccount()
        {
            this.NumberAccount = "00" + Account.TotalAccounts;
        }
        public override bool CashOut(double value)
        {
            bool runCashOut = base.CashOut(value);
            if (runCashOut == true)
            {
                this.Balance -= 6;
                return true;
            }
            return false;
        }
    }
}
