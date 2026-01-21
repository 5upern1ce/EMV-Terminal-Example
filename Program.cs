using EMV;
using EMV.Card;
using EMV.Issuer;
using EMV.Terminal;
using EMV.Transaction;
using EMV.Transactions;

class Program
{
    static void Main(string[] args)
    {
        // Set things up
        var card = TerminalUI.SetCard();

        var terminal = TerminalUI.SetTerminal();

        var bank = new IssuerBank(100.00m);

        var transaction = new EmvTransaction(35.00m);


        // --- EMV FLOW ---
        EmvLogger.Log("Application Selection");

        transaction.AdvanceTo(TransactionStage.RiskManagement);

        EmvLogger.Log("Risk Management");

        if (terminal.RequiresPin(transaction.Amount, card))
        {
            transaction.AdvanceTo(TransactionStage.CardholderVerification);

            EmvLogger.Log("Pin Required");

            Console.Write("Enter PIN: ");
            string enteredPin = Console.ReadLine();

            if (!card.VerifyPin(enteredPin))
            {
                transaction.Complete(TransactionResult.Declined, DeclineReason.IncorrectPin);
                EmvLogger.Log($"Transaction Declined due to - {transaction.DeclineReason}");
                return;
            }
            EmvLogger.Log("PIN Verified");
        }
        else
        {
            EmvLogger.Log("No PIN Required");
        }

        transaction.AdvanceTo(TransactionStage.Authorisation);

        EmvLogger.Log("Authorisation");

        if (bank.HasSufficientFunds(transaction.Amount))
        {
            bank.Debit(transaction.Amount);
            transaction.Complete(TransactionResult.Approved);
            EmvLogger.Log("Transaction Approved");
        }
        else
        {
            transaction.Complete(TransactionResult.Declined, DeclineReason.InsufficientFunds);
            EmvLogger.Log($"Transaction Declined due to - {transaction.DeclineReason}");
        }

        Console.WriteLine($"Transaction result: {transaction.Result}");
    }
}