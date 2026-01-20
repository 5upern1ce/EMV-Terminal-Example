using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.Transactions
{
    internal enum DeclineReason
    {
        None,
        IncorrectPin,
        InsufficientFunds,
        CardExpired
    }
}
