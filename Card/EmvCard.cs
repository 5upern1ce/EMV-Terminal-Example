using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.Card
{
    internal class EmvCard
    {
        // This is the card's stored data, these are handed over when the chip makes contact with the reader
        // This is part of Level 1

        // PAN is a primary account number and it's the long, unique number on the credit or debit card.
        private string _pan;

        private DateTime _expiryDate;

        // Some banks have different contactless limits, however the default in the UK is £100
        private decimal _contactlessLimit;

        // I chose a string in case the pin starts with a 0, where an integer would strip the 0.
        private string _pin;

        public EmvCard(string pan, DateTime expiryDate, decimal contactlessLimit, string pin)
        {
            ValidatePin(pin);
            _pan = pan;
            _expiryDate = expiryDate;
            _contactlessLimit = contactlessLimit;
            _pin = pin;
        }

        // Splits the last 4 digits of the card and hides the first 12, a real bank system may show this to ensure that card data is kept protected due to the sensitivity of it
        public string GetMaskedPan()
        {
            return "**** **** **** " + _pan.Substring(_pan.Length - 4);
        }

        // Things the card can do
        public bool IsExpired()
        {
            return DateTime.Now > _expiryDate;
        }

        // If the transaction amount is above the contactless limit, then the user must insert their card and put in the pin
        public bool RequiresPin(decimal transactionAmount)
        {
            return transactionAmount > _contactlessLimit;
        }

                // To ensure the length of the pin is 4 digits and all numbers despite being a string
        private void ValidatePin(string pin)
        {
            if (pin.Length != 4)
                throw new ArgumentException("PIN must be exactly 4 digits.");

            foreach (char c in pin)
            {
                if (!char.IsDigit(c))
                    throw new ArgumentException("PIN must contain only digits.");
            }
        }
    }
}
