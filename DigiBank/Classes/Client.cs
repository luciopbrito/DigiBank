using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.Contratos;

namespace DigiBank.Classes
{
    public class Client
    {
        public string Name { get; private set; }
        public double CPF { get; private set; }
        public string Passaword { get; private set; }
        public Extract Extract;
        public void AddTypeExtract(string type)
        {
            this.Extract = new Extract(type);            
        }
    
        public IAccount Account { get; set; }

        public static List<Client> Clients = new List<Client>();
        public static int CheckClient(double cpf, string password)
        {
            int clientReturn = 0;
            foreach (Client clientEach in Clients)
            {
                if (cpf == clientEach.CPF && password != clientEach.Passaword)
                {
                    clientReturn = 1;
                }
                if (cpf == clientEach.CPF && password == clientEach.Passaword)
                {                   
                    Layout.ScreenLoginInAccount(clientEach);
                }
            }
            return clientReturn;
        }
        public Client(SavingsAccount account)
        {
            this.Account = account;                     
        }

        public Client(CheckingAccount account)
        {
            this.Account = account;            
        }

        public void AddName(string name)
        {
            this.Name = name;
        }

        public void AddCPF(string cpf)
        {
            this.CPF = double.Parse(cpf);
        }
        
        public void AddPassword(string password)
        {
            this.Passaword = password;
        }
    }
}
