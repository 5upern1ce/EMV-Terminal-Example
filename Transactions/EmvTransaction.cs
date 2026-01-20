using EMV.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.Transaction
{
    internal class EmvTransaction
    {
        private decimal _amount;
        private DateTime _timestamp;
        private TransactionStage _currentStage;
        private TransactionResult? _result;
        private DeclineReason _declineReason = DeclineReason.None;
        public EmvTransaction(decimal amount)
        {
            _amount = amount;
            _timestamp = DateTime.Now;
            _currentStage = TransactionStage.ApplicationSelection;
        }

        public decimal Amount => _amount;
        public DateTime Timestamp => _timestamp;
        public TransactionStage CurrentStage => _currentStage;
        public TransactionResult? Result => _result;

        public DeclineReason DeclineReason => _declineReason;

        // Move on to the next stage of transaction
        public void AdvanceTo(TransactionStage nextStage)
        {
            _currentStage = nextStage;
        }

        // On completion of the transaction, set the result
        public void Complete(TransactionResult result, DeclineReason reason = DeclineReason.None)
        {
            _result = result;
            // If declined, set the reason. Otherwise, ensure reason is None.
            _declineReason = reason;
            _currentStage = TransactionStage.Completion;
        }
    }
}
