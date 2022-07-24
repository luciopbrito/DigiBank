using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Extract
    {
        public Extract(string typeAccount)
        {
            this.TypeAccount = typeAccount;    
        }
        private string TypeAccount { get; set; }
        private List<String> ExtractList = new List<String>();
        public double SubTotal { get; private set; }
        public void AddExtract(string type, double value)
        {
            if (type == "Deposito")
            {
                string add = $"Tipo de Movimentação {type} \nValor: {value}";
                this.ExtractList.Add(add);
                this.SubTotal += value;
            }
            else
            {              
                string add = $"Tipo de Movimentação {type} \nValor: -{value}";
                if (this.TypeAccount == "SavingAccount")
                {
                    this.SubTotal -= 6;
                    add += $"\nTaxa por saque : -6";
                }
                this.ExtractList.Add(add);
                this.SubTotal -= value;
            }          
        }

        public void Moviments()
        {                                           
            foreach (string moviment in ExtractList)
            {
                Console.WriteLine(moviment);
            }
            Console.WriteLine();
            Console.WriteLine($"SubTotal : {this.SubTotal}");                              
        }
    }
}
