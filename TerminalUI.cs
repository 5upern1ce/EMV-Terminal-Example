using EMV.Card;
using EMV.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV
{
    internal class TerminalUI
    {
        public static EmvCard SetCard() {
            Console.WriteLine("=== Card Setup ===");

            string pan;
            while (true)
            {
                Console.Write("Enter PAN: ");
                pan = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(pan))
                {
                    Console.WriteLine("PAN cannot be empty.");
                }
                else
                {
                    break;
                }
            };

            DateTime expiryDate;
            while (true) {
                Console.Write("Enter expiry date (MM/YY): ");
                string expiryInput = Console.ReadLine();
                if (!DateTime.TryParseExact(expiryInput, "MM/yy", null, System.Globalization.DateTimeStyles.None, out expiryDate))
                {
                    Console.WriteLine("Invalid date format. Please use MM/YY.");
                }
                else
                {
                    break;
                }
            }

            decimal contactlessLimit;
            while (true) {
                Console.Write("Enter contactless limit: ");
                contactlessLimit = decimal.Parse(Console.ReadLine());
                if (contactlessLimit <= 0)
                {
                    Console.WriteLine("Contactless limit must be positive.");
                }
                else
                {
                    break;
                }
            }

            string pin;
            while (true)
            {
                Console.Write("Set 4-digit PIN: ");
                pin = Console.ReadLine();
                if ((pin.Length != 4) || !pin.All(char.IsDigit))
                {
                    Console.WriteLine("PIN must be exactly 4 digits.");
                }
                else
                {
                    break;
                }
            }

            var card = new EmvCard(
                pan,
                expiryDate,
                contactlessLimit,
                pin
            );

            return card;
        }

        public static EmvTerminal SetTerminal() {
            Console.WriteLine("=== Terminal Setup ===");

            string terminalId;
            while (true) {
                Console.Write("Enter Terminal ID: ");
                terminalId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(terminalId))
                {
                    Console.WriteLine("Terminal ID cannot be empty.");
                }
                else
                {
                    break;
                }
            }

            string countryCode;
            while (true) {

                Console.Write("Enter Country Code (ISO 3166), if in the UK, 826 is the code: ");
                countryCode = Console.ReadLine();

                if (countryCode.Length != 3 || !countryCode.All(char.IsDigit))
                {
                    Console.WriteLine("Country code must be exactly 2 letters.");
                }
                else
                {
                    break;
                }
            }
            
            bool supportsPin;
            while (true)
            {
                Console.Write("Supports PIN? (y/n): ");
                supportsPin = Console.ReadLine().ToLower() == "y";
                if(supportsPin == false || supportsPin == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' or 'n'.");
                }
            }

            bool supportsContactless;
            while (true)
            {
                Console.Write("Supports Contactless? (y/n): ");
                supportsContactless = Console.ReadLine().ToLower() == "y";
                if (supportsContactless == false || supportsContactless == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' or 'n'.");
                }
            }

            var terminal = new EmvTerminal(
                terminalId,
                countryCode,
                supportsPin,
                supportsContactless
            );
            return terminal;
        }
    }
}
