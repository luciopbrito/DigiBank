using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.Contratos;

namespace DigiBank.Classes
{
    public abstract class Account : Bank, IAccount
    {
        public double Balance { get; protected set; }
        public string NumberAccount { get; protected set; }
        public string NumberAgency { get; private set; }
        public static int TotalAccounts { get; private set; }
      
        public Account()
        {
            Account.TotalAccounts++;          
            this.NumberAgency = "0001";
        }
        public static int NextAccount(int TotalAccounts)
        {
            return TotalAccounts++;
        }
        public virtual bool CashOut(double value)
        {
            if (value > ConsultBalance())
            {
                return false;
            }
            else
            {
                this.Balance -= value;
                return true;
            }
        }

        public double ConsultBalance()
        {
            return this.Balance;
        }

        public void Deposit(double value)
        {
            this.Balance += value;
        }

        public string GetCodeAccount()
        {
            return this.NumberAccount;
        }

        public string GetCodeAgency()
        {
            return this.NumberAgency;
        }

        public int GetCodeBank()
        {
            return this.NumberBank;
        }
    }
}
