using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.Transaction
{
    internal enum TransactionStage
    {
        ApplicationSelection,
        RiskManagement,
        CardAuthentication,
        CardholderVerification,
        Authorisation,
        Completion
    }
}
