using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class CheckingAccount : Account
    {
        public CheckingAccount()
        {
            this.NumberAccount = "00" + Account.TotalAccounts;
        }
    }
}
