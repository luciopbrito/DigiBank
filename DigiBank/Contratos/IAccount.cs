using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Contratos
{
    public interface IAccount
    {
        void Deposit(double value);
        bool CashOut(double value);
        double ConsultBalance();
        string GetCodeAccount();
        string GetCodeAgency();       
        int GetCodeBank();
    }
}
