using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Bank
    {
        public int NumberBank { get; private set; }
        public int[] Banks = new int[99];
        public Bank()
        {
            Random r = new Random();
            this.NumberBank = 0 + r.Next(0, this.Banks.Length);
        }
    }
}
