using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.Issuer
{
    internal class IssuerBank
    {
        private decimal _balance;

        public IssuerBank(decimal startingBalance)
        {
            _balance = startingBalance;
        }

        public bool HasSufficientFunds(decimal amount)
        {
            return _balance >= amount;
        }

        public void Debit(decimal amount)
        {
            _balance -= amount;
        }
    }
}
